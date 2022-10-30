using UnityEngine;
using UnityEngine.UI;

namespace Agava.Wallet
{
    public class IntWalletView : MonoBehaviour, IWalletView<int>
    {
        [SerializeField] private Text _text;

        public void Render(int currentValue)
        {
            _text.text = currentValue.ToString();
        }
    }
}