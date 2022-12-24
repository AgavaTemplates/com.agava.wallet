#if UNITY_EDITOR
using System;
using System.IO;
using Agava.Wallet.Presenter;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Agava.Wallet.WalletFactoryAPI
{
    public sealed class WalletFactory
    {
        private readonly WalletList _walletList = new();
        
        public string PathToWalletPrefabWith(string walletId) 
            => _walletList.PathToWalletWith(walletId);

        public bool CanCreateWalletPrefabWith(string walletId) 
            => walletId.Trim() != "" && _walletList.HasWalletWith(walletId) == false;

        public void CreateWalletPrefab(WalletType walletType, string walletId)
        {
            if (CanCreateWalletPrefabWith(walletId) == false)
                throw new InvalidOperationException($"Id already taken or empty: '{walletId}'");
            
            string pathToFile = EditorUtility.SaveFilePanelInProject("Save wallet", $"{walletType.ToString()}Wallet", "prefab", "");

            if (pathToFile.Trim() != "")
            {
                var walletInstance = InstanceWallet(walletType, walletId);
                walletInstance.name = Path.GetFileNameWithoutExtension(pathToFile);

                PrefabUtility.SaveAsPrefabAsset(walletInstance, pathToFile);
                Object.DestroyImmediate(walletInstance);
                
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(pathToFile));
            }
        }

        private GameObject InstanceWallet(WalletType walletType, string walletId)
        {
            var walletInstance = new GameObject();

            if (walletType == WalletType.Int)
                walletInstance.AddComponent<IntWalletPresenter>().Initialize(walletId);
            else if (walletType == WalletType.BigInteger) 
                walletInstance.AddComponent<BigIntegerWalletPresenter>().Initialize(walletId);

            return walletInstance;
        }
    }
}
#endif
