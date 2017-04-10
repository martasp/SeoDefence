using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    [TestClass()]
    public class HealthBarTests : MonoBehaviour
    {
        [TestMethod()]
        public void DamageTest()
        {
            GameObject Slider = GameObject.Find("Slider");
            var hpCom = Slider.GetComponent<HealthBar>();
            hpCom.currentHP = 100;
            hpCom.maxHP = 100;
            hpCom.Damage();
            Assert.AreSame(99, hpCom.currentHP);
        }
    }
}