using System.Linq.Expressions;

namespace Agava.WalletTemplate.MathOperations
{
    internal sealed class SubtractExpressionLambda<T> : ExpressionLambda<T>
    {
        protected override BinaryExpression GetBody(ParameterExpression leftParameter, ParameterExpression rightParameter)
        {
            return Expression.Subtract(leftParameter, rightParameter);
        }
    }
}