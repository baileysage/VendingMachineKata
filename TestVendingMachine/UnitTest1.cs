using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;

namespace TestVendingMachine
{
    [TestClass]
    public class TestVendingMachine
    {
        VendingMachine testMachine;

        [TestInitialize]
        public void SetupVendingMachine()
        {
            testMachine = new VendingMachine();
        }

        [TestMethod]
        public void TestInsertNickel()
        {
            var preCount = testMachine.CoinCount(Coins.NICKEL);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(5);
            Assert.AreEqual(preCount, testMachine.CoinCount(Coins.NICKEL) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited - 5);
        }

        [TestMethod]
        public void TestInsertDime()
        {
            var preCount = testMachine.CoinCount(Coins.DIME);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(10);
            Assert.AreEqual(preCount, testMachine.CoinCount(Coins.DIME) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited - 10);
        }

        [TestMethod]
        public void TestInsertQuarter()
        {
            var preCount = testMachine.CoinCount(Coins.QUARTER);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(25);
            Assert.AreEqual(preCount, testMachine.CoinCount(Coins.QUARTER) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited - 25);
        }

        [TestMethod]
        public void TestInsertPenny()
        {
            var preCount = testMachine.CoinReturnCount(Coins.INVALID);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(1);
            Assert.AreEqual(preCount, testMachine.CoinReturnCount(Coins.INVALID) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited);
        }

        [TestMethod]
        public void TestReturnCoins()
        {
            testMachine.InsertCoin(5);
            testMachine.InsertCoin(10);
            testMachine.InsertCoin(25);
            testMachine.ReturnCoins();
            Assert.AreEqual(1, testMachine.CoinReturnCount(Coins.NICKEL));
            Assert.AreEqual(1, testMachine.CoinReturnCount(Coins.DIME));
            Assert.AreEqual(1, testMachine.CoinReturnCount(Coins.QUARTER));
        }

    }
}
