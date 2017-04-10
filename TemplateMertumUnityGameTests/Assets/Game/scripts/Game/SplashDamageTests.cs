using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Game.scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.scripts.Game.Tests
{
    [TestClass()]
    public class SplashDamageTests : MonoBehaviour
    {
        [TestMethod()]
        public void DealSplashDamageTest()
        {
            hp enemy = GameObject.FindWithTag("enemy").GetComponent<hp>();
            var dmg = 10;
            var currrent = enemy.CurrentHP - dmg;
            GameObject projectile = GameObject.FindWithTag("projectile");
            projectile.GetComponent<SplashDamage>().DealSplashDamage();

            Assert.AreSame(currrent, enemy.CurrentHP);
        }
    }
}