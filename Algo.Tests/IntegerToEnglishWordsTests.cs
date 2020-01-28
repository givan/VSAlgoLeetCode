using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class IntegerToEnglishWordsTests
    {
        [DataRow(123, "One Hundred Twenty Three")]
        [DataRow(1123, "One Thousand One Hundred Twenty Three")]
        [DataRow(51123, "Fifty One Thousand One Hundred Twenty Three")]
        [DataRow(99999, "Ninety Nine Thousand Nine Hundred Ninety Nine")]
        [DataRow(100000, "One Hundred Thousand")]
        [DataRow(999999, "Nine Hundred Ninety Nine Thousand Nine Hundred Ninety Nine")]
        [DataRow(1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
        [DataRow(1234567891, "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One")]
        [DataRow(1000000005, "One Billion Five")]
        [DataRow(1000000015, "One Billion Fifteen")]
        [DataRow(1000000053, "One Billion Fifty Three")]
        [DataRow(1000000000, "One Billion")]
        [DataRow(12345, "Twelve Thousand Three Hundred Forty Five")]
        [DataTestMethod]
        public void TestEnglishNumbers(int num, string expectedNumber)
        {
            // arrange
            // act
            string actualNumber = IntegerToEnglishWords.NumberToWords(num);

            // assert
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void MustBeNonNegative()
        {
            // arrange
            int num = -1;

            // act
            // assert
            Assert.ThrowsException<ArgumentException>(() => IntegerToEnglishWords.NumberToWords(num));
        }
    }
}