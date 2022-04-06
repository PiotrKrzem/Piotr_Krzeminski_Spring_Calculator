using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class Calculator
    {
        public int Add()
        {
            return 0;
        }
        public int Add(string input)
        {
            
            if (input == "") return 0;
            string delimeter = ",";
            if (input.Length > 3 && input[0] == '/' && input[1] == '/')
            {
                if (input[2] == '[')
                {
                    while (input.IndexOf('[') >= 0)
                    {
                        int idx = input.IndexOf('[');
                        int idx2 = input.IndexOf(']');
                        string d = input.Substring(idx + 1, idx2 - idx - 1);
                        input = input.Substring(idx2 + 1);
                        input = input.Replace(d, delimeter);
                    }
                }
                else
                {
                    string d = input[2].ToString();
                    input = input.Substring(3);
                    input = input.Replace(d, delimeter);
                }
                
            }
            input = input.Replace("\n", delimeter);

            string[] vals = input.Split(delimeter,StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            List<int> negatives = new List<int>();
            Console.WriteLine(vals);
            for (int i = 0; i<vals.Length; i++)
            {
                int value = int.Parse(vals[i]);
                if (value < 0) negatives.Add(value);
                if (value > 1000) continue;
                sum += value;
            }
            if (negatives.Count>0)
            {
                throw new Exception("Negatives found: " + String.Join(' ', negatives));
            }
            return sum;


        }
    }
}
