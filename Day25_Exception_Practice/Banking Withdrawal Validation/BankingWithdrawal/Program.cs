using System;

class BankAccount
{
    public static void Main()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");
        int amount = int.Parse(Console.ReadLine());

        try
        {
            // 1. Throw exception if amount <= 0
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            // 2. Throw exception if amount > balance
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }

            // 3. Deduct amount if valid
            balance -= amount;
            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine("Remaining Balance: " + balance);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            // 4. Log transaction
            Console.WriteLine("Transaction completed at: " + DateTime.Now);
        }
    }
}
