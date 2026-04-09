using System;
using System.Diagnostics.Tracing;
using Microsoft.VisualBasic.CompilerServices;

public class Program
{
    // changing of the notes
    /*  1.==============================================================================================
        Design and implement a program that processes a string entered from the keyboard.  The application will
        - convert the string to upper and lowercase
        - reverse the string
        - count the number punctuation characters in the string
        - find the index of the first vowel in the string
        - divide the string up into "words"

        2.==============================================================================================
        Design and implement a program that converts a sentence entered by the user into pig latin.
        - version 1 - 	moves the first character to the end and adds ay
        - version 2 - 	words that start with vowels - add way to the end
                        words that start with consonants - same as version 1

    */
    public static void Main()
    {
        Console.WriteLine("Please enter a word or phrase.  Press the ENTER key when you're done.");
        string input = Console.ReadLine();

        // uppercase and lowercase
        string lower = input.ToLower();
        Console.WriteLine("Converted to lowercase: " + lower);
        string upper = input.ToUpper();
        Console.WriteLine("Converted to uppercase: " + upper);

        // iterate through a string with a foreach loop
        string reverse = "";
        foreach (char c in input)
            reverse = c + reverse;
        Console.WriteLine("In reverse: " + reverse);

        // use Char method.  Note that most of the Char methods are static - they get called on a CLASS
        // Math.pow is a static method.  gen.Next(..) gets called on a random OBJECT and is NOT static
        int pCount = 0;
        foreach (char c in input)
            if (Char.IsPunctuation(c))
                pCount++;
        Console.WriteLine("Punctuation count: " + pCount);

        // a string has a Length property  - just like an array

        //index of the first vowel
        int vIndex = IndexOfFirstVowel(input);
        Console.WriteLine("The index of the first vowel is: " + vIndex);

        // create an array of strings from a string.  Default delimiter is white space.
        string[] words = input.Split();
        foreach (string word in words)
            Console.WriteLine(word);

        string pig1 = PigLatin1(words[0]);
        Console.WriteLine($"The word {words[0]} in pig latin is: {pig1}");

        string pig2 = PigLatin2(words[0]);
        Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig2);

        string pig3 = PigLatin3(words);
        Console.WriteLine($"The sentence {words[0]} in pig latin is: {pig3}");

        char b = 'b';
        Console.WriteLine("Here's a character: " + b);
        int asciiOFb = (int)b;
        Console.WriteLine("Here's its ascii value: " + asciiOFb);
        char bPlus1 = (char)(asciiOFb + 1);
        Console.WriteLine("Here's the character after adding 10 to it's ascii value: " + bPlus1);
        char z = 'z';
        Console.WriteLine("Here's a character: " + z);
        int asciiOFz = (int)z;
        Console.WriteLine("Here's its ascii value: " + asciiOFz);
        char zPlus1 = (char)(asciiOFz + 1);
        Console.WriteLine("Here's the character after adding 1 to it's ascii value: " + zPlus1);
        Console.WriteLine("Darn!  z should be translated to a");
    }

    // I'll do this with you in a screencast
    //Done
    static bool IsVowel(char c)
    {
        string vowels = "aeiouAEIOU";
        for (int i = 0; i < vowels.Length; i++)
        {
            if (vowels[i] == c)
            {
                return true;
            }
        }

        return false;
    }

    // I'll do this with you in a screencast
    //Done
    static int IndexOfFirstVowel(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (IsVowel(s[i]))
                return i;
        }

        return -1;
    }

    //Punctuation method using built in C# check

    static bool IsPunctuation(char c)
    {
        return char.IsPunctuation(c);
    }

    // I'll do this in the screencast
    //Done
    static string PigLatin1(string s)
    {
        string punch = "";
        string temp = "";

        foreach (char c in s)
        {
            if (IsPunctuation(c))
                punch += c; //punctuated
            else
                temp += c; //unpunctuated
        }

        s = temp;

        if (string.IsNullOrEmpty(s))
            return punch;

        string pigString = "";

        int i = IndexOfFirstVowel(s);

        if (IsVowel(s[0]) && s[0] != 'y')
        {
            pigString = s + "yay";
        }
        else if (i > 0)
        {
            pigString = s[i..] + s[..i] + "ay";
        }
        else
        {
            pigString = s + "ay";
        }

        return pigString + punch;
    }

    // I'll do this with you in a screencast
    //done myself because the video for lab 1 part 2 is missing

    //pigLatin capitalization
    static string PigLatin2(string s)
    {
        string punch = "";
        string temp = "";

        foreach (char c in s)
        {
            if (IsPunctuation(c))
                punch += c; //punctuated
            else
                temp += c; //unpunctuated
        }

        s = temp;

        if (string.IsNullOrEmpty(s))
            return punch;

        string pigString = "";

        string capitalPig = char.ToUpper(s[1]) + s.Substring(2);

        int i = IndexOfFirstVowel(s);

        if (IsVowel(s[0]) && s[0] != 'y')
        {
            pigString = s + "yay";
        }
        else if (i > 0)
        {
            pigString = capitalPig + s[..i].ToLower() + "ay";
        }
        else
        {
            pigString = s + "ay";
        }

        return pigString + punch;
    }

    //Checks and moves punctuations
    static string PigLatin3(string[] words)
    {
        string[] uniqueWords = words;
        for (int i = 0; i < uniqueWords.Length; i++)
        {
           uniqueWords[i] = PigLatin2(uniqueWords[i]);
        }
        return string.Join(" ", uniqueWords);
    }
}