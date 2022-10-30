using System;
using System.Numerics;
using Newtonsoft.Json;

namespace Agava.Wallet
{
    [Serializable]
    public sealed class BigIntegerWallet : IWallet<BigInteger>
    {
        [JsonProperty] public BigInteger Value { get; private set; }
        
        public void Add(BigInteger amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount) + " less than 0");

            Value += amount;
        }

        public bool TrySpend(BigInteger amount)
        {
            if (amount < 0)
                return false;

            if (Value - amount < 0)
                return false;

            Value -= amount;
            return true;
        }
    }
}