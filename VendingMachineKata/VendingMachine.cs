using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public enum Coins
    {
        NICKEL,
        DIME,
        QUARTER,
        INVALID
    }
    public enum Products
    {
        POP,
        CHIPS,
        CANDY
    }

    public class VendingMachine
    {
        public const string INSERT_COIN = "INSERT COIN";
        public const string THANK_YOU = "THANK YOU";
        public const string SOLD_OUT = "SOLD OUT";
        public const string PRICE = "PRICE";

        public const float POP_PRICE = 1.00F;
        public const float CHIP_PRICE = 0.50F;
        public const float CANDY_PRICE = 0.65F;

        private int[] productsAvailable = { 10, 10, 10 };
        private int[] coinsAvailable = { 10, 10, 10 };
        private int[] coinsDeposited = { 0, 0, 0 };
        private int[] coinReturn = { 0, 0, 0, 0 };
        private float amountDeposited = 0;
        private string displayString;

        public float AmountDeposited
        {
            get { return amountDeposited; }
        }

        public string DisplayString
        {
            get { return displayString; }
        }

        public VendingMachine()
        {
            displayString = "INSERT COIN";
        }

        public int CoinCount(Coins coinType)
        {
            return coinsDeposited[(int)coinType];
        }

        public void InsertCoin(int coinValue)
        {
            switch (coinValue)
            {
                case 5:
                    coinsDeposited[(int)Coins.NICKEL]++;
                    amountDeposited += 5;
                    break;
                case 10:
                    coinsDeposited[(int)Coins.DIME]++;
                    amountDeposited += 10;
                    break;
                case 25:
                    coinsDeposited[(int)Coins.QUARTER]++;
                    amountDeposited += 25;
                    break;
                default:
                    coinReturn[(int)Coins.INVALID]++;
                    break;
            }
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (amountDeposited > 0)
            {
                displayString = "$" + amountDeposited.ToString();
            }
            else
            {
                displayString = "INSERT COIN";
            }
        }

        public int CoinReturnCount(Coins coinType)
        {
            return coinReturn[(int)coinType];
        }

        public void ReturnCoins()
        {
            coinReturn[(int)Coins.NICKEL] += coinsDeposited[(int)Coins.NICKEL];
            coinReturn[(int)Coins.DIME] += coinsDeposited[(int)Coins.DIME];
            coinReturn[(int)Coins.QUARTER] += coinsDeposited[(int)Coins.QUARTER];
        }
    }
}
