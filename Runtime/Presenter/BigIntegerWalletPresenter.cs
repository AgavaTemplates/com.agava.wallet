﻿using Agava.Wallet.Utils;
using System.Numerics;
using Agava.Wallet.Model;
using UnityEngine;

namespace Agava.Wallet.Presenter
{
    public sealed class BigIntegerWalletPresenter : WalletPresenter<BigIntegerWallet, BigInteger>
    {
        [SerializeField, BigIntegerString] private string _startValue = "0";

        protected override BigInteger StartValue => BigInteger.Parse(_startValue);
    }
}