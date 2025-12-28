using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Valid Date Check");
            Console.WriteLine("2. ATM Withdrawal");
            Console.WriteLine("3. Profit / Loss");
            Console.WriteLine("4. Rock Paper Scissors");
            Console.WriteLine("5. Simple Calculator");
            Console.WriteLine("6. Fibonacci Series");
            Console.WriteLine("7. Prime Number");
            Console.WriteLine("8. Armstrong Number");
            Console.WriteLine("9. Reverse & Palindrome");
            Console.WriteLine("10. GCD and LCM");
            Console.WriteLine("11. Pascal's Triangle");
            Console.WriteLine("12. Binary to Decimal");
            Console.WriteLine("13. Diamond Pattern");
            Console.WriteLine("14. Factorial");
            Console.WriteLine("15. Guessing Game");
            Console.WriteLine("16. Digital Root");
            Console.WriteLine("17. Continue Usage");
            Console.WriteLine("18. Strong Number");
            Console.WriteLine("19. Search with Goto");
            Console.WriteLine("20. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: ValidDateCheck.Execute(); break;
                case 2: ATMWithdrawal.Execute(); break;
                case 3: ProfitLoss.Execute(); break;
                case 4: RockPaperScissors.Execute(); break;
                case 5: SimpleCalculator.Execute(); break;
                case 6: FibonacciSeries.Execute(); break;
                case 7: PrimeNumber.Execute(); break;
                case 8: ArmstrongNumber.Execute(); break;
                case 9: ReversePalindrome.Execute(); break;
                case 10: GcdLcm.Execute(); break;
                case 11: PascalsTriangle.Execute(); break;
                case 12: BinaryToDecimal.Execute(); break;
                case 13: DiamondPattern.Execute(); break;
                case 14: FactorialLarge.Execute(); break;
                case 15: GuessingGame.Execute(); break;
                case 16: DigitalRoot.Execute(); break;
                case 17: ContinueUsage.Execute(); break;
                case 18: StrongNumber.Execute(); break;
                case 19: SearchWithGoto.Execute(); break;
                case 20: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid choice"); break;
            }

        } while (choice != 20);
    }
}
