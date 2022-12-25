using Agava.Wallet.Model;
using Newtonsoft.Json;

namespace Agava.Wallet.Save
{
    internal sealed class WalletInventory<TWallet, TWalletType> where TWallet : IWallet<TWalletType>, new()
    {
        private readonly string _id;
        private readonly IJsonSaveLoad _saveLoad;
        private TWallet _wallet;

        internal WalletInventory(string id) : this (id, new PlayerPrefsJsonSaveLoad()) { }

        internal WalletInventory(string id, IJsonSaveLoad saveLoad)
        {
            _id = id;
            _saveLoad = saveLoad;
        }

        internal bool HasSave => _saveLoad.HasSave(_id);

        internal TWallet Load()
        {
            if (_wallet != null)
                return _wallet;

            _wallet = new TWallet();

            if (_saveLoad.HasSave(_id))
            {
                var jsonString = _saveLoad.Load(_id);
                _wallet = JsonConvert.DeserializeObject<TWallet>(jsonString);
            }

            return _wallet;
        }

        internal void Save(TWallet wallet)
        {
            var jsonString = JsonConvert.SerializeObject(wallet);
            _saveLoad.Save(_id, jsonString);
        }
    }
}
