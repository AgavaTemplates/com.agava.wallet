using System.Diagnostics;
using System.Numerics;
using Agava.WalletTemplate.MathOperations;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Agava.WalletTemplate
{
    public class Benchmark : MonoBehaviour
    {
        [ContextMenu("StartTest")]
        private void StartTest()
        {
            int n = Random.Range(99990, 100000);
            
            DefaultOperationInt(n);
            ExpressionOperationInt(n);
            DefaultOperationBigInteger(n);
            ExpressionOperationBigInteger(n);
        }

        private void DefaultOperationInt(int n)
        {
            var watch = new Stopwatch();
            int sum = 0;
            
            watch.Start();
            
            for (int i = 0; i < n; i++)
                sum = i + i;
            
            watch.Stop();
            
            Debug.Log($"Default operation int: {watch.Elapsed.TotalMilliseconds} milliseconds; n: {n}, {sum}");
        }
        
        private void ExpressionOperationInt(int n)
        {
            var watch = new Stopwatch();
            int sum = 0;
            
            var expression = new CachedExpressionLambda<int>(new AddExpressionLambda<int>());

            watch.Start();
            
            for (int i = 0; i < n; i++)
                sum = expression.Compile()(i, i);
            
            watch.Stop();

            Debug.Log($"Expression operation int: {watch.Elapsed.TotalMilliseconds} milliseconds; n: {n}, {sum}");
        }
        
        private void DefaultOperationBigInteger(int n)
        {
            var watch = new Stopwatch();
            BigInteger sum = 0;
            
            watch.Start();
            
            for (int i = 0; i < n; i++)
                sum = i + i;
            
            watch.Stop();
            
            Debug.Log($"Default operation BigInteger: {watch.Elapsed.TotalMilliseconds} milliseconds; n: {n}, {sum}");
        }

        private void ExpressionOperationBigInteger(int n)
        {
            var watch = new Stopwatch();
            BigInteger sum = 0;
            
            var expression = new CachedExpressionLambda<BigInteger>(new AddExpressionLambda<BigInteger>());

            watch.Start();
            
            for (int i = 0; i < n; i++)
                sum = expression.Compile()(i, i);
            
            watch.Stop();

            Debug.Log($"Expression operation BigInteger: {watch.Elapsed.TotalMilliseconds} milliseconds; n: {n}, {sum}");
        }
    }
}