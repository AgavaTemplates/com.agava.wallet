using System.Numerics;
using TMPro;
using UnityEngine;

namespace Agava.Wallet.View
{
    public class BigIntegerWalletView : MonoBehaviour, IWalletView<BigInteger>
    {
        [SerializeField] private TMP_Text _text;

        public void Render(BigInteger currentValue)
        {
            _text.text = currentValue.ToString();
        }
    }
}