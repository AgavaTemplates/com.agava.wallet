using System.Collections.Generic;
using Agava.Wallet.Attributes;
using Agava.Wallet.Model;
using Agava.Wallet.Save;
using Agava.Wallet.View;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Agava.Wallet.Presenter
{
    public abstract class WalletPresenter<TWallet, TWalletType> : MonoBehaviour where TWallet : IWallet<TWalletType>, new()
    {
        [SerializeField, ReadOnly] private string _id;
        [SerializeField] private List<MonoBehaviour> _walletViews = new();

        public IWallet<TWalletType> Model { get; private set; }
        internal string Id => _id;
        protected abstract TWalletType StartValue { get; }

#if UNITY_EDITOR
        internal void Initialize(string id)
        {
            _id = id;
            EditorUtility.SetDirty(gameObject);
        }
#endif

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