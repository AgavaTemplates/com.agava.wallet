namespace Agava.Wallet
{
    internal sealed class SavedWallet<TWallet, TWalletType> : IWallet<TWalletType> where TWallet : IWallet<TWalletType>, new()
    {
        private readonly TWallet _wallet;
        private readonly WalletSave<TWallet, TWalletType> _save;

        internal SavedWallet(WalletSave<TWallet, TWalletType> save)
        {
            _save = save;
            _wallet = save.Load();
        }

        public TWalletType Value => _wallet.Value;
        
        public void Add(TWalletType amount)
        {
            _wallet.Add(amount);
            _save.Save(_wallet);
        }

        public bool TrySpend(TWalletType amount)
        {
            if (_wallet.TrySpend(amount) == false)
                return false;
            
            _save.Save(_wallet);
            return true;
        }
    }
}