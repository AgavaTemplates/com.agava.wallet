using UnityEngine;

namespace Agava.Wallet.Save
{
    public sealed class PlayerPrefsJsonSaveLoad : IJsonSaveLoad
    {
        public bool HasSave(string id) => PlayerPrefs.HasKey(id);
        public string Load(string id) => PlayerPrefs.GetString(id);
        public void Save(string id, string json) => PlayerPrefs.SetString(id, json);
    }
}