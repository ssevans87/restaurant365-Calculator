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
        public void testSeperateNumbers5()
        {
            //Setup
            string arg1 = "k\n1";
            //string [] delim = {}
            List<string> arg2 = new List<string>();
            
            string[] expected = { "k", "1" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers6()
        {
            //Setup
            string arg1 = "k\n1,h";
            //string [] delim = {}
            List<string> arg2 = new List<string>();

            string[] expected = { "k", "1", "h" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers7()
        {
            //Setup
            string arg1 = "k\n1;h";
            string[] delim = { ";" };
            List<string> arg2 = new List<string>();
            arg2.AddRange(delim);
            string[] expected = { "k", "1", "h" };
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
            Assert.ThrowsException<ArgumentException>(() => calc.GetValidArray(arg1));
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

        [TestMethod]
        public void testGetValidArray4()
        {
            //Setup
            string[] arg1 = { "-1" };
            List<string> arg2 = new List<string>();
            long[] expected = {  };
            long[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.GetValidArray(arg1));
        }

        [TestMethod]
        public void testExtractDelims1()
        {
            //Setup
            string arg1 = "//[;]";
            List<string> expected = new List<string>() ;
            expected.Add(";");
            List<string> actual;
            Calculator calc = new Calculator();

            //Assert
            actual = calc.ExtractDelims(arg1);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testExtractDelims2()
        {
            //Setup
            string arg1 = "//[***]";
            List<string> expected = new List<string>();
            expected.Add("***");
            List<string> actual;
            Calculator calc = new Calculator();

            //Assert
            actual = calc.ExtractDelims(arg1);
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void testExtractDelims6()
        {
            //Setup
            string arg1 = "//[;][?]";
            List<string> expected = new List<string>();
            expected.Add(";");
            List<string> actual;
            Calculator calc = new Calculator();

            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.ExtractDelims(arg1));
        }

        //check for number over 1000
        [TestMethod]
        public void OverThou()
        {
            //Setup
            string arg1 = "1001";
            string arg2 = "1";
            string arg3 = "2";
            string expected = "3";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1 + ',' + arg2 + ',' + arg3);
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
            string expected = "0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.Calculate(arg1));
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
            string expected = "0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.Calculate(arg1 + ',' + arg2));
        }

        //testing with two opposite sign numbers
        [TestMethod]
        public void TwoOpp()
        {
            //Setup
            string arg1 = "1";
            string arg2 = "-2";
            string expected = "1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.Calculate(arg1 + ',' + arg2));
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

        //testing with more than custom single deliminator
        [TestMethod]
        public void CustomArgs()
        {
            //Setup
            string arg1 = "//;\n2;5";
            string expected = "7";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1);
            Assert.AreEqual(expected, actual);
        }




    }
}
