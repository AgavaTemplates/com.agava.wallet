using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

namespace Agava.Wallet
{
    public class BigIntegerWalletView : MonoBehaviour, IWalletView<BigInteger>
    {
        [SerializeField] private Text _text;

        public void Render(BigInteger currentValue)
        {
            _text.text = currentValue.ToString();
        }
    }
}