using UnityEngine;

namespace Agava.Wallet
{ 
    public sealed class IntWalletPresenter : WalletPresenter<IntWallet, int>
    {
        [SerializeField, Min(0)] private int _startValue;

        protected override int StartValue => _startValue;
    }
}