using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class ZigZagTests
    {
        [TestMethod]
        public void ZigZagRowSize3()
        {
            // arrange
            string input = "PAYPALISHIRING";
            int numRows = 3;
            string expectedOutput = "PAHNAPLSIIGYIR";

            // act
            ZigZag zigZagEncoder = new ZigZag();
            string output = zigZagEncoder.Convert(input, numRows);

            // assert
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void ZigZagRowSize4()
        {
            // arrange
            string input = "PAYPALISHIRING";
            int numRows = 4;
            string expectedString = "PINALSIGYAHRPI";

            // act
            ZigZag zigZagEncoder = new ZigZag();
            string output = zigZagEncoder.Convert(input, numRows);

            // assert
            Assert.AreEqual(expectedString, output);
        }
    }
}