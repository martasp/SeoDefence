using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    [TestClass()]
    public class MoneyScriptTests : MonoBehaviour
    {
        [TestMethod()]
        public void AddTest()
        {
            GameObject Money = GameObject.Find("Money");
            var mon = Money.GetComponent<MoneyScript>();
            mon.money = 0;
            mon.Add(100);
            Assert.AreSame(100, mon.money);
        }

        [TestMethod()]
        public void SubTest()
        {
            GameObject Money = GameObject.Find("Money");
            var mon = Money.GetComponent<MoneyScript>();
            mon.money = 99;
            mon.Sub(50);
            Assert.AreSame(1, mon.money);
        }
    }
}