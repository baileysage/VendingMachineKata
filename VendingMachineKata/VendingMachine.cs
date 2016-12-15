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
        CANDY,
        UNSET
    }

    public class VendingMachine
    {
        public const string INSERT_COIN = "INSERT COIN";
        public const string THANK_YOU = "THANK YOU";
        public const string SOLD_OUT = "SOLD OUT";
        public const string PRICE = "PRICE";
        public const string EXACT_CHANGE_ONLY = "EXACT CHANGE ONLY";

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

        public Products SelectedProduct { get; set; }

        public VendingMachine()
        {
            displayString = INSERT_COIN;
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
                    amountDeposited += 0.05F;
                    break;
                case 10:
                    coinsDeposited[(int)Coins.DIME]++;
                    amountDeposited += 0.10F;
                    break;
                case 25:
                    coinsDeposited[(int)Coins.QUARTER]++;
                    amountDeposited += 0.25F;
                    break;
                default:
                    coinReturn[(int)Coins.INVALID]++;
                    break;
            }
            SelectedProduct = Products.UNSET;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (SelectedProduct != Products.UNSET)
            {
                if (productsAvailable[(int)SelectedProduct] == 0)
                {
                    displayString = SOLD_OUT;
                    SelectedProduct = Products.UNSET;
                }
                else
                {
                    switch (SelectedProduct)
                    {
                        case Products.POP:
                            if (amountDeposited >= POP_PRICE)
                            {
                                Vend(Products.POP);
                                displayString = THANK_YOU;
                            }
                            else
                            {
                                displayString = PRICE + " $" + POP_PRICE.ToString("#0.00");
                            }
                            break;
                        case Products.CHIPS:
                            if (amountDeposited >= CHIP_PRICE)
                            {
                                Vend(Products.CHIPS);
                                displayString = THANK_YOU;
                            }
                            else
                            {
                                displayString = PRICE + " $" + CHIP_PRICE.ToString("#0.00");
                            }
                            break;
                        case Products.CANDY:
                            if (amountDeposited >= POP_PRICE)
                            {
                                Vend(Products.CANDY);
                                displayString = THANK_YOU;
                            }
                            else
                            {
                                displayString = PRICE + " $" + CANDY_PRICE.ToString("#0.00");
                            }
                            break;
                    }

                }
                SelectedProduct = Products.UNSET;
            }
            else
            {
                if (amountDeposited > 0)
                {
                    displayString = "$" + amountDeposited.ToString("#0.00");
                }
                else
                {
                    if (coinsAvailable[(int)Coins.NICKEL] == 0)
                    {
                        displayString = EXACT_CHANGE_ONLY;
                    }
                    else
                    {
                        displayString = INSERT_COIN;
                    }
                }
            }
        }

        private void Vend(Products product)
        {
            if (productsAvailable[(int)product] == 0)
                throw new Exception();
            productsAvailable[(int)product]--;
            amountDeposited = 0;
            //TODO: make change and write some freaking tests for all o' this. 
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
            SelectedProduct = Products.UNSET;
        }

        public void SelectProduct(Products product)
        {
            SelectedProduct = product;
            UpdateDisplay();
        }
    }
}
