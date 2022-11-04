using Agava.Wallet.Utils;
using System.Numerics;
using UnityEngine;

namespace Agava.Wallet
{
    public sealed class BigIntegerWalletPresenter : WalletPresenter<BigIntegerWallet, BigInteger>
    {
        [SerializeField, BigIntegerString] private string _startValue = "0";

        protected override BigInteger StartValue => BigInteger.Parse(_startValue);
    }
}