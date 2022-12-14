using System.Collections.Generic;
using Agava.Wallet.Attributes;
using Agava.Wallet.Model;
using Agava.Wallet.Save;
using Agava.Wallet.View;
using UnityEngine;

namespace Agava.Wallet.Presenter
{
    public abstract partial class WalletPresenter<TWallet, TWalletType> : MonoBehaviour where TWallet : IWallet<TWalletType>, new()
    {
        [SerializeField, ReadOnly] private string _id;
        [SerializeField] private List<MonoBehaviour> _walletViews = new();

        public IWallet<TWalletType> Model { get; private set; }
        protected abstract TWalletType StartValue { get; }

        private void OnValidate()
        {
            foreach (var view in _walletViews)
            {
                if (view != null && view is IWalletView<TWalletType> == false)
                {
                    Debug.LogError(nameof(view) + " needs to implement " + typeof(IWalletView<TWalletType>));
                    _walletViews.Remove(view);
                    
                    break;
                }
            }
        }

        private void Awake()
        {
            var walletInventory = new WalletInventory<TWallet, TWalletType>(_id);
            Model = new ViewedWallet<TWalletType>(new SavedWallet<TWallet, TWalletType>(walletInventory), CastWalletView());
            
            if (walletInventory.HasSave == false)
                Model.Add(StartValue);
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