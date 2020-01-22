using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class BinaryNumberAlternatingBitsTests
    {
        [TestMethod]
        public void PositiveOneBit()
        {
            // arrange
            // 1 is 1 binary and hence is a solution
            int input = 1;
            bool expectedResult = true;

            // act
            BinaryNumberAlternatingBits alternatingBinaryNumbers = new BinaryNumberAlternatingBits();
            bool result = alternatingBinaryNumbers.HasAlternatingBits(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void NegativeOneBit()
        {
            // arrange
            // 0 is 0 binary (not a solution)
            int input = 0;
            bool expectedResult = false;

            // act
            BinaryNumberAlternatingBits alternatingBits = new BinaryNumberAlternatingBits();
            bool result = alternatingBits.HasAlternatingBits(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void PositiveTwoBitsNumber()
        {
            // arrange
            // 2 is 10 binary and hence is a solution
            int input = 2;
            bool expectedResult = true;

            // act
            BinaryNumberAlternatingBits alternatingBinaryNumbers = new BinaryNumberAlternatingBits();
            bool result = alternatingBinaryNumbers.HasAlternatingBits(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void NegativeTwoBitsNumber()
        {
            // arrange
            // 3 is 11 binary and hence is NOT a solution
            int input = 3;
            bool expectedResult = false;

            // act
            BinaryNumberAlternatingBits alternatingBinaryNumbers = new BinaryNumberAlternatingBits();
            bool result = alternatingBinaryNumbers.HasAlternatingBits(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void PositiveThreeBitsNumber()
        {
            // arrange
            // 5 is 101 binary and hence is a solution
            int input = 5;
            bool expectedResult = true;

            // act
            BinaryNumberAlternatingBits alternatingBinaryNumbers = new BinaryNumberAlternatingBits();
            bool result = alternatingBinaryNumbers.HasAlternatingBits(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void NegativeThreeBitsNumber()
        {
            // arrange
            // 7 is 111 binary and hence is NOT a solution
            int input = 7;
            bool expectedResult = false;

            // act
            BinaryNumberAlternatingBits alternatingBinaryNumbers = new BinaryNumberAlternatingBits();
            bool result = alternatingBinaryNumbers.HasAlternatingBits(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
