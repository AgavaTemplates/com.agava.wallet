using System;
using System.Collections.Generic;
using System.Numerics;
using Agava.WalletTemplate.MathOperations;
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

            Value = new Add<T>(Value, amount).Result();
        }

        public void Remove(T amount)
        {
            if (new Subtract<T>(Value, amount).Result().CompareTo(0) < 0)
                throw new InvalidOperationException(nameof(Value) + " less than 0");

            Value = new Subtract<T>(Value, amount).Result();
        }
    }
}