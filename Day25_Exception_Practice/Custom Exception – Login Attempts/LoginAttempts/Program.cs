using System;

// Custom Exception
class LoginAttemptExceededException : Exception
{
    public LoginAttemptExceededException(string message) : base(message)
    {
    }
}

class LoginSystem
{
    public static void Main()
    {
        int attempts = 0;
        const int maxAttempts = 3;

        // User-defined credentials
        Console.Write("Create Username: ");
        string registeredUsername = Console.ReadLine();

        Console.Write("Create Password: ");
        string registeredPassword = Console.ReadLine();

        try
        {
            while (true)
            {
                Console.Write("\nEnter Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (username == registeredUsername && password == registeredPassword)
                {
                    Console.WriteLine("Login successful!");
                    break;
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Invalid credentials.");

                    if (attempts >= maxAttempts)
                    {
                        throw new LoginAttemptExceededException(
                            "Maximum login attempts exceeded. Access denied."
                        );
                    }
                }
            }
        }
        catch (LoginAttemptExceededException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Application terminated.");
        }
        finally
        {
            Console.WriteLine("End of login process.");
        }
    }
}
