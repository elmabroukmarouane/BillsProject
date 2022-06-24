using BillProject.Models;
using BillProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BillTestProject
{
    [TestClass]
    public class BillsTest
    {
        [TestMethod]
        public void TestBillsNull()
        {
            var _billService = new BillService();
            Assert.AreEqual(null, _billService.GetBill(null));
        }

        [TestMethod]
        public void TestBillsBasketItemIsNull()
        {
            var _billService = new BillService();
            var basket = new Basket()
            {
                BasketItems = null
            };
            Assert.AreEqual(null, _billService.GetBill(basket));
        }

        [TestMethod]
        public void TestBillsEquals0()
        {
            var _billService = new BillService();
            var basket = new Basket()
            {
                BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Item = new Item()
                        {
                            Name = "P1",
                            Price = 10
                        },
                        Quantity = 0
                    }
                }
            };
            Assert.AreEqual(0, _billService.GetBill(basket));
        }

        [TestMethod]
        public void TestBillsEquals210()
        {
            var _billService = new BillService();
            var basket = new Basket()
            {
                BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Item = new Item()
                        {
                            Name = "P1",
                            Price = 10
                        },
                        Quantity = 5
                    },
                    new BasketItem()
                    {
                        Item = new Item()
                        {
                            Name = "P1",
                            Price = 20
                        },
                        Quantity = 2
                    },
                    new BasketItem()
                    {
                        Item = new Item()
                        {
                            Name = "P1",
                            Price = 30
                        },
                        Quantity = 4
                    }
                }
            };
            Assert.AreEqual(210, _billService.GetBill(basket));
        }
    }
}
