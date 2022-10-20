namespace Agava.WalletTemplate
{
    public interface IWallet<T>
    {
        T Value { get; }

        void Add(T amount);
        void Subtract(T amount);
    }
}