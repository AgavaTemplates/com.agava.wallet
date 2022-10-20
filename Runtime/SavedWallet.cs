using System;

namespace Agava.WalletTemplate
{
    public sealed class SavedWallet<T> : IWallet<T> where T : IComparable, IComparable<T>
    {
        private readonly IWallet<T> _wallet;
        private readonly WalletSave<T> _save;

        public SavedWallet(WalletSave<T> save)
        {
            _save = save;
            _wallet = save.Load();
        }

        public T Value => _wallet.Value;
        
        public void Add(T amount)
        {
            _wallet.Add(amount);
            _save.Save(_wallet);
        }

        public void Remove(T amount)
        {
            _wallet.Remove(amount);
            _save.Save(_wallet);
        }
    }
}