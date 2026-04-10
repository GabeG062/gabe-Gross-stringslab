using System;

namespace ShiftCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word or phrase.  Press the ENTER key when you're done.");
            string input = Console.ReadLine();
            
            string[] words = input.Split();
            foreach (string word in words)
                Console.WriteLine(word);
            
            Random rnd = new Random();
            int shift = rnd.Next(-10, 10);
            Console.WriteLine("Shift is " + shift);
            
            string encodedWord = Coder(words[0]);
            Console.WriteLine($"the encoded version of {words[0]} with a shift of {shift} is {encodedWord}");
        }

        static string Coder(string s)
        {
            return "asdf";
        }
    }
}
