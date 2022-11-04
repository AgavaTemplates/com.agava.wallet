namespace Agava.Wallet
{
    internal sealed class ViewedWallet<TWalletType> : IWallet<TWalletType>
    {
        private readonly IWallet<TWalletType> _wallet;
        private readonly IWalletView<TWalletType>[] _views;

        internal ViewedWallet(IWallet<TWalletType> wallet, params IWalletView<TWalletType>[] views)
        {
            _wallet = wallet;
            _views = views;
            
            UpdateViews();
        }

        public TWalletType Value => _wallet.Value;
        
        public void Add(TWalletType amount)
        {
            _wallet.Add(amount);
            UpdateViews();
        }

        public bool CanSpend(TWalletType amount) => _wallet.CanSpend(amount);

        public void Spend(TWalletType amount)
        {
            _wallet.Spend(amount);
            UpdateViews();
        }

        private void UpdateViews()
        {
            foreach (var view in _views)
                view.Render(Value);
        }
    }
}