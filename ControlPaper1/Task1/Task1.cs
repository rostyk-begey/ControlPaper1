using System;
using System.Linq;

namespace ControlPaper1.Task1
{
    static class StringExtensionClass {
        public static bool ContainsDigits(this String str)
        {
            return str.Any(char.IsDigit);
        }
    }

    static class Task1
    {
        public static void Run()
        {
            Console.WriteLine("--- TASK 1 ---");
            Console.WriteLine("Enter text: ");
            String inputText = Console.ReadLine();
            String outputText = "";
            int counter = 0;
            
            foreach (string word in inputText.Split(' '))
            {
                if (word.ContainsDigits())
                {
                    ++counter;
                }
                else
                {
                    outputText += word + " ";
                }
            }
            Console.WriteLine("------------");
            Console.WriteLine("Number of words with digits: " + counter);
            Console.WriteLine("Output text: ");
            Console.WriteLine(outputText);
            Console.WriteLine("=== END TASK 1 ===");
        }
    }
}