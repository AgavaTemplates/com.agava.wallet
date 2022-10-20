using UnityEngine;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private IntWalletPresenter _intWallet;
        [SerializeField] private BigIntegerWalletPresenter _bigIntegerWallet;

        [ContextMenu("Add")]
        private void Add()
        {
            _intWallet.Model.Add(1);
            _bigIntegerWallet.Model.Add(1);
        }

        [ContextMenu("Subtract")]
        private void Subtract()
        {
            _intWallet.Model.Subtract(1);
            _bigIntegerWallet.Model.Subtract(1);
        }
    }
}
