namespace Agava.Wallet.Model
{
    public interface IWallet<T>
    {
        T Value { get; }

        void Add(T amount);

        bool CanSpend(T amount);
        void Spend(T amount);
    }
}