namespace Agava.Wallet.View
{
    public interface IWalletView<in T>
    {
        void Render(T currentValue);
    }
}