using System;
using System.Collections.Generic;

namespace Calculator365
{
    public class Calculator
    {
        // Main method accepts args as follows.
        // args[0] : Formatted string to be processed.
        // args[1] : Alternate single character delimiter. - Defaults to '\n'
        // args[2] : Deny negative numbers. (T = true/ F = false) - Defaults to true.
        // args[3] : Upper bound of numbers. - Defaults to 1000
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            // Formatted string to use
            string formString = "";
            // Alternate delimiter
            char altDelim = '\n';
            // If to allow negative numbers
            bool allowNeg = false;
            // Max number allowed
            long upperBound = 1000;

            // Setting upper bound if aplicable 
            if (args.Length > 3) long.TryParse(args[3] , out upperBound);

            // Setting allowNeg if applicable
            if (args.Length > 2 && args[2].Length >= 1 && args[2].ToLower()[0] == 't') allowNeg = true;

            // Setting altDelim if applicable
            if (args.Length > 1 && args[1].Length == 1 && args[1][0] == 't') altDelim = args[1][0];

            // Setting formatted string
            if (args.Length > 0) formString = args[0];

            

            // Detecting Ctrl+C
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                Console.WriteLine("out");
                e.Cancel = true;
            };
            // Loop until Ctrl+C
            try
            {
                while (true)
                {
                    string result = calc.Calculate(formString, altDelim, allowNeg, upperBound);
                    Console.WriteLine(result);
                    string tempLine = Console.ReadLine();
                    if (tempLine == null) break;
                    if (tempLine.Length > 0)
                    {
                        if (tempLine[0] != ',') formString += ",";
                        formString += tempLine;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        // Calculate method accepts args as follows.
        // arg1 : Formatted string to be processed.
        // altDelim : Alternate single character delimiter.
        // allowNeg : Deny negative numbers.
        // upperBound : Upper bound of numbers.
        public string Calculate(string formString, char altDelim, bool allowNeg, long upperBound)
        {
            // Check for null string input
            if (formString == null) return"";
            // List of delimiters
            List<string> delimiters = new List<string>();
            string nums = "";
            string delims = "";

            // Splitting delims from numbers
            if (formString.Length > 3 && formString.Substring(0, 2) == "//")
            {
                int split = formString.IndexOf('\n');
                delims = formString.Substring(0, split);
                nums = formString.Substring(split+1);
                delimiters = ExtractDelims(delims);
            }
            else nums = formString;
            


            // List of valid numbers to add together
            string[] tokens;


            //sepperating numbers
            string[] tempTokens = SeperateNumbers(nums, delimiters, altDelim);

            //if (tempTokens.Length > 2) return "More than 2 numbers";

            //checking each token if it is a valid number
            tokens = GetValidArray(tempTokens, allowNeg, upperBound);

            return PerformMath(tokens);
        }

        //seperating numbers by delimiters
        public string[] SeperateNumbers(string toSeperate, List<string> newDelimiters, char altDelim)
        {
            List<string> allDelims = newDelimiters;
            
            //adding basic delimiters
            string[] basicDelims = { "," };
            allDelims.AddRange(basicDelims);
            allDelims.Add("" + altDelim);

            // seperating by delimiters
            string[] result = toSeperate.Split(newDelimiters.ToArray(), StringSplitOptions.None);
            return result;
        }

        //return only valid numbers
        public string[] GetValidArray(string[] toCheck, bool allowNeg, long upperBound)
        {
            string negativeNumbers = "";
            List<string> result = new List<string>();
            // Op is used to check for two operators in a row
            bool op = true;
            // Checking each token if it is a valid number
            foreach (string s in toCheck)
            {
                long tempLong;
                if (long.TryParse(s, out tempLong))
                {

                    if (!allowNeg && tempLong < 0) negativeNumbers += "," + tempLong;
                    else if (tempLong > upperBound) result.Add("" + 0);
                    else result.Add("" + tempLong);
                    op = false;

                }
                else if (s.Trim() == "+" || s.Trim() == "-" || s.Trim() == "*" || s.Trim() == "/")
                {
                    // Throw exception if 2 operators in a row 
                    if (op)
                    {
                        System.ArgumentException argEx = new System.ArgumentException("Invalid operators");
                        throw argEx;
                    }
                    op = true;
                    result.Add(s.Trim());
                }
                else
                {
                    result.Add("0");
                    op = false;
                }
            }
            // Throw exception if negative numbers are not allowed but found
            if (negativeNumbers.Length > 0)
            {

                System.ArgumentException argEx = new System.ArgumentException("Negative numbers denied", negativeNumbers);
                throw argEx;
            }

            // Throw exception if ending with an operator 
            if (op)
            {
                System.ArgumentException argEx = new System.ArgumentException("Invalid operators");
                throw argEx;
            }

            return result.ToArray();
        }

        // Extract custom delimiter
        public List<string> ExtractDelims(string delString)
        {
            string delims = delString.Substring(2);
            string[] splitter = { "[", "]" };
            string[] result = delims.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            List<string> final = new List<string>();
            final.AddRange(result);
            return final;
        }

        // Perform mathmatic functions
        public string PerformMath(string[] input)
        {
            Stack<string> myStack1 = new Stack<string>();
            Stack<string> myStack2 = new Stack<string>();
            string math = "";
            long count = 0;
            bool num = false;
            foreach (string s in input)
            {
                long tempLong;
                if (long.TryParse(s, out tempLong))
                {
                    if (num) math += "+";
                    math += s;
                    num = true;
                }
                else
                {
                    num = false;
                    math += s;
                }

            }

            // Checking for multiplication or division
            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == "*")
                {
                    i++;
                    long a, b;
                    long.TryParse(myStack1.Pop(), out a);
                    long.TryParse(input[i], out b);
                    myStack1.Push((a * b).ToString());
                }
                else if (input[i] == "/")
                {

                    i++;
                    long a, b;
                    long.TryParse(myStack1.Pop(), out a);
                    long.TryParse(input[i], out b);
                    myStack1.Push((a / b).ToString());
                }
                else myStack1.Push(input[i]);
            }
            // Reversing order
            foreach (string s in myStack1) myStack2.Push(s);
            bool subtract = false;
            // Checking for addition and subrtraction
            foreach (string s in myStack2)
            {
                long tempNum;
                if (long.TryParse(s, out tempNum))
                {
                    // reverse sign if it is a negative number
                    if (subtract) tempNum = 0 - tempNum;
                    count += tempNum;
                    subtract = false;
                }
                else if (s == "-") subtract = true;
            }

            string result = math + " = " + count;
            return result;
        }
    }
}
