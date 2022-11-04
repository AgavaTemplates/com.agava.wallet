namespace Agava.Wallet
{
    public interface IWallet<T>
    {
        T Value { get; }

        void Add(T amount);

        bool CanSpend(T amount);
        void Spend(T amount);
    }
}