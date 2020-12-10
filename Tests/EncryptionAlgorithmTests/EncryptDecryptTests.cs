using CourseProject1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace EncryptionAlgorithmTests
{
    [TestClass]
    public class EncryptDecryptTests
    {
        string allSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞßàáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿ 0123456789.,!?#$%^&*()_+-={}[]`";
        string allRusLetters = "àáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿ";
        static Random rnd = new Random();
        [TestMethod]
        public void RandomStringEncryptDecryptTests()
        {
            string key = GenRandomString(allRusLetters, 10);
            string expected = GenRandomString(allSymbols, 1000);

            string encrypted = EncryptionAlgorithm.GetEncryptedString(expected, key);
            string actual = EncryptionAlgorithm.GetDecryptedString(encrypted, key);

            Assert.AreEqual(expected, actual);
        }
        public static string GenRandomString(string Alphabet, int Length)
        {
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }
            return sb.ToString();
        }
    }
}
