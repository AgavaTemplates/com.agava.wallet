#if UNITY_EDITOR
using UnityEditor;

namespace Agava.Wallet.Presenter
{
    public abstract partial class WalletPresenter<TWallet, TWalletType>
    {
        internal string Id => _id;
        
        internal void Initialize(string id)
        {
            _id = id;
            EditorUtility.SetDirty(gameObject);
        }
    }
}
#endif