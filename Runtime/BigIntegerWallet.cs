using System;
using System.Numerics;
using Newtonsoft.Json;

namespace Agava.WalletTemplate
{
    public sealed class BigIntegerWallet : IWallet<BigInteger>
    {
        [JsonProperty(nameof(Value))] public BigInteger Value { get; private set; }
        
        public void Add(BigInteger amount)
        {
            if (amount < 0)
                throw new InvalidOperationException(nameof(amount) + " less than 0");

            Value += amount;
        }

        public void Subtract(BigInteger amount)
        {
            if (Value - amount < 0)
                throw new InvalidOperationException(nameof(Value) + " less than 0");

            Value -= amount;
        }
    }
}