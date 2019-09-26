using System;
using System.Collections.Generic;

namespace Calculator365
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            if(args.Length >= 1 )Console.WriteLine(calc.Calculate(args[0]));
        }

        //perform calculation on given string
        public string Calculate(string arg1)
        {

            //list of delimiters
            List<string> delimiters = new List<string>();
            string nums = "";
            string delims = "";

            //splitting delims from numbers
            if (arg1.Length > 3 && arg1.Substring(0, 2) == "//")
            {
                int split = arg1.IndexOf('\n');
                delims = arg1.Substring(0, split);
                nums = arg1.Substring(split+1);
                delimiters = ExtractDelims(delims);
            }
            else nums = arg1;
            


            //list of valid numbers to add together
            long[] tokens;

            

            long result = 0;

            //sepperating numbers
            string[] tempTokens = SeperateNumbers(nums, delimiters);

            //if (tempTokens.Length > 2) return "More than 2 numbers";

            //checking each token if it is a valid number
            tokens = GetValidArray(tempTokens);

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
        public string[] SeperateNumbers(string toSeperate, List<string> newDelimiters)
        {
            List<string> allDelims = newDelimiters;
            
            //adding basic delimiters
            string[] basicDelims = { ",", "\n" };
            allDelims.AddRange(basicDelims);

            // seperating by delimiters
            string[] result = toSeperate.Split(newDelimiters.ToArray(), StringSplitOptions.None);
            return result;
        }

        //return only valid numbers
        public long[] GetValidArray(string[] toCheck)
        {
            string negativeNumbers = "";
            List<long> result = new List<long>();
            //checking each token if it is a valid number
            foreach (string s in toCheck)
            {
                long tempLong;
                if (long.TryParse(s, out tempLong))
                {


                    if (tempLong < 0) negativeNumbers += "," + tempLong;
                    else if ( tempLong > 1000) result.Add(0);
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
