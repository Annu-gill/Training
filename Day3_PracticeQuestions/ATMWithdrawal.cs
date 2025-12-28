using System;

// Nested if to check: Card inserted, Pin valid, Balance sufficient.
static class ATMWithdrawal
{
    public static void Execute()
    {
        Console.Write("Insert card (yes/no): ");
        string card = Console.ReadLine();

        if (card == "yes")
        {
            Console.Write("Enter PIN: ");
            int pin = int.Parse(Console.ReadLine());

            if (pin == 1234)
            {
                Console.Write("Enter withdrawal amount: ");
                int amount = int.Parse(Console.ReadLine());

                int balance = 5000;
                if (amount <= balance)
                    Console.WriteLine("Transaction Successful");
                else
                    Console.WriteLine("Insufficient Balance");
            }
            else
                Console.WriteLine("Invalid PIN");
        }
        else
            Console.WriteLine("Card not inserted");
    }
}
