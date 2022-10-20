using System;
using Newtonsoft.Json;

namespace Agava.WalletTemplate
{
    public sealed class IntWallet : IWallet<int>
    {
        [JsonProperty(nameof(Value))] public int Value { get; private set; }
        
        public void Add(int amount)
        {
            if (amount < 0)
                throw new InvalidOperationException(nameof(amount) + " less than 0");

            Value += amount;
        }

        public void Subtract(int amount)
        {
            if (Value - amount < 0)
                throw new InvalidOperationException(nameof(Value) + " less than 0");

            Value -= amount;
        }
    }
}