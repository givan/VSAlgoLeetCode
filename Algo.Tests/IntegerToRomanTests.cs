using Algo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests {
    [TestClass]
    public class IntegerToRomanTests 
    {
        [DataTestMethod]
        [DataRow(3, "III")]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(58, "LVIII")]
        [DataRow(1994, "MCMXCIV")]
        public void ConvertToRomanNumberTestV1(int number, string expectedRoman) {
            // arrange
            // act
            IntegerToRoman itor = new IntegerToRoman();
            string roman = itor.IntToRoman(number);

            // assert
            Assert.AreEqual(expectedRoman, roman);
        }

        [DataTestMethod]
        [DataRow(3, "III")]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(58, "LVIII")]
        [DataRow(1994, "MCMXCIV")]
        public void ConvertToRomanNumberTestV2(int number, string expectedRoman) {
            // arrange
            // act
            IntegerToRoman itor = new IntegerToRoman();
            string roman = itor.IntToRomanV2(number);

            // assert
            Assert.AreEqual(expectedRoman, roman);
        }

        [DataTestMethod]
        [DataRow(3, "III")]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(58, "LVIII")]
        [DataRow(1994, "MCMXCIV")]
        public void ConvertToRomanNumberTestV3(int number, string expectedRoman) {
            // arrange
            // act
            IntegerToRoman itor = new IntegerToRoman();
            string roman = itor.IntToRomanV3(number);

            // assert
            Assert.AreEqual(expectedRoman, roman);
        }
    }
}