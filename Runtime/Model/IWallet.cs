namespace Agava.Wallet
{
    public interface IWallet<T>
    {
        T Value { get; }

        void Add(T amount);
        bool TrySpend(T amount);
    }
}