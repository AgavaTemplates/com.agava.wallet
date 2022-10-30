using System;
using Newtonsoft.Json;

namespace Agava.Wallet
{
    [Serializable]
    public sealed class IntWallet : IWallet<int>
    {
        [JsonProperty] public int Value { get; private set; }
        
        public void Add(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount) + " less than 0");

            if (Value + amount < 0)
                throw new OverflowException(nameof(Value) + " out of range Int32. Use BigIntegerWallet");

            Value += amount;
        }

        public bool TrySpend(int amount)
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