using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word to check if it's a palindrome:");
            string input = Console.ReadLine();

            if (IsPalindrome(input))
            {
                Console.WriteLine($"{input} is a palindrome.");
            }
            else
            {
                Console.WriteLine($"{input} is not a palindrome.");
            }
            Console.ReadLine();
        }

        static bool IsPalindrome(string word)
        {
            // Convert the word to lowercase to make the comparison case-insensitive
            word = word.ToLower();

            // Split the word into an array of characters
            char[] charArray = word.ToCharArray();

            // Reverse the array
            Array.Reverse(charArray);

            // Join the characters back into a string
            string reversedWord = new string(charArray);

            // Check if the original word is equal to the reversed word
            return word == reversedWord;
        }
    }
    }

