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
            //list of valid numbers to add together
            long[] tokens;

            //list of delimiters
            List<string> delimiters = new List<string>();

            long result = 0;

            //sepperating numbers
            string[] tempTokens = SeperateNumbers(arg1, delimiters);

            if (tempTokens.Length > 2) return "More than 2 numbers";

            //checking each token if it is a valid number
            tokens = GetValidArray(tempTokens);


            //checking for no valid numbers
            if (tokens.Length == 0) result = 0;
            else if (tokens.Length == 1) result = tokens[0];
            else
            {
                foreach (long l in tokens)
                {
                    try { result = checked(result + l); }
                    catch (OverflowException) { return "Overflow"; }
                }
            }

            return result.ToString();
        }

        //seperating numbers by delimiters
        public string[] SeperateNumbers(string toSeperate, List<string> newDelimiters)
        {

            string[] tempTokens = toSeperate.Split(',');


            return tempTokens;
        }

        //return only valid numbers
        public long[] GetValidArray(string[] toCheck)
        {
            List<long> result = new List<long>();
            //checking each token if it is a valid number
            foreach (string s in toCheck)
            {
                long tempLong;
                if (long.TryParse(s, out tempLong)) result.Add(tempLong);
            }


            return result.ToArray();
        }
    }
}
