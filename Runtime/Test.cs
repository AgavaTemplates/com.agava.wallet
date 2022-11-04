using UnityEngine;

namespace Agava.Wallet
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private BigIntegerWalletPresenter _bigIntegerWallet;

        [ContextMenu("Add")]
        private void Add()
        {
            _bigIntegerWallet.Model.Add(999999999);
        }

        [ContextMenu("Spend")]
        private void Spend()
        {
            _bigIntegerWallet.Model.Spend(1);
        }
    }
}
