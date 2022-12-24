using Agava.Wallet.WalletFactoryAPI;
using UnityEditor;
using UnityEngine;

namespace Agava.Wallet.Editor
{
    internal class WalletFactoryWindow : EditorWindow
    {
        private readonly WalletFactory _walletFactory = new();
        private readonly WalletFactoryWindowStyles _windowStyles = new();
        private string _walletId = "";
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
            
            if (_walletId.Trim() != "" && _walletFactory.CanCreateWalletPrefabWith(_walletId) == false)
            {
                EditorGUILayout.HelpBox($"This id ('{_walletId}') already taken\nPath: {_walletFactory.PathToWalletPrefabWith(_walletId)}", MessageType.Warning);
                EditorGUILayout.Separator();
            }
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Wallet type", _windowStyles.LabelTextStyle());
            _walletType = (WalletType)EditorGUILayout.EnumPopup(_walletType);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(6);

            if (GUILayout.Button("Create wallet prefab", _windowStyles.DefaultButtonStyle()))
            {
                if (_walletFactory.CanCreateWalletPrefabWith(_walletId))
                {
                    _walletFactory.CreateWalletPrefab(_walletType, _walletId);
                    _walletId = "";

                    GUIUtility.keyboardControl = 0;
                }
            }

            EditorGUILayout.EndVertical();
        }
    }
}
