using Agava.Wallet.Model;
using UnityEngine;

namespace Agava.Wallet.Presenter
{ 
    [AddComponentMenu("")]
    public sealed class IntWalletPresenter : WalletPresenter<IntWallet, int>
    {
        [SerializeField, Min(0)] private int _startValue;

        protected override int StartValue => _startValue;
    }
}