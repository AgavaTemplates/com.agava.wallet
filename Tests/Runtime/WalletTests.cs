using System;
using System.Numerics;
using Agava.Wallet.Model;
using NUnit.Framework;

namespace Agava.Wallet.Tests
{
    public class WalletTests
    {
        [Test]
        public void IntWallet_Add()
        {
            var wallet = new IntWallet();
            int addValue = 100;
            
            wallet.Add(addValue);

            Assert.AreEqual(addValue, wallet.Value);
        }
        
        [Test]
        public void IntWallet_AddOverMaxValueShouldThrowOverflowException()
        {
            var wallet = new IntWallet();
            wallet.Add(100);

            Assert.Throws<OverflowException>(() => wallet.Add(Int32.MaxValue));
        }
        
        [Test]
        public void IntWallet_AddLessZeroShouldThrowArgumentOutOfRangeException()
        {
            var wallet = new IntWallet();
            Assert.Throws<ArgumentOutOfRangeException>(() => wallet.Add(-1));
        }
        
        [Test]
        public void IntWallet_Spend()
        {
            var wallet = new IntWallet();
            int spendValue = 100;
            
            wallet.Add(spendValue);
            wallet.Spend(spendValue);

            Assert.AreEqual(0, wallet.Value);
        }
        
        [Test]
        public void BigIntegerWallet_Add()
        {
            var wallet = new BigIntegerWallet();
            int addValue = 100;
            
            wallet.Add(addValue);

            Assert.AreEqual((BigInteger)addValue, wallet.Value);
        }

        [Test]
        public void BigIntegerWallet_AddLessZeroShouldThrowArgumentOutOfRangeException()
        {
            var wallet = new BigIntegerWallet();
            Assert.Throws<ArgumentOutOfRangeException>(() => wallet.Add(-1));
        }
        
        [Test]
        public void BigIntegerWallet_Spend()
        {
            var wallet = new BigIntegerWallet();
            int spendValue = 100;
            
            wallet.Add(spendValue);
            wallet.Spend(spendValue);

            Assert.AreEqual(BigInteger.Zero, wallet.Value);
        }
    }
}
