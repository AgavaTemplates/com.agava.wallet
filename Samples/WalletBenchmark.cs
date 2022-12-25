using System.Diagnostics;
using Agava.Wallet.Presenter;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Agava.Wallet.Samples
{
    public class WalletBenchmark : MonoBehaviour
    {
        [SerializeField] private IntWalletPresenter _wallet;
        [SerializeField] private int _operations = 999999;

        [ContextMenu("StartTest")]
        private void StartTest()
        {
            var addWalletStopwatch = new Stopwatch();
            
            addWalletStopwatch.Start();

            for (int i = 0; i < _operations; i++)
                _wallet.Model.Add(1);
            
            addWalletStopwatch.Stop();
            
            var spendWalletStopwatch = new Stopwatch();
            
            spendWalletStopwatch.Start();

            for (int i = 0; i < _operations; i++)
                if (_wallet.Model.CanSpend(1))
                    _wallet.Model.Spend(1);
            
            spendWalletStopwatch.Stop();
            
            Debug.Log($"Add operations ({_operations}): {addWalletStopwatch.Elapsed.Milliseconds}ms\n" +
                      $"Spend operations ({_operations}): {spendWalletStopwatch.Elapsed.Milliseconds}ms");
        }
    }
}