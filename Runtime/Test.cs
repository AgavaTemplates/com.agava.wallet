using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Text _walletText;
        
        private IWallet<BigInteger> _wallet;

        private void Start()
        {
            _wallet = new ViewedWallet<BigInteger>(
                new SavedWallet<BigIntegerWallet, BigInteger>(
                    new WalletSave<BigIntegerWallet, BigInteger>(id: "123")
                    ), new WalletView<BigInteger>(_walletText));
            
            _wallet.Add(0);
        }

        [ContextMenu("Add")]
        private void Add()
        {
            _wallet.Add(1);
        }

        [ContextMenu("Subtract")]
        private void Subtract()
        {
            _wallet.Subtract(1);
        }
    }
}
