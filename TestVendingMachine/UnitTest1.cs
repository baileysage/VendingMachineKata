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
            var preAmount = testMachine.coinCount(Coins.NICKELS);
            testMachine.InsertCoin(5);
            Assert.AreEqual(testMachine.coinCount(Coins.NICKELS) - 1, preAmount);
        }

        [TestMethod]
        public void TestInsertDime()
        {
            var preAmount = testMachine.coinCount(Coins.DIMES);
            testMachine.InsertCoin(10);
            Assert.AreEqual(testMachine.coinCount(Coins.DIMES) - 1, preAmount);
        }

        [TestMethod]
        public void TestInsertQuarter()
        {
            var preAmount = testMachine.coinCount(Coins.QUARTERS);
            testMachine.InsertCoin(25);
            Assert.AreEqual(preAmount, testMachine.coinCount(Coins.QUARTERS) - 1);
        }

        [TestMethod]
        public void TestInsertPenny()
        {
            var preAmount = testMachine.coinReturnCount(Coins.INVALID);
            testMachine.InsertCoin(1);
            Assert.AreEqual(preAmount, testMachine.coinReturnCount(Coins.INVALID) - 1);
        }


    }
}
