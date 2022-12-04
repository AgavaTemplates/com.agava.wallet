using Agava.Wallet.Presenter;
using UnityEngine;

namespace Agava.Wallet.Samples
{
    public class DefaultUseCase : MonoBehaviour
    {
        [SerializeField] private BigIntegerWalletPresenter _bigIntegerWallet;

        [ContextMenu("Add")]
        private void Add()
        {
            _bigIntegerWallet.Model.Add(10);
        }

        [ContextMenu("Spend")]
        private void Spend()
        {
            if (_bigIntegerWallet.Model.CanSpend(10))
                _bigIntegerWallet.Model.Spend(10);
        }
    }
}
