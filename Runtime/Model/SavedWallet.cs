using Agava.Wallet.Save;

namespace Agava.Wallet.Model
{
    internal sealed class SavedWallet<TWallet, TWalletType> : IWallet<TWalletType> where TWallet : IWallet<TWalletType>, new()
    {
        private readonly TWallet _wallet;
        private readonly WalletInventory<TWallet, TWalletType> _inventory;

        internal SavedWallet(WalletInventory<TWallet, TWalletType> inventory)
        {
            _inventory = inventory;
            _wallet = inventory.Load();
        }

        public TWalletType Value => _wallet.Value;
        
        public void Add(TWalletType amount)
        {
            _wallet.Add(amount);
            _inventory.Save(_wallet);
        }

        public bool CanSpend(TWalletType amount) 
            => _wallet.CanSpend(amount);

        public void Spend(TWalletType amount)
        {
            _wallet.Spend(amount);
            _inventory.Save(_wallet);
        }
    }
}