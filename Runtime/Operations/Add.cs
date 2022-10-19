using System;
using System.Linq.Expressions;

namespace Agava.WalletTemplate.MathOperations
{
    internal sealed class Add<T> : IOperation<T>
    {
        private readonly T _leftValue;
        private readonly T _rightValue;

        internal Add(T leftValue, T rightValue)
        {
            _leftValue = leftValue;
            _rightValue = rightValue;
        }

        public T Result()
        {
            var type = typeof(T);

            var leftParameter = Expression.Parameter(type, nameof(_leftValue));
            var rightParameter = Expression.Parameter(type, nameof(_rightValue));
            var body = Expression.Add(leftParameter, rightParameter);

            var func = Expression.Lambda<Func<T, T, T>>(body, leftParameter, rightParameter).Compile();

            return func(_leftValue, _rightValue);
        }
    }
}