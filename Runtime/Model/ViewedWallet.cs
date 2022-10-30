namespace Agava.Wallet
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

        public bool TrySpend(T amount)
        {
            if (_wallet.TrySpend(amount) == false)
                return false;
            
            UpdateViews();
            return true;
        }

        private void UpdateViews()
        {
            foreach (var view in _views)
                view.Render(Value);
        }
    }
}