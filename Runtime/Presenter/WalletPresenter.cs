using UnityEngine;
using UnityEngine.UI;

namespace Agava.WalletTemplate
{
    public abstract class WalletPresenter<TWallet, TWalletType> : MonoBehaviour where TWallet : IWallet<TWalletType>, new()
    {
        [SerializeField] private string _id;
        [SerializeField] private Text _walletText;

        public IWallet<TWalletType> Model { get; private set; }

        private void Awake()
        {
            Model = new ViewedWallet<TWalletType>(
                new SavedWallet<TWallet, TWalletType>(
                    new WalletSave<TWallet, TWalletType>(_id)
                ), new WalletView<TWalletType>(_walletText));
        }
    }
}