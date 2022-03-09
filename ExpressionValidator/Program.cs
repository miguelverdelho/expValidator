using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionValidator
{
    class Program
    {
        // brackets includes the pairs of characters that should be matched together
        static Dictionary<char, char> brackets = new Dictionary<char, char>()
        {
            {'(',')'},
            {'{','}'},
            {'[',']'},
        };


        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\nPlease insert an expression to validate:");

                string expression = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(expression))
                {
                    PerformValidation(expression.ToCharArray());
                }
                else
                {
                    Console.WriteLine("The expression can not be empty");
                }

            }


        }

        static void PerformValidation(char[] expression)
        {
            Stack<char> openingBrackets = new Stack<char>();

            int position = 0;
            foreach (char c in expression)
            {
                position++;

                // if it is an opening bracket add to stack
                if (brackets.Keys.Contains(c))
                {
                    openingBrackets.Push(c);
                }
                // if it is closing bracket check if it matches the top item of the stack
                else if (brackets.Values.Contains(c))
                {
                    if (openingBrackets.Count > 0 && openingBrackets.Peek() == brackets.FirstOrDefault(x => x.Value == c).Key)
                    {
                        // in case it is matched, pop from stack
                        openingBrackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine($"Invalid caracter at position {position}.");
                        return;
                    }
                }
                else
                    continue;
            }

            //if stack is not empty by now, there were brackets unclosed
            if (openingBrackets.Count > 0)
            {
                Console.WriteLine($"There were brackets unclosed in the expression. Should be closed at position {position}.");
            }
            else
            {
                Console.WriteLine("Expression is valid.");
            }
        }
    }
}
