using Microsoft.VisualStudio.TestTools.UnitTesting;
using deve_web.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deve_web.Logic.Tests
{
    using Acces;
    using Logic;
    [TestClass()]
    public class SingUpLogicTests
    {
        [TestMethod()]
        public void InsertUserTest()
        {
            crud cr = new crud();
            bool isSingUp=cr.SingUpUser("prueba","prueba","prueba", "2017-06-01","prueba","prueba@prueba.com","1");
            bool expectative = false;
            Assert.AreEqual(expectative,isSingUp);
        }
        [TestMethod()]
        public void IsUserTest()
        {
            crud cr = new crud();
            String username = cr.IsUser("prueba", "cAByAHUAZQBiAGEAMQAyADMANAA=");
            String expectative ="prueba";
            Assert.AreEqual(expectative, username);
        }
        [TestMethod()]
        public void IsNotUserTest()
        {
            crud cr = new crud();
            String username = cr.IsUser("sprueba", "no");
            String expectative = null;
            Assert.AreEqual(expectative, username);
        }
        [TestMethod()]
        public void InsertHashtagTest()
        {
            crud cr = new crud();
            bool inserted= cr.inserthashtag(null, "no");
            bool expectative = false;
            Assert.AreEqual(expectative, inserted);
        }

        [TestMethod()]
        public void InsertRankPositiveTest()
        {
            crud cr = new crud();
            bool inserted = cr.inserRank("prueba", "2018’-‘11’-‘02’T’18’:’58’:’42.1701850-06:00prueba", "1");
            bool expectative = true;
            Assert.AreEqual(expectative, inserted);
        }

        [TestMethod()]
        public void InsertRankNegativeTest()
        {
            crud cr = new crud();
            bool inserted = cr.inserRank("prueba", "2018’-‘11’-‘02’T’18’:’58’:’42.1701850-06:00prueba", "-1");
            bool expectative = true;
            Assert.AreEqual(expectative, inserted);
        }


        /*LOGIC LAYER*/
        [TestMethod()]
        public void IsUserLogicTest()
        {
            LogInLogic  lg = new LogInLogic();
            bool username = lg.IsUser("prueba", "cAByAHUAZQBiAGEAMQAyADMANAA=");
            bool expectative = false;
            Assert.AreEqual(expectative, username);
        }
        [TestMethod()]
        public void IsNotUserLogicTest()
        {
            LogInLogic lg = new LogInLogic();
            bool username = lg.IsUser("pruebsa", "cAByAdsaHUAZQBiAGEAMQAyADMANAA=");
            bool expectative = false;
            Assert.AreEqual(expectative, username);
        }
        [TestMethod()]
        public void SecurytyEncodeTest()
        {
            String username = SecurityLogic.Encriptar("Password");
            String expectative = "sadfasfjkaslasljNASn1k=";
            Assert.AreNotEqual(expectative, username);
        }
        [TestMethod()]
        public void SecurytyDesEncodeTest()
        {
            String username = SecurityLogic.DesEncriptar(SecurityLogic.Encriptar( "password"));
            String expectative = "password";
            Assert.AreEqual(expectative, username);
        }
        
        /*SERVICES TEST*/

        [TestMethod()]
        public void SensitiveLogicTest()
        {
            ServiceLogic lg = new ServiceLogic();
            bool username = lg.IsSensitiHashtags("jaja puta mierda");
            bool expectative = true;
            Assert.AreEqual(expectative, username);
        }
        [TestMethod()]
        public void NotSensitiveLogicTest()
        {
            ServiceLogic lg = new ServiceLogic();
            bool username = lg.IsSensitiHashtags("hola y adios");
            bool expectative = false;
            Assert.AreEqual(expectative, username);
        }


    }
}