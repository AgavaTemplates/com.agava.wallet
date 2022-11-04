using System.Collections.Generic;
using UnityEngine;

namespace Agava.Wallet
{
    public abstract class WalletPresenter<TWallet, TWalletType> : MonoBehaviour where TWallet : IWallet<TWalletType>, new()
    {
        [SerializeField] private List<MonoBehaviour> _walletViews;
        [SerializeField] private string _id;

        public IWallet<TWalletType> Model { get; private set; }
        protected abstract TWalletType StartValue { get; }

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
            var walletSave = new WalletSave<TWallet, TWalletType>(_id);
            Model = new ViewedWallet<TWalletType>(new SavedWallet<TWallet, TWalletType>(walletSave), CastWalletView());
            
            if (walletSave.HasSave == false)
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