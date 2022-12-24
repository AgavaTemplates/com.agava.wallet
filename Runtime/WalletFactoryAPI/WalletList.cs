#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using Agava.Wallet.Presenter;
using UnityEditor;
using UnityEngine;

namespace Agava.Wallet.WalletFactoryAPI
{
    internal sealed class WalletList
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
                return "No wallet with this id";

            Load();

            var wallets = new List<GameObject>();
            _intWallets.Where(wallet => wallet.Id == walletId).ToList().ForEach(wallet => wallets.Add(wallet.gameObject));
            _bigIntegerWallets.Where(wallet => wallet.Id == walletId).ToList().ForEach(wallet => wallets.Add(wallet.gameObject));

            string path = "";

            foreach (var wallet in wallets)
            {
                if (AssetDatabase.Contains(wallet) == false)
                    continue;

                return AssetDatabase.GetAssetPath(wallet);
            }

            return path;
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
#endif