using System;

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
        Console.WriteLine("Puncutation count: " + pCount);

        // find the index of the first vowel in a string
        // see the method IsVowel below
        int vIndex = -1;
        // a string has a Length property  - just like an array
        for (int i = 0; i < input.Length && vIndex == -1; i++)
        {
            char c = input[i];
            if (IsVowel(c))
                vIndex = i;
        }
        Console.WriteLine("The index of the first vowel is: " + vIndex);

        // create an array of strings from a string.  Default delimiter is white space.
        string[] words = input.Split();
        foreach (string word in words)
            Console.WriteLine(word);

        string pig1 = PigLatin1(words[0]);
        Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig1);

        string pig2 = PigLatin2(words[0]);
        Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig2);

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

    // I'll do this with you in a screen cast
    static bool IsVowel(char c)
    {
        return false;
    }

    // I'll do this with you in a screen cast
    static int IndexOfFirstVowel(string s)
    {
        int vIndex = -1;
        return vIndex;
    }

    // I'll do this in the screen cast
    static string PigLatin1(string s)
    {
        return s;
    }

    // I'll do this with you in a screen cast
    static string PigLatin2(string s)
    {
        return s;
    }
}