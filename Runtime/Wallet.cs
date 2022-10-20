using System;
using System.Collections.Generic;
using System.Numerics;
using Agava.WalletTemplate.MathOperations;
using Newtonsoft.Json;

namespace Agava.WalletTemplate
{
    [Serializable]
    public sealed class Wallet<T> : IWallet<T> where T : IComparable, IComparable<T>
    {
        private readonly IExpressionLambda<T> _addExpression;
        private readonly IExpressionLambda<T> _subtractExpression;

        public Wallet()
        {
            var supportedTypes = new List<Type>
            {
                typeof(int),
                typeof(BigInteger)
            };
            
            if (supportedTypes.Contains(typeof(T)) == false)
                throw new NotSupportedException($"Type '{typeof(T).FullName}' isn't supported!");

            _addExpression = new CachedExpressionLambda<T>(new AddExpressionLambda<T>());
            _subtractExpression = new CachedExpressionLambda<T>(new SubtractExpressionLambda<T>());
        }
        
        [JsonProperty(nameof(Value))] public T Value { get; private set; }

        public void Add(T amount)
        {
            if (amount.CompareTo(0) < 0)
                throw new InvalidOperationException(nameof(amount) + " less than 0");

            Value = _addExpression.Compile()(Value, amount);
        }

        public void Subtract(T amount)
        {
            if (_subtractExpression.Compile()(Value, amount).CompareTo(0) < 0)
                throw new InvalidOperationException(nameof(Value) + " less than 0");

            Value = _subtractExpression.Compile()(Value, amount);
        }
    }
}