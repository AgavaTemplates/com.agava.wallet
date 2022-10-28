namespace Agava.WalletTemplate
{
    public interface IWalletView<in T>
    {
        void Render(T currentValue);
    }
}