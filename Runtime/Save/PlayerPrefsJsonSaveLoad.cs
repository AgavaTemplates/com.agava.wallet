using UnityEngine;

namespace Agava.Wallet
{
    public class PlayerPrefsJsonSaveLoad : IJsonSaveLoad
    {
        public bool HasSave(string id) => PlayerPrefs.HasKey(id);
        public string Load(string id) => PlayerPrefs.GetString(id);
        public void Save(string id, string json) => PlayerPrefs.SetString(id, json);
    }
}