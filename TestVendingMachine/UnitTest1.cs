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
            testMachine.InsertCoin(Coins.NICKELS);
            Assert.AreEqual(testMachine.coinCount(Coins.NICKELS) - 1, preAmount);
        }


    }
}
