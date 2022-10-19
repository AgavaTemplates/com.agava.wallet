using System.Linq.Expressions;

namespace Agava.WalletTemplate.MathOperations
{
    internal sealed class AddExpressionLambda<T> : ExpressionLambda<T>
    {
        protected override BinaryExpression GetBody(ParameterExpression leftParameter, ParameterExpression rightParameter)
        {
            return Expression.Add(leftParameter, rightParameter);
        }
    }
}