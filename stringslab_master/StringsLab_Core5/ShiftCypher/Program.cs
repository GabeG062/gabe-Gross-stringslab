using System;

namespace ShiftCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word or phrase, do NOT enter any numbers. Press the ENTER key when you're done.");
            string input = Console.ReadLine();
            
            string[] words = input.Split();
            
            Random rnd = new Random();
            int shift = rnd.Next(-10, 11);
            Console.WriteLine("Shift is " + shift);
            
            string encodedWord = SentenceCoder(words, shift);
            Console.WriteLine($"the encoded version of {input} with a shift of {shift} is {encodedWord}");
        }

        static string SentenceCoder(string[] words, int shift)
        {
            string newWord = "";
            string word = "";
            string[] encodedSentence = new string[words.Length];
            
            for (int i = 0; i < words.Length; i++)
            {
                newWord = words[i];
                word = Coder(newWord, shift);
                encodedSentence[i] = word;
            }
            string result = string.Join(", ", encodedSentence);
            return result;
        }
        
        static string Coder(string word, int shift)
        {
            char[] originalLetters = [];
            char letter = ' ';
            int asciiValue = 0;
            int[] asciiValues = [];
            
            
            //this combines the string into one singular block
            string combinedSentence = string.Join("", word);
            originalLetters = combinedSentence.ToCharArray();
            asciiValues = new int[originalLetters.Length];
            

            //this for loop converts the character array into an int array with the ASCII values
            for (int i = 0; i < originalLetters.Length; i++)
            {
                letter = originalLetters[i];
                asciiValue = (int)letter;
                asciiValues[i] = asciiValue;
            }
            
            //this for loop shifts the contents of the ASCII array by a random number between -10 and 10 in the Uppercase
            for (int i = 0; i < asciiValues.Length; i++)
            {
                int[] asciiOriginal = (int[])asciiValues.Clone();
                asciiValues[i] += shift;
                if (asciiOriginal[i] >= 65 && asciiOriginal[i] <= 90)
                {
                    if (asciiValues[i] < 65)
                    {
                        asciiValues[i] += 26;
                    }
                    else if (asciiValues[i] > 90)
                    {
                        asciiValues[i] -= 26;
                    }
                }
                else if (asciiOriginal[i] >= 97 && asciiOriginal[i] <= 122)
                {
                    if (asciiValues[i] < 97)
                    {
                        asciiValues[i] += 26;
                    }
                    else if (asciiValues[i] > 122)
                    {
                        asciiValues[i] -= 26;
                    }
                }
                else
                {
                    asciiValues[i] -= shift;
                }
            }
            //this array converts the ASCII Array back into a character array after being shuffled
            for (int i = 0; i < asciiValues.Length; i++)
            {
                asciiValue = asciiValues[i];
                letter = (char) asciiValue;
                originalLetters[i] = letter;
            }
            string sentence = new string(originalLetters);
            
            return sentence;
        }
    }
}
