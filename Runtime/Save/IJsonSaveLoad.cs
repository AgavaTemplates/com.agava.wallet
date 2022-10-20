namespace Agava.WalletTemplate
{
    internal interface IJsonSaveLoad
    {
        bool HasSave(string id);
        
        string Load(string id);
        void Save(string id, string json);
    }
}