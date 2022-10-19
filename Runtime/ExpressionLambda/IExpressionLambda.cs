using System;
using JetBrains.Annotations;

namespace Agava.WalletTemplate.MathOperations
{
    internal interface IExpressionLambda<T>
    {
        [NotNull]
        Func<T, T, T> Compile();
    }
}