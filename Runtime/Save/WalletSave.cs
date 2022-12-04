using System.Collections.Generic;
using Agava.Wallet.Model;
using Newtonsoft.Json;

namespace Agava.Wallet.Save
{
    public class WalletSave<TWallet, TWalletType> where TWallet : IWallet<TWalletType>, new()
    {
        private static readonly Dictionary<string, TWallet> Hash = new();

        private readonly string _id;
        private readonly IJsonSaveLoad _saveLoad;

        public WalletSave(string id) : this (id, new PlayerPrefsJsonSaveLoad()) { }

        public WalletSave(string id, IJsonSaveLoad saveLoad)
        {
            _id = id;
            _saveLoad = saveLoad;
        }

        public bool HasSave => _saveLoad.HasSave(_id);

        public TWallet Load()
        {
            if (Hash.ContainsKey(_id))
                return Hash[_id];

            var wallet = new TWallet();

            if (_saveLoad.HasSave(_id))
            {
                var jsonString = _saveLoad.Load(_id);
                wallet = JsonConvert.DeserializeObject<TWallet>(jsonString);
            }

            Hash.Add(_id, wallet);

            return wallet;
        }

        public void Save(TWallet wallet)
        {
            var jsonString = JsonConvert.SerializeObject(wallet);
            _saveLoad.Save(_id, jsonString);
        }
    }
}
