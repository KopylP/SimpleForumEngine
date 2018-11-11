using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleForumEngine.web.Models;
using System.Text;
using System.Linq;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod6()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod7()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod8()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod9()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
        [TestMethod]
        public void TestMethod10()
        {
            string testing_password = "12345678";
            var salt = Hasher.GenarateSalt();
            var password = Hasher.SHA256(Hasher.ToByte(testing_password).ToArray(), salt);
            var passwordAndSaltStr = Hasher.getPasswordString(password, salt);
            Assert.AreEqual(Hasher.CompareStrings(testing_password, passwordAndSaltStr), true);
        }
    }
}
