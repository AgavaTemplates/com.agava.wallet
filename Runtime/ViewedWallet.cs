namespace Agava.WalletTemplate
{
    public sealed class ViewedWallet<T> : IWallet<T>
    {
        private readonly IWallet<T> _wallet;
        private readonly IWalletView<T> _view;

        public ViewedWallet(IWallet<T> wallet, IWalletView<T> view)
        {
            _wallet = wallet;
            _view = view;
        }

        public T Value => _wallet.Value;
        
        public void Add(T amount)
        {
            _wallet.Add(amount);
            _view.Render(Value);
        }

        public void Subtract(T amount)
        {
            _wallet.Subtract(amount);
            _view.Render(Value);
        }
    }
}