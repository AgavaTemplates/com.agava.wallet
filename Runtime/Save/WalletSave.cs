using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Agava.WalletTemplate
{
    public class WalletSave<T> where T : IComparable, IComparable<T>
    {
        private static readonly Dictionary<string, IWallet<T>> Hash = new();

        private readonly string _id;
        private readonly IJsonSaveLoad _saveLoad;

        public WalletSave(string id, IJsonSaveLoad saveLoad)
        {
            _id = id;
            _saveLoad = saveLoad;
        }

        public IWallet<T> Load()
        {
            if (Hash.ContainsKey(_id))
                return Hash[_id];

            var wallet = new Wallet<T>();

            if (_saveLoad.HasSave(_id))
            {
                var jsonString = _saveLoad.Load(_id);
                wallet = JsonConvert.DeserializeObject<Wallet<T>>(jsonString);
            }

            Hash.Add(_id, wallet);

            return wallet;
        }

        public void Save(IWallet<T> wallet)
        {
            var jsonString = JsonConvert.SerializeObject(wallet);
            _saveLoad.Save(_id, jsonString);
        }
    }
}
