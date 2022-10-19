using System;
using JetBrains.Annotations;

namespace Agava.WalletTemplate.MathOperations
{
    internal sealed class CachedExpressionLambda<T> : IExpressionLambda<T>
    {
        private readonly IExpressionLambda<T> _expressionLambda;
        [CanBeNull] private Func<T, T, T> _value;

        internal CachedExpressionLambda(IExpressionLambda<T> expressionLambda)
        {
            _expressionLambda = expressionLambda;
        } 
        
        public Func<T, T, T> Compile()
        {
            return _value ??= _expressionLambda.Compile();
        }
    }
}