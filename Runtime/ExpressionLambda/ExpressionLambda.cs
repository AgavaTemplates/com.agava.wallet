using System;
using System.Linq.Expressions;

namespace Agava.WalletTemplate.MathOperations
{
    internal abstract class ExpressionLambda<T> : IExpressionLambda<T>
    {
        public Func<T, T, T> Compile()
        {
            var leftValue = Expression.Parameter(typeof(T));
            var rightValue = Expression.Parameter(typeof(T));
            var body = GetBody(leftValue, rightValue);
            
            return Expression.Lambda<Func<T, T, T>>(body, leftValue, rightValue).Compile();
        }
        
        protected abstract BinaryExpression GetBody(ParameterExpression leftParameter, ParameterExpression rightParameter);
    }
}