using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator365;

namespace Calculator365Test
{
    [TestClass]
    public class CalculatorTest
    {
        
        [TestMethod]
        public void testSeperateNumbers1()
        {
            //Setup
            string arg1 = "1";
            List<string> arg2 = new List<string>();
            string[] expected = {"1"};
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers2()
        {
            //Setup
            string arg1 = "1,2";
            List<string> arg2 = new List<string>();
            string[] expected = { "1","2" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers3()
        {
            //Setup
            string arg1 = "1,k";
            List<string> arg2 = new List<string>();
            string[] expected = { "1", "k"};
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers4()
        {
            //Setup
            string arg1 = "k,1";
            List<string> arg2 = new List<string>();
            string[] expected = {"k","1" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testGetValidArray1()
        {
            //Setup
            string[] arg1 = { "1" };
            List<string> arg2 = new List<string>();
            long[] expected = {1 };
            long[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            actual = calc.GetValidArray(arg1);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testGetValidArray2()
        {
            //Setup
            string[] arg1 = { "1", "-2" };
            List<string> arg2 = new List<string>();
            long[] expected = { 1,-2 };
            long[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            actual = calc.GetValidArray(arg1);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testGetValidArray3()
        {
            //Setup
            string[] arg1 = { "1", "k" };
            List<string> arg2 = new List<string>();
            long[] expected = { 1};
            long[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            actual = calc.GetValidArray(arg1);
            CollectionAssert.AreEqual(expected, actual);
        }

        //check for overflow
        [TestMethod]
        public void OverFlow()
        {
            //Setup
            string arg1 = "9223372036854775807";
            string arg2 = "1";
            string expected = "Overflow";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2);
            Assert.AreEqual(expected, actual);
        }

        //testing with no input
        [TestMethod]
        public void NoArg()
        {
            //Setup
            string arg1 = "";
            string expected = "0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1);
            Assert.AreEqual(expected, actual);
        }

        //testing with one positive number
        [TestMethod]
        public void OnePos()
        {
            //Setup
            string arg1 = "1";
            string expected = "1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1);
            Assert.AreEqual(expected, actual);
        }

        //testing with one negative number
        [TestMethod]
        public void OneNeg()
        {
            //Setup
            string arg1 = "-1";
            string expected = "-1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1);
            Assert.AreEqual(expected, actual);
        }

        //testing with one invalid char
        [TestMethod]
        public void OneInv()
        {
            //Setup
            string arg1 = "z";
            string expected = "0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1);
            Assert.AreEqual(expected, actual);
        }

        //testing with one invalid string
        [TestMethod]
        public void OneInv2()
        {
            //Setup
            string arg1 = "zzz";
            string expected = "0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1);
            Assert.AreEqual(expected, actual);
        }

        //testing with two positive numbers
        [TestMethod]
        public void TwoPos()
        {
            //Setup
            string arg1 = "1";
            string arg2 = "2";
            string expected = "3";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2);
            Assert.AreEqual(expected, actual);
        }

        //testing with two negative numbers
        [TestMethod]
        public void TwoNeg()
        {
            //Setup
            string arg1 = "-1";
            string arg2 = "-2";
            string expected = "-3";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2);
            Assert.AreEqual(expected, actual);
        }

        //testing with two opposite sign numbers
        [TestMethod]
        public void TwoOpp()
        {
            //Setup
            string arg1 = "1";
            string arg2 = "-2";
            string expected = "-1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2);
            Assert.AreEqual(expected, actual);
        }

        //testing with one valid one invalid
        [TestMethod]
        public void MixedVal()
        {
            //Setup
            string arg1 = "1";
            string arg2 = "p";
            string expected = "1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2);
            Assert.AreEqual(expected, actual);
        }

        //testing with one valid one invalid
        [TestMethod]
        public void MixedVal2()
        {
            //Setup
            string arg1 = "p";
            string arg2 = "1";
            string expected = "1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2);
            Assert.AreEqual(expected, actual);
        }

        //testing with more than 2 values
        [TestMethod]
        public void ThreeArgs()
        {
            //Setup
            string arg1 = "1";
            string arg2 = "2";
            string arg3 = "3";
            string expected = "6";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2 + ',' + arg3);
            Assert.AreEqual(expected, actual);
        }




    }
}
