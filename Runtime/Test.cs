using System.Numerics;
using UnityEngine;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        private IWallet<int> _wallet;
        
        private void Start()
        {
            _wallet = new SavedWallet<int>(new WalletSave<int>("123"));
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
            _wallet.Remove(1);
            Debug.Log(_wallet.Value);
        }
    }
}
