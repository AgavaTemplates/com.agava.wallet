using UnityEngine;

namespace Agava.Wallet
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private IntWalletPresenter _bigIntegerWallet;

        [ContextMenu("Add")]
        private void Add()
        {
            _bigIntegerWallet.Model.Add(999999999);
        }

        [ContextMenu("Subtract")]
        private void Subtract()
        {
            _bigIntegerWallet.Model.TrySpend(1);
        }
    }
}
