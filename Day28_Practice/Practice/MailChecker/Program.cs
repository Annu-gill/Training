using System;
using System.Reflection.Metadata.Ecma335;
class MailValidation
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the email id: ");
        string email=Console.ReadLine();
        if (IsValidGmail(email))
        {
            Console.WriteLine("The given email is valid");
        }
        else
        {
            Console.WriteLine("The given email is not valid");
        }

    }
    static bool IsValidGmail(string email)
    {
        // 1. Check empty or null
        if (string.IsNullOrEmpty(email))
            // return false;
            Console.WriteLine("The email should not be null or empty");

        // 2. No spaces allowed
        if (email.Contains(" "))
            // return false;
            Console.WriteLine("The email should not conatin a space");

        // 3. Must contain exactly one '@'
        int atIndex = email.IndexOf('@');
        if (atIndex <= 0 || atIndex != email.LastIndexOf('@'))
            return false;

        // Split local part and domain part
        string localPart = email.Substring(0, atIndex);
        string domainPart = email.Substring(atIndex + 1);

        // 4. Local part should not be empty
        if (string.IsNullOrEmpty(localPart))
            return false;

        // 5. Local part must contain only alphabets and digits
        foreach (char ch in localPart)
        {
            if (!char.IsLetterOrDigit(ch))
                return false;
        }

        // 6. Domain must be exactly "gmail.com"
        if (domainPart != "gmail.com")
            return false;

        // 7. After '@' there should be only 1 dot
        int dotCount = 0;
        foreach (char ch in domainPart)
        {
            if (ch == '.')
                dotCount++;
        }

        if (dotCount != 1)
            return false;

        return true;
    }
}
