namespace Agava.WalletTemplate
{
    internal sealed class ViewedWallet<T> : IWallet<T>
    {
        private readonly IWallet<T> _wallet;
        private readonly IWalletView<T>[] _views;

        internal ViewedWallet(IWallet<T> wallet, params IWalletView<T>[] views)
        {
            _wallet = wallet;
            _views = views;
            
            UpdateViews();
        }

        public T Value => _wallet.Value;
        
        public void Add(T amount)
        {
            _wallet.Add(amount);
            UpdateViews();
        }

        public void Subtract(T amount)
        {
            _wallet.Subtract(amount);
            UpdateViews();
        }

        private void UpdateViews()
        {
            foreach (var view in _views)
                view.Render(Value);
        }
    }
}