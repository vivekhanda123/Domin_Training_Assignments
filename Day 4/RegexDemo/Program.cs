using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Example 1 Email Validation 
            //string emailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|in)$";

            //string[] emails = { "test@example.com", "invalidemailPattern@", "example@co.in" };
            //foreach (string email in emails)
            //{
            //    if (Regex.IsMatch(email, emailPattern))
            //    {
            //        Console.WriteLine($"{email} is Valid");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{email} is Invalid");
            //    }
            //}

            // Example 2 is to find a number
            //Console.WriteLine("Enter the text to extract the number from string.");
            //string input  = Console.ReadLine();
            //string numberPattern = @"\d+";
            //foreach(Match match in Regex.Matches(input, numberPattern))
            //{
            //    Console.WriteLine($"Found number : {match.Value}");
            //}

            // Example 3 to replace a string 
            //string message = "You can reach me @ 123-456-7890 or 987-654-3210";
            //string mobilePattern = @"\d{3}-\d{3}-\d{4}";

            //string replceWith = "***-***-****";
            //string result = Regex.Replace(message, mobilePattern, replceWith);
            //Console.WriteLine(result);

            // Example 4 Find and highlight the specific pattern 
            string content = "I forgot my lunch box at black box";

            string wordPattern = @"\b\w+?ox\b";

            string findResult = Regex.Replace(content, wordPattern, match => $"[{match.Value}]");
            Console.WriteLine(findResult);
            Console.ReadKey();

        }
    }
}
