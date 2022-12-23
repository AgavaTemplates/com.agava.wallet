using System.IO;
using Agava.Wallet.Presenter;
using UnityEditor;
using UnityEngine;

namespace Agava.Wallet.Editor
{
    internal class WalletFactoryWindow : EditorWindow
    {
        private readonly WalletFactoryWindowStyles _windowStyles = new();
        private string _walletId;
        private WalletType _walletType;
        
        [MenuItem("Window/Wallet Factory")]
        private static void Initialize()
        {
            var walletFactoryWindow = GetWindow<WalletFactoryWindow>("Wallet factory");
            walletFactoryWindow.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(6);
            EditorGUILayout.LabelField("Wallet factory", _windowStyles.TitleTextStyle());
            EditorGUILayout.Separator();

            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Wallet id (use as save key)", _windowStyles.LabelTextStyle());
            _walletId = EditorGUILayout.TextField("", _walletId);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Wallet type", _windowStyles.LabelTextStyle());
            _walletType = (WalletType)EditorGUILayout.EnumPopup(_walletType);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(6);
            
            if (GUILayout.Button("Create wallet prefab", _windowStyles.DefaultButtonStyle()))
            {
                string pathToFolder = EditorUtility.OpenFolderPanel("Open the folder where to save the wallet prefab", Application.dataPath, "Assets");

                if (pathToFolder.Trim() != "")
                {
                    var walletInstance = CreateWalletPrefab();

                    string path = AssetDatabase.GenerateUniqueAssetPath($"{pathToFolder}{Path.DirectorySeparatorChar}{walletInstance.name}.prefab");
                    PrefabUtility.SaveAsPrefabAsset(walletInstance, path);
                    
                    DestroyImmediate(walletInstance);
                }
            }

            EditorGUILayout.EndVertical();
        }

        private GameObject CreateWalletPrefab()
        {
            var walletInstance = new GameObject();

            if (_walletType == WalletType.Int)
            {
                walletInstance.name = "IntWallet";
                walletInstance.AddComponent<IntWalletPresenter>();
            }
            else
            {
                walletInstance.name = "BigIntegerWallet";
                walletInstance.AddComponent<BigIntegerWalletPresenter>();
            }

            return walletInstance;
        }
    }
}
