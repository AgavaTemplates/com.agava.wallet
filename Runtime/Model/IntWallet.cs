using System;
using Newtonsoft.Json;

namespace Agava.Wallet.Model
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

        public bool CanSpend(int amount) => amount >= 0 && Value - amount >= 0;

        public void Spend(int amount)
        {
            if (CanSpend(amount) == false)
                throw new InvalidOperationException("Can't spend");

            Value -= amount;
        }
    }
}