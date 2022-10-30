using System.Collections.Generic;
using UnityEngine;

namespace Agava.Wallet
{
    public abstract class WalletPresenter<TWallet, TWalletType> : MonoBehaviour where TWallet : IWallet<TWalletType>, new()
    {
        [SerializeField] private string _id;
        [SerializeField] private List<MonoBehaviour> _walletViews;

        public IWallet<TWalletType> Model { get; private set; }

        private void OnValidate()
        {
            foreach (var view in _walletViews)
            {
                if (view && view is IWalletView<TWalletType> == false)
                {
                    Debug.LogError(nameof(view) + " needs to implement " + typeof(IWalletView<TWalletType>));
                    _walletViews.Remove(view);
                    
                    break;
                }
            }
        }

        private void Awake()
        {
            Model = new ViewedWallet<TWalletType>(
                        new SavedWallet<TWallet, TWalletType>(
                            new WalletSave<TWallet, TWalletType>(_id)
                ), CastWalletView());
        }

        private IWalletView<TWalletType>[] CastWalletView()
        {
            var castedWalletViews = new IWalletView<TWalletType>[_walletViews.Count];

            for (int i = 0; i < _walletViews.Count; i++)
                castedWalletViews[i] = (IWalletView<TWalletType>)_walletViews[i];

            return castedWalletViews;
        }
    }
}