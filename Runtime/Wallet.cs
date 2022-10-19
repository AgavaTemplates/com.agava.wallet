using System;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

namespace Agava.WalletTemplate
{
    [Serializable]
    public sealed class Wallet<T> : IWallet<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        public Wallet()
        {
            var supportedTypes = new List<Type>
            {
                typeof(int),
                typeof(BigInteger)
            };
            
            if (supportedTypes.Contains(typeof(T)) == false)
                throw new NotSupportedException($"Type '{typeof(T).FullName}' isn't supported!");
        }
        
        [JsonProperty(nameof(Value))] public T Value { get; private set; }

        public void Add(T amount)
        {
            if (amount.CompareTo(0) < 0)
                throw new InvalidOperationException(nameof(amount) + " less than 0");

            Value = Calculate(Value, Operation.Plus, amount);
        }

        public void Remove(T amount)
        {
            if (Calculate(Value, Operation.Minus, amount).CompareTo(0) < 0)
                throw new InvalidOperationException(nameof(Value) + " less than 0");

            Value = Calculate(Value, Operation.Plus, amount);
        }

        private T Calculate(T leftValue, Operation operation, T rightValue)
        {
            return operation switch
            {
                Operation.Plus => (dynamic)leftValue + (dynamic)rightValue,
                Operation.Minus => (dynamic)leftValue - (dynamic)rightValue,
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
        }
    }
}