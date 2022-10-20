using System.Numerics;
using UnityEngine;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        private IWallet<BigInteger> _wallet;

        private void Start()
        {
            _wallet = new SavedWallet<BigIntegerWallet, BigInteger>(new WalletSave<BigIntegerWallet, BigInteger>("123"));
        }

        [ContextMenu("Add")]
        private void Add()
        {
            _wallet.Add(1);
            Debug.Log(_wallet.Value);
        }

        [ContextMenu("Subtract")]
        private void Subtract()
        {
            _wallet.Subtract(1);
            Debug.Log(_wallet.Value);
        }
    }
}
