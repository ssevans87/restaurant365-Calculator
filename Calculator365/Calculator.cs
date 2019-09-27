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
            if (args.Length > 2 && args[2].Length >= 1 && args[2].ToLower()[0] == 't') allowNeg = false;

            // Setting altDelim if applicable
            if (args.Length > 1 && args[1].Length == 1 && args[1][0] == 't') altDelim = args[1][0];

            if (args.Length > 0) formString = args[0];
            else return;

            Console.WriteLine(calc.Calculate(formString, altDelim, allowNeg, upperBound));

        }

        // Calculate method accepts args as follows.
        // arg1 : Formatted string to be processed.
        // altDelim : Alternate single character delimiter.
        // allowNeg : Deny negative numbers.
        // upperBound : Upper bound of numbers.
        public string Calculate(string formString, char altDelim, bool allowNeg, long upperBound)
        {

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
            long[] tokens;

            

            long result = 0;

            //sepperating numbers
            string[] tempTokens = SeperateNumbers(nums, delimiters, altDelim);

            //if (tempTokens.Length > 2) return "More than 2 numbers";

            //checking each token if it is a valid number
            tokens = GetValidArray(tempTokens, allowNeg, upperBound);

            string process = "";
            //checking for no valid numbers
            if (tokens.Length == 0) result = 0;
            else if (tokens.Length == 1)
            {
                result = tokens[0];
                process += tokens[0];
            }
            else
            {
                foreach (long l in tokens)
                {
                    result += l;
                    process += "+" + l;
                }
                process = process.Substring(1);
            }

            return process + " = " + result.ToString();
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
        public long[] GetValidArray(string[] toCheck, bool allowNeg, long upperBound)
        {
            string negativeNumbers = "";
            List<long> result = new List<long>();
            //checking each token if it is a valid number
            foreach (string s in toCheck)
            {
                long tempLong;
                if (long.TryParse(s, out tempLong))
                {


                    if (!allowNeg && tempLong < 0) negativeNumbers += "," + tempLong;
                    else if ( tempLong > upperBound) result.Add(0);
                    else result.Add(tempLong);

                }
                else result.Add(0);
            }
            if (negativeNumbers.Length > 0)
            {

                System.ArgumentException argEx = new System.ArgumentException("Negative numbers denied", negativeNumbers);
                throw argEx;
            }


            return result.ToArray();
        }

        //extract custom delimiter
        public List<string> ExtractDelims(string delString)
        {
            string delims = delString.Substring(2);
            string[] splitter = { "[", "]" };
            string[] result = delims.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            List<string> final = new List<string>();
            final.AddRange(result);
            return final;
        }
    }
}
