using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests {
    [TestClass]
    public class ReverseIntegerTests
    {
        [TestMethod]
        public void ReversePositiveNumberTest() {
            // arrange
            int inputNumber = 123;
            int expectedReversedNumber = 321;
            
            // act
            ReverseInteger reverseInteger = new ReverseInteger();
            int actualReversedNumber = reverseInteger.Reverse(inputNumber);

            // assert
            Assert.AreEqual(expectedReversedNumber, actualReversedNumber);
        }

        [TestMethod]
        public void ReverseNegativeNumberTest() {
            // arrange
            int inputNumber = -123;
            int expectedReversedNumber = -321;
            
            // act
            ReverseInteger reverseInteger = new ReverseInteger();
            int actualReversedNumber = reverseInteger.Reverse(inputNumber);

            // assert
            Assert.AreEqual(expectedReversedNumber, actualReversedNumber);
        }

        [TestMethod]
        public void ReversePositiveEndingWithZeroNumberTest() {
            // arrange
            int inputNumber = 120;
            int expectedReversedNumber = 21;
            
            // act
            ReverseInteger reverseInteger = new ReverseInteger();
            int actualReversedNumber = reverseInteger.Reverse(inputNumber);

            // assert
            Assert.AreEqual(expectedReversedNumber, actualReversedNumber);
        }

        [TestMethod]
        public void OverflowPositiveLargeNumberTest() {
            // arrange
            int inputNumber = 1234567899;// this reversed will be 9,987,654,321 which is beyond the Int32
            int expectedReversedNumber = 0;
            
            // act
            ReverseInteger reverseInteger = new ReverseInteger();
            int actualReversedNumber = reverseInteger.Reverse(inputNumber);

            // assert
            Assert.AreEqual(expectedReversedNumber, actualReversedNumber);
        }

        [TestMethod]
        public void OverflowNegativeLargeNumberTest() {
            // arrange
            int inputNumber = -1234567899;// this reversed will be 9,987,654,321 which is beyond the Int32
            int expectedReversedNumber = 0;
            
            // act
            ReverseInteger reverseInteger = new ReverseInteger();
            int actualReversedNumber = reverseInteger.Reverse(inputNumber);

            // assert
            Assert.AreEqual(expectedReversedNumber, actualReversedNumber);
        }
    }
}