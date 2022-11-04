namespace Agava.Wallet
{
    public interface IWalletView<in T>
    {
        void Render(T currentValue);
    }
}