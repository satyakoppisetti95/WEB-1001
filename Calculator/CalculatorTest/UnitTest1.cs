using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calculator = new Calculator();

        //=======ADDITION TESTS =========================

        [TestMethod]
        public void TestAddingTwoPositiveNumbers()
        {
            double first = 1.0;
            double second = 2.0;
            string operator_code = "a";
            double expected = first + second;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestAddingTwoNegativeNumbers()
        {
            double first = -5.0;
            double second = -3.0;
            string operator_code = "a";
            double expected = first + second;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);

        }


        //one of the properties in addition is if you add 0 to a number the result should be equal to the number itself
        [TestMethod]
        public void TestAddingNumberToZeroAndCheckResultIsNumberItself()
        {
            double first = 25.0;
            double second = 0;
            string operator_code = "a";
            double expected = first;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }


        //=======SUBTRACTION TESTS =========================

        [TestMethod]
        public void TestSubtractingTwoPositiveNumbers()
        {
            double first = 25.0;
            double second = 35.0;
            string operator_code = "s";
            double expected = first - second;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubtractingTwoNegativeNumbers()
        {
            double first = -45.0;
            double second = -55.0;
            string operator_code = "s";
            double expected = first - second;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);

        }


        //one of the properties in subtraction is if you subtract a number from itself it should result in 0
        [TestMethod]
        public void TestSubtractingNumberByItself()
        {
            double first = 45.0;
            double second = first;
            string operator_code = "s";

            //expected should be 0
            double expected = 0;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);

        }



        //=======MULTIPLICATION TESTS =========================

        [TestMethod]
        public void TestMultiplyingTwoPositiveNumbers()
        {
            double first = 25.0;
            double second = 35.0;
            string operator_code = "m";
            double expected = first * second;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiplyingOnePositiveOneNegativeNumbers()
        {
            double first = 15.0;
            double second = -25.0;
            string operator_code = "m";
            double expected = first * second;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }

        //one of the property of multiplication is if you multiply number by 1 it should result in the same number
        [TestMethod]
        public void TestMultiplyingANumberByOneAndCheckIfResultIsSameNumber()
        {
            double first = 23.0;
            double second = 1;
            string operator_code = "m";

            //expected should be the first number itself
            double expected = first;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }


        //=======DIVISION TESTS =========================


        [TestMethod]
        public void TestDividingTwoNumbers()
        {
            double first = 24.0;
            double second = -12.0;
            string operator_code = "d";

            double expected = first/second;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDividingANumberByZero()
        {
            double first = 24.0;
            double second = 0;
            string operator_code = "d";

            double expected = double.NaN;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }

        //one of the property of division is if you divide number by 1 you get back the same number
        [TestMethod]
        public void TestDividingANumberByOne()
        {
            double first = 24.0;
            double second = 1;
            string operator_code = "d";

            //expected should be the first number itself
            double expected = first;

            double actual = calculator.performCalculation(first, second, operator_code);

            Assert.AreEqual(expected, actual);
        }
    }
}
