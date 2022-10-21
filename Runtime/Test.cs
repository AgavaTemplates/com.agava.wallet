using UnityEngine;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private BigIntegerWalletPresenter _bigIntegerWallet;

        [ContextMenu("Add")]
        private void Add()
        {
            _bigIntegerWallet.Model.Add(9999999);
        }

        [ContextMenu("Subtract")]
        private void Subtract()
        {
            _bigIntegerWallet.Model.Subtract(1);
        }
    }
}
