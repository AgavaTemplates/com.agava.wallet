using System.Collections.Generic;
using System.Linq;
using Agava.Wallet.Presenter;
using UnityEditor;
using UnityEngine;

namespace Agava.Wallet.WalletFactoryAPI
{
    internal class WalletList
    {
        private readonly List<IntWalletPresenter> _intWallets = new();
        private readonly List<BigIntegerWalletPresenter> _bigIntegerWallets = new();

        internal bool HasWalletWith(string walletId)
        {
            Load();
            
            if (_intWallets.Count + _bigIntegerWallets.Count == 0)
                return false;
            
            return _intWallets.Any(wallet => wallet.Id == walletId) || _bigIntegerWallets.Any(wallet => wallet.Id == walletId);
        }

        internal string PathToWalletWith(string walletId)
        {
            if (HasWalletWith(walletId) == false)
                return "";

            Load();

            var intWallet = _intWallets.FirstOrDefault(wallet => wallet.Id == walletId);
            var bigIntegerWallet = _bigIntegerWallets.FirstOrDefault(wallet => wallet.Id == walletId);

            return AssetDatabase.GetAssetPath(intWallet != null ? intWallet : bigIntegerWallet);
        }

        private void Load()
        {
            _intWallets.Clear();
            _bigIntegerWallets.Clear();

            _intWallets.AddRange(Resources.FindObjectsOfTypeAll<IntWalletPresenter>());
            _bigIntegerWallets.AddRange(Resources.FindObjectsOfTypeAll<BigIntegerWalletPresenter>());
        }
    }
}