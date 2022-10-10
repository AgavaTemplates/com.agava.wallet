using System;

namespace Agava.WalletTemplate
{
    public interface IWallet<T> where T : IComparable
    {
        T Value { get; }

        void Add(T amount);
        void Remove(T amount);
    }
}