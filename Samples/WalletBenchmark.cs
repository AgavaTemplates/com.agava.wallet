using System.Diagnostics;
using Agava.Wallet.Presenter;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Agava.Wallet.Samples
{
    public class WalletBenchmark : MonoBehaviour
    {
        [SerializeField] private IntWalletPresenter _intWallet;
        [SerializeField] private BigIntegerWalletPresenter _bigIntegerWallet;

        [ContextMenu("StartTestForIntWallet")]
        private void StartTestForIntWallet()
        {
            int operations = Random.Range(99990, 100000);
            var addWalletStopwatch = new Stopwatch();
            
            addWalletStopwatch.Start();

            for (int i = 0; i < operations; i++)
                _intWallet.Model.Add(1);
            
            addWalletStopwatch.Stop();
            
            var spendWalletStopwatch = new Stopwatch();
            
            spendWalletStopwatch.Start();

            for (int i = 0; i < operations; i++)
                if (_intWallet.Model.CanSpend(1))
                    _intWallet.Model.Spend(1);
            
            spendWalletStopwatch.Stop();
            
            Debug.Log($"Add operations ({operations}): {addWalletStopwatch.Elapsed.Milliseconds}ms\n" +
                      $"Spend operations ({operations}): {spendWalletStopwatch.Elapsed.Milliseconds}ms");
        }
        
        [ContextMenu("StartTestForBigIntegerWallet")]
        private void StartTestForBigIntegerWallet()
        {
            int operations = Random.Range(99990, 100000);
            var addWalletStopwatch = new Stopwatch();
            
            addWalletStopwatch.Start();

            for (int i = 0; i < operations; i++)
                _bigIntegerWallet.Model.Add(1);
            
            addWalletStopwatch.Stop();
            
            var spendWalletStopwatch = new Stopwatch();
            
            spendWalletStopwatch.Start();

            for (int i = 0; i < operations; i++)
                if (_bigIntegerWallet.Model.CanSpend(1))
                    _bigIntegerWallet.Model.Spend(1);
            
            spendWalletStopwatch.Stop();
            
            Debug.Log($"Add operations ({operations}): {addWalletStopwatch.Elapsed.Milliseconds}ms\n" +
                      $"Spend operations ({operations}): {spendWalletStopwatch.Elapsed.Milliseconds}ms");
        }
    }
}