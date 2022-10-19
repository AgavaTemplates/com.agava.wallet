namespace Agava.WalletTemplate.MathOperations
{
    internal interface IOperation<out T>
    {
        T Result();
    }
}