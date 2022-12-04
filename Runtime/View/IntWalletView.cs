using TMPro;
using UnityEngine;

namespace Agava.Wallet.View
{
    public class IntWalletView : MonoBehaviour, IWalletView<int>
    {
        [SerializeField] private TMP_Text _text;

        public void Render(int currentValue)
        {
            _text.text = currentValue.ToString();
        }
    }
}