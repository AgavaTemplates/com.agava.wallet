using System;

namespace Agava.WalletTemplate
{
    public interface IWallet<T> where T : IComparable, IComparable<T>
    {
        T Value { get; }

        void Add(T amount);
        void Remove(T amount);
    }
}