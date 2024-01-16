﻿using exercise.main.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class BasketTest
    {
    
        private Basket _basket;
        [SetUp]
        public void SetUp()
        {
            _basket = new Basket();
        }

        [Test]
        public void Add()
        {
            bool resultTrue = _basket.Add("BGLO");
            bool resultFalse = _basket.Add("wrong");
            _basket.Add("BGLP");
            _basket.Add("BGLP");
            _basket.Add("BGLP");
            bool resultOverLimit = _basket.Add("BGLO");

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsFalse(resultOverLimit);
            Assert.IsTrue(_basket.basket.Any(item => item.SKU == "BGLO"));
        }
        [Test]
        public void Remove()
        {
            _basket.Add("BGLO");
            bool resultTrue = _basket.Remove("BGLO");
            bool resultFalse = _basket.Remove("wrong");

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsFalse(_basket.basket.Any(item => item.SKU == "BGLO"));
        }
        [Test]
        public void EditSize()
        {
            
            Manager manager = new Manager();
            Assert.IsTrue(manager.AlterSize(_basket,4));
            
            
        }
        [Test]
        public void Calculate()
        {
            _basket.Add("BGLO");
            _basket.Add("COFB");

            Assert.AreEqual(_basket.Sum(), 0.49d + 0.99d);
        }
        [Test]
        public void addFilling()
        {
            Product testFilling1 = new Product("FILB", 0.12d,Product.pType.Filling, "Bacon");
            Product testFilling2 = new Product("COFB", 0.12d,Product.pType.Coffee, "Black");
            _basket.Add("BGLO");
            var test = _basket.basket.FirstOrDefault(item => item.SKU == "BGLO");
            Assert.IsTrue(test.AddFilling(testFilling1));
            Assert.IsFalse(test.AddFilling(testFilling2));
            Assert.IsTrue(test.Filling.Any(t => t.SKU == "FILB"));
        }
    }
}
