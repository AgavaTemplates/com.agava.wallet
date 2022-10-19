using System.Diagnostics;
using Agava.WalletTemplate.MathOperations;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Agava.WalletTemplate
{
    public class Test : MonoBehaviour
    {
        private WalletSave<int> _walletSave;
        private IWallet<int> _wallet;
        
        private void Start()
        {
            _walletSave = new WalletSave<int>("123", new PlayerPrefsJsonSaveLoad());
            _wallet = _walletSave.Load();
        }

        [ContextMenu("Add")]
        private void Add()
        {
            _wallet.Add(1);
            Debug.Log(_wallet.Value);
        }

        [ContextMenu("Subtract")]
        private void Subtract()
        {
            _wallet.Remove(1);
            Debug.Log(_wallet.Value);
        }

        [ContextMenu("Save")]
        private void Save()
        {
            _walletSave.Save(_wallet);
        }
        
        [ContextMenu("Time")]
        private void StartTime()
        {
            var watch = new Stopwatch();
            int sum1 = 0;

            int n = Random.Range(99999, 100002);
            
            watch.Start();
            for (int i = 0; i < n; i++)
                sum1 = i + i;
            watch.Stop();
            
            Debug.Log($"Default operation: {watch.Elapsed.TotalMilliseconds} milliseconds; n: {n}, {sum1}");

            int sum2 = 0;
            watch.Reset();
            
            var expression = new CachedExpressionLambda<int>(new AddExpressionLambda<int>());

            watch.Start();
            for (int i = 0; i < n; i++)
                sum2 = expression.Compile()(i, i);
            watch.Stop();

            Debug.Log($"Expression operation: {watch.Elapsed.TotalMilliseconds} milliseconds; n: {n}, {sum2}");
        }
    }
}
