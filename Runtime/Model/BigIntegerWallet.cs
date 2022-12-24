using System;
using System.Numerics;
using Newtonsoft.Json;

namespace Agava.Wallet.Model
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
        
        public bool CanSpend(BigInteger amount) 
            => amount >= 0 && Value - amount >= 0;

        public void Spend(BigInteger amount)
        {
            if (CanSpend(amount) == false)
                throw new InvalidOperationException("Can't spend");

            Value -= amount;
        }
    }
}