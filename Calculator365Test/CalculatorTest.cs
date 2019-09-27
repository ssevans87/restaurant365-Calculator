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
            char arg3 = '\n';
            string[] expected = {"1"};
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers2()
        {
            //Setup
            string arg1 = "1,2";
            List<string> arg2 = new List<string>();
            char arg3 = '\n';
            string[] expected = { "1","2" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers3()
        {
            //Setup
            string arg1 = "1,k";
            List<string> arg2 = new List<string>();
            char arg3 = '\n';
            string[] expected = { "1", "k"};
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers4()
        {
            //Setup
            string arg1 = "k,1";
            List<string> arg2 = new List<string>();
            char arg3 = '\n';
            string[] expected = {"k","1" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers5()
        {
            //Setup
            string arg1 = "k\n1";
            //string [] delim = {}
            List<string> arg2 = new List<string>();
            char arg3 = '\n';

            string[] expected = { "k", "1" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers6()
        {
            //Setup
            string arg1 = "k\n1,h";
            //string [] delim = {}
            List<string> arg2 = new List<string>();
            char arg3 = '\n';

            string[] expected = { "k", "1", "h" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers7()
        {
            //Setup
            string arg1 = "k\n1;h";
            string[] delim = { ";" };
            List<string> arg2 = new List<string>();
            char arg3 = '\n';
            arg2.AddRange(delim);
            string[] expected = { "k", "1", "h" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers8()
        {
            //Setup
            string arg1 = "k:1";
            //string [] delim = {}
            List<string> arg2 = new List<string>();
            char arg3 = ':';

            string[] expected = { "k", "1" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers9()
        {
            //Setup
            string arg1 = "k:1,h";
            //string [] delim = {}
            List<string> arg2 = new List<string>();
            char arg3 = ':';

            string[] expected = { "k", "1", "h" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testSeperateNumbers10()
        {
            //Setup
            string arg1 = "k:1;h";
            string[] delim = { ";" };
            List<string> arg2 = new List<string>();
            char arg3 = ':';
            arg2.AddRange(delim);
            string[] expected = { "k", "1", "h" };
            string[] actual;
            Calculator calc = new Calculator();

            //SeperateNumbers(string toSeperate, List<string> newDelimiters)
            //Assert
            actual = calc.SeperateNumbers(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testGetValidArray1()
        {
            //Setup
            string[] arg1 = { "1" };
            bool arg2 = false;
            long arg3 = 1000;
            string[] expected = {"1" };
            string[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            actual = calc.GetValidArray(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testGetValidArray2()
        {
            //Setup
            string[] arg1 = { "1", "-2" };
            bool arg2 = false;
            long arg3 = 1000;
            string[] expected = { "1","-2" };

            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.GetValidArray(arg1,arg2,arg3));
        }

        [TestMethod]
        public void testGetValidArray3()
        {
            //Setup
            string[] arg1 = { "1", "k" };
            bool arg2 = false;
            long arg3 = 1000;
            string[] expected = { "1", "0"};
            string[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            actual = calc.GetValidArray(arg1,arg2,arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testGetValidArray4()
        {
            //Setup
            string[] arg1 = { "-1" };
            bool arg2 = false;
            long arg3 = 1000;
            string[] expected = {  };
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.GetValidArray(arg1,arg2,arg3));
        }

        [TestMethod]
        public void testGetValidArray5()
        {
            //Setup
            string[] arg1 = { "1","51" };
            bool arg2 = false;
            long arg3 = 50;
            string[] expected = { "1","0" };
            string[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            actual = calc.GetValidArray(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testGetValidArray6()
        {
            //Setup
            string[] arg1 = { "1", "-2" };
            bool arg2 = true;
            long arg3 = 1000;
            string[] expected = { "1", "-2" };
            string[] actual;
            Calculator calc = new Calculator();

            //GetValidArray(string[] toCheck)
            //Assert
            actual = calc.GetValidArray(arg1, arg2, arg3);
            CollectionAssert.AreEqual(expected, actual);
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



        //check for number over 1000
        [TestMethod]
        public void OverThou()
        {
            //Setup
            string arg1 = "1001,1,2";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "0+1+2 = 3";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1,arg2,arg3,arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with no input
        [TestMethod]
        public void NoArg()
        {
            //Setup
            string arg1 = "";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "0 = 0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with one positive number
        [TestMethod]
        public void OnePos()
        {
            //Setup
            string arg1 = "1";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "1 = 1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with one negative number
        [TestMethod]
        public void OneNeg()
        {
            //Setup
            string arg1 = "-1";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;


            Calculator calc = new Calculator();


            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.Calculate(arg1, arg2, arg3, arg4));
        }

        //testing with one invalid char
        [TestMethod]
        public void OneInv()
        {
            //Setup
            string arg1 = "z";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "0 = 0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with one invalid string
        [TestMethod]
        public void OneInv2()
        {
            //Setup
            string arg1 = "zzz";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "0 = 0";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with two positive numbers
        [TestMethod]
        public void TwoPos()
        {
            //Setup
            string arg1 = "1,2";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "1+2 = 3";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with two negative numbers
        [TestMethod]
        public void TwoNeg()
        {
            //Setup
            string arg1 = "-1,-2";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;


            Calculator calc = new Calculator();


            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.Calculate(arg1, arg2, arg3, arg4));
        }

        //testing with two opposite sign numbers
        [TestMethod]
        public void TwoOpp()
        {
            //Setup
            string arg1 = "1,-2";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;

            Calculator calc = new Calculator();


            //Assert
            Assert.ThrowsException<ArgumentException>(() => calc.Calculate(arg1, arg2, arg3, arg4));
        }

        //testing with one valid one invalid
        [TestMethod]
        public void MixedVal()
        {
            //Setup
            string arg1 = "1,p";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "1+0 = 1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with one valid one invalid
        [TestMethod]
        public void MixedVal2()
        {
            //Setup
            string arg1 = "p,1";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "0+1 = 1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with more than 2 values
        [TestMethod]
        public void ThreeArgs()
        {
            //Setup
            string arg1 = "1,2,3";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "1+2+3 = 6";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with custom single deliminator
        [TestMethod]
        public void CustomArgs1()
        {
            //Setup
            string arg1 = "//[;]\n2;5";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "2+5 = 7";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with custom single deliminator
        [TestMethod]
        public void CustomArgs2()
        {
            //Setup
            string arg1 = "//[*][!!][r9r]\n11r9r22*33!!44";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "11+22+33+44 = 110";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        //testing with custom single deliminator
        [TestMethod]
        public void MultiplyTest()
        {
            //Setup
            string arg1 = "4,*,4";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "4*4 = 16";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            //Setup
            string arg1 = "4,/,2";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "4/2 = 2";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderOfOperTest()
        {
            //Setup
            string arg1 = "2,+,4,*,4";
            char arg2 = '\n';
            bool arg3 = false;
            long arg4 = 1000;
            string expected = "2+4*4 = 18";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1, arg2, arg3, arg4);
            Assert.AreEqual(expected, actual);
        }




    }
}
