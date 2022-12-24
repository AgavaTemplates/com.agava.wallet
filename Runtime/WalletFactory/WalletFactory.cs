using System.IO;
using Agava.Wallet.Presenter;
using UnityEditor;
using UnityEngine;

namespace Agava.Wallet.WalletFactoryAPI
{
    public class WalletFactory
    {
        public void CreateWalletPrefab(WalletType walletType, string walletId)
        {
            string pathToFolder = EditorUtility.OpenFolderPanel("Open the folder where to save the wallet prefab", Application.dataPath, "Assets");

            if (pathToFolder.Trim() != "")
            {
                var walletInstance = InstanceWallet(walletType, walletId);

                string path = AssetDatabase.GenerateUniqueAssetPath($"{pathToFolder}{Path.DirectorySeparatorChar}{walletInstance.name}.prefab");
                PrefabUtility.SaveAsPrefabAsset(walletInstance, path);
                
                Object.DestroyImmediate(walletInstance);
            }
        }
        
        private GameObject InstanceWallet(WalletType walletType, string walletId)
        {
            var walletInstance = new GameObject();

            if (walletType == WalletType.Int)
            {
                walletInstance.name = "IntWallet";
                walletInstance.AddComponent<IntWalletPresenter>()
                    .Initialize(walletId);
            }
            else
            {
                walletInstance.name = "BigIntegerWallet";
                walletInstance.AddComponent<BigIntegerWalletPresenter>()
                    .Initialize(walletId);
            }

            return walletInstance;
        }
    }
}
