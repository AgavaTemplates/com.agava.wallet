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

        public bool CanSpend(TWalletType amount) => _wallet.CanSpend(amount);

        public void Spend(TWalletType amount)
        {
            _wallet.Spend(amount);
            _save.Save(_wallet);
        }
    }
}