using UnityEngine;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        [ContextMenu("Start")]
        private void Start()
        {
            var walletSave = new WalletSave<int>("123", new PlayerPrefsJsonSaveLoad());
            var wallet = (Wallet<int>)walletSave.Load();

            wallet.Add(1);
            walletSave.Save(wallet);

            Debug.Log(wallet.Value);
        }
    }
}
