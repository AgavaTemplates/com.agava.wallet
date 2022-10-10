using System.Numerics;
using UnityEngine;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private string _debug;

        private void Start()
        {
            var walletSave = new WalletSave<string>("123", new PlayerPrefsJsonSaveLoad());
            var wallet = new Wallet<string>();

            if (walletSave.HasSave)
                wallet = (Wallet<string>)walletSave.Load();

            wallet.Add("1.1f");
            _debug = $"{wallet.Value}";
            
            walletSave.Save(wallet);
        }
    }
}
