using UnityEngine.UI;

namespace Agava.WalletTemplate
{
    public class WalletView<T> : IWalletView<T>
    {
        private readonly Text _text;
        
        public WalletView(Text text)
        {
            _text = text;
        }

        public void Render(T currentValue)
        {
            _text.text = currentValue.ToString();
        }
    }
}