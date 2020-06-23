using Moq;
using System;
using System.Collections.Generic;
using Xunit;



namespace Wallet
{
    public class UnitTest1
    {
        
        [Fact]
        public void TestAddMoney()
        {
            var mockBank = new Mock<Bank>();
            var wallet = new Wallet(mockBank.Object);
            string title = "USD";
            int price = 500;
            wallet.addMoney(title, price);
            double expection = 500;
            foreach (var acc in wallet.account)
            {
                if(acc.Key==title)
                    Assert.Equal(expection, acc.Value);
            }
        }
        [Fact]
        public void Test2AddMoney()
        {
            var mockBank = new Mock<Bank>();
            var wallet = new Wallet(mockBank.Object);
            wallet.addMoney("USD", 200);
            string title = "USD";
            int price = 500;
            wallet.addMoney(title, price);
            double expection = 700;
            foreach (var acc in wallet.account)
            {
                if (acc.Key == title)
                    Assert.Equal(expection, acc.Value);
            }
        }

        [Fact]
        public void TestRemoveMoney()
        {            
            var mockBank = new Mock<Bank>();
            var wallet = new Wallet(mockBank.Object);
            wallet.addMoney("RUB", 200);
            string title = "RUB";
            int price = 100;
            wallet.removeMoney(title, price);
            double expection = 100;
            
            foreach (var account in wallet.account)
            {
                if (account.Key == title)
                {
                    Assert.Equal(expection, account.Value);                    
                }
            }
        }


        
        [Fact]
        
        public void TestGetMoney()
        {
            var mockBank = new Mock<Bank>();
            var wallet = new Wallet(mockBank.Object);
            wallet.addMoney("RUB", 200);
            wallet.addMoney("USD", 500);
            wallet.addMoney("EUR", 50);
            string title = "EUR";
            wallet.getMoney(title);
            foreach (var account in wallet.account)
            {
                if (account.Key == title)
                {
                    Assert.Equal(50.0, account.Value);                    
                }
            }
            
        }
        
        [Fact]        
        public void TestCount—urrencies()
        {
            var mockBank = new Mock<Bank>();
            var wallet = new Wallet(mockBank.Object);
            wallet.addMoney("RUB", 200);
            wallet.addMoney("USD", 500);
            wallet.addMoney("EUR", 50);
           
            int temp = wallet.count—urrencies();
            
            Assert.Equal(3, temp);
        }


        
        [Fact]
        public void TestPrice()
        {
            var mockBank = new Mock<Bank>();
            var wallet = new Wallet(mockBank.Object);
            wallet.addMoney("RUB", 200);
            wallet.addMoney("USD", 500);
            string temp = wallet.price();
            string text = "{ 200 RUB; 500 USD }";
            
            Assert.Equal(text, temp);
        }


        
        [Fact]        
        public void TestGetTotalMoney()
        {
            var mock = new Mock<Bank>();
            var wallet = new Wallet(mock.Object);            
            wallet.addMoney("RUB", 500);            
            double temp = wallet.getTotalMoney("USD");            
            Assert.Equal(5.0, temp);
        }
        
        
    }
}
