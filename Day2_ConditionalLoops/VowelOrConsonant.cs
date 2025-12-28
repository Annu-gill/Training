using System;

// Check vowel or consonant using switch
static class VowelOrConsonant
{
    public static void Execute()
    {
        Console.Write("Enter a character: ");
        char ch = Convert.ToChar(Console.ReadLine().ToLower());

        switch (ch)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine("Vowel");
                break;
            default:
                Console.WriteLine("Consonant");
                break;
        }
    }
}
