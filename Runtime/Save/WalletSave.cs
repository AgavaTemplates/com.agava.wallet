using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Agava.WalletTemplate
{
    public class WalletSave<T> where T : IComparable
    {
        private static readonly Dictionary<string, IWallet<T>> Hash = new();

        private readonly string _id;
        private readonly IJsonSaveLoad _saveLoad;

        public WalletSave(string id, IJsonSaveLoad saveLoad)
        {
            _id = id;
            _saveLoad = saveLoad;
        }

        public bool HasSave => _saveLoad.HasSave(SaveKey);
        private string SaveKey => $"{typeof(T)}-{_id}";

        public IWallet<T> Load()
        {
            if (HasSave == false)
                throw new InvalidOperationException("Wallet with this id was not saved");
            
            if (Hash.ContainsKey(_id))
                return Hash[_id];

            var jsonString = _saveLoad.Load(SaveKey);
            var wallet = JsonConvert.DeserializeObject<Wallet<T>>(jsonString);

            Hash.Add(_id, wallet);

            return wallet;
        }

        public void Save(IWallet<T> wallet)
        {
            var jsonString = JsonConvert.SerializeObject(wallet);
            _saveLoad.Save(SaveKey, jsonString);
        }
    }
}
