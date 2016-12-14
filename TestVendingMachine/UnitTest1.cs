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
            var preCount = testMachine.coinCount(Coins.NICKELS);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(5);
            Assert.AreEqual(preCount, testMachine.coinCount(Coins.NICKELS) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited - 5);
        }

        [TestMethod]
        public void TestInsertDime()
        {
            var preCount = testMachine.coinCount(Coins.DIMES);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(10);
            Assert.AreEqual(preCount, testMachine.coinCount(Coins.DIMES) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited - 10);
        }

        [TestMethod]
        public void TestInsertQuarter()
        {
            var preCount = testMachine.coinCount(Coins.QUARTERS);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(25);
            Assert.AreEqual(preCount, testMachine.coinCount(Coins.QUARTERS) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited - 25);
        }

        [TestMethod]
        public void TestInsertPenny()
        {
            var preCount = testMachine.coinReturnCount(Coins.INVALID);
            var preAmount = testMachine.AmountDeposited;
            testMachine.InsertCoin(1);
            Assert.AreEqual(preCount, testMachine.coinReturnCount(Coins.INVALID) - 1);
            Assert.AreEqual(preAmount, testMachine.AmountDeposited);
        }


    }
}
