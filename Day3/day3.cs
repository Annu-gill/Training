using System;
class Day03
{
    public static void Run()
    {
    //     // Valid Date Check: Input day/month/year and check if it's a valid calendar date (handle Feb 29).
        // Console.Write("Enter Day: ");
        // int day = int.Parse(Console.ReadLine());

        // Console.Write("Enter Month: ");
        // int month = int.Parse(Console.ReadLine());

        // Console.Write("Enter Year: ");
        // int year = int.Parse(Console.ReadLine());

        // bool isLeap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        // int daysInMonth = 0;

        // if (month >= 1 && month <= 12)
        // {
        //     if (month == 2)
        //         daysInMonth = isLeap ? 29 : 28;
        //     else if (month == 4 || month == 6 || month == 9 || month == 11)
        //         daysInMonth = 30;
        //     else
        //         daysInMonth = 31;

        //     if (day >= 1 && day <= daysInMonth)
        //         Console.WriteLine("Valid Date");
        //     else
        //         Console.WriteLine("Invalid Date");
        // }
        // else
        // {
        //     Console.WriteLine("Invalid Date");
        // }




        // // ATM Withdrawal: Nested if to check: 1. Card inserted, 2. Pin valid, 3. Balance sufficient.
        // Console.Write("Insert Card (yes/no): ");
        // string card = Console.ReadLine();

        // if (card == "yes")
        // {
        //     Console.Write("Enter PIN: ");
        //     int pin = int.Parse(Console.ReadLine());

        //     if (pin == 1234)
        //     {
        //         Console.Write("Enter Withdrawal Amount: ");
        //         int amount = int.Parse(Console.ReadLine());
        //         int balance = 5000;

        //         if (amount <= balance)
        //             Console.WriteLine("Withdrawal Successful");
        //         else
        //             Console.WriteLine("Insufficient Balance");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Invalid PIN");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("Please insert your card");
        // }



        // // Profit/Loss: Calculate profit or loss percentage based on Cost Price and Selling Price.

        // Console.Write("Enter Cost Price: ");
        // double cp = double.Parse(Console.ReadLine());

        // Console.Write("Enter Selling Price: ");
        // double sp = double.Parse(Console.ReadLine());

        // if (sp > cp)
        // {
        //     double profit = sp - cp;
        //     double profitPercent = (profit / cp) * 100;
        //     Console.WriteLine("Profit = " + profitPercent + "%");
        // }
        // else if (cp > sp)
        // {
        //     double loss = cp - sp;
        //     double lossPercent = (loss / cp) * 100;
        //     Console.WriteLine("Loss = " + lossPercent + "%");
        // }
        // else
        // {
        //     Console.WriteLine("No Profit No Loss");
        // }



        // // Rock Paper Scissors: Logic for a 2-player game using nested conditionals.

        // Console.Write("Player 1 (rock/paper/scissors): ");
        // string p1 = Console.ReadLine();

        // Console.Write("Player 2 (rock/paper/scissors): ");
        // string p2 = Console.ReadLine();

        // if (p1 == p2)
        // {
        //     Console.WriteLine("Draw");
        // }
        // else if (p1 == "rock")
        // {
        //     if (p2 == "scissors")
        //         Console.WriteLine("Player 1 Wins");
        //     else
        //         Console.WriteLine("Player 2 Wins");
        // }
        // else if (p1 == "paper")
        // {
        //     if (p2 == "rock")
        //         Console.WriteLine("Player 1 Wins");
        //     else
        //         Console.WriteLine("Player 2 Wins");
        // }
        // else if (p1 == "scissors")
        // {
        //     if (p2 == "paper")
        //         Console.WriteLine("Player 1 Wins");
        //     else
        //         Console.WriteLine("Player 2 Wins");
        // }
        // else
        // {
        //     Console.WriteLine("Invalid Input");
        // }


        // // Simple Calculator: Use switch to perform +, -, *, / based on user operator input.

        // Console.Write("Enter First Number: ");
        // double a = double.Parse(Console.ReadLine());

        // Console.Write("Enter Operator (+, -, *, /): ");
        // char op = char.Parse(Console.ReadLine());

        // Console.Write("Enter Second Number: ");
        // double b = double.Parse(Console.ReadLine());

        // switch (op)
        // {
        //     case '+':
        //         Console.WriteLine("Result = " + (a + b));
        //         break;

        //     case '-':
        //         Console.WriteLine("Result = " + (a - b));
        //         break;

        //     case '*':
        //         Console.WriteLine("Result = " + (a * b));
        //         break;

        //     case '/':
        //         if (b != 0)
        //             Console.WriteLine("Result = " + (a / b));
        //         else
        //             Console.WriteLine("Cannot divide by zero");
        //         break;

        //     default:
        //         Console.WriteLine("Invalid Operator");
        //         break;
        // }


        // // Fibonacci Series: Display the first N terms of the Fibonacci sequence.
        // Console.Write("Enter N: ");
        // int n = int.Parse(Console.ReadLine());

        // int a = 0, b = 1;

        // for (int i = 1; i <= n; i++)
        // {
        //     Console.Write(a + " ");
        //     int c = a + b;
        //     a = b;
        //     b = c;
        // }



        // // Prime Number: Check if a number is prime using a for loop and break.

        // Console.Write("Enter number: ");
        // int n = int.Parse(Console.ReadLine());
        // bool isPrime = true;

        // if (n <= 1)
        //     isPrime = false;

        // for (int i = 2; i <= n / 2; i++)
        // {
        //     if (n % i == 0)
        //     {
        //         isPrime = false;
        //         break; // Exit loop once divisor is found
        //     }
        // }

        // Console.WriteLine(isPrime ? "Prime Number" : "Not Prime");
        


        // // Armstrong Number: Check if a number equals the sum of its digits raised to the power of number of digits.

        // Console.Write("Enter number: ");
        // int num = int.Parse(Console.ReadLine());
        // int temp = num, sum = 0;
        // int digits = num.ToString().Length;

        // while (temp > 0)
        // {
        //     int d = temp % 10;
        //     sum += (int)Math.Pow(d, digits);
        //     temp /= 10;
        // }

        // Console.WriteLine(sum == num ? "Armstrong Number" : "Not Armstrong");



        // // Reverse & Palindrome: Reverse an integer and check if it is a palindrome using while.

        // Console.Write("Enter number: ");
        // int num = int.Parse(Console.ReadLine());
        // int temp = num, rev = 0;

        // while (temp > 0)
        // {
        //     rev = rev * 10 + (temp % 10);
        //     temp /= 10;
        // }

        // Console.WriteLine("Reverse = " + rev);
        // Console.WriteLine(num == rev ? "Palindrome" : "Not Palindrome");



        // // GCD and LCM: Find the Greatest Common Divisor and Least Common Multiple of two numbers.

        // Console.Write("Enter a: ");
        // int a = int.Parse(Console.ReadLine());

        // Console.Write("Enter b: ");
        // int b = int.Parse(Console.ReadLine());

        // int x = a, y = b;

        // // Euclidean Algorithm
        // while (y != 0)
        // {
        //     int temp = y;
        //     y = x % y;
        //     x = temp;
        // }

        // int gcd = x;
        // int lcm = (a * b) / gcd;

        // Console.WriteLine("GCD = " + gcd);
        // Console.WriteLine("LCM = " + lcm);



        // // Pascal's Triangle: Use Nested Loops to print Pascal's triangle up to N rows.

        // Console.Write("Enter rows: ");
        // int n = int.Parse(Console.ReadLine());

        // for (int i = 0; i < n; i++)
        // {
        //     int num = 1;
        //     for (int j = 0; j <= i; j++)
        //     {
        //         Console.Write(num + " ");
        //         num = num * (i - j) / (j + 1);
        //     }
        //     Console.WriteLine();
        // }



        // // Binary to Decimal: Convert a binary number string to decimal without using built-in library functions.

        // Console.Write("Enter binary number: ");
        // string bin = Console.ReadLine();

        // int dec = 0, power = 1;

        // for (int i = bin.Length - 1; i >= 0; i--)
        // {
        //     if (bin[i] == '1')
        //         dec += power;

        //     power *= 2;
        // }

        // Console.WriteLine("Decimal = " + dec);



        // // Diamond Pattern: Print a diamond shape using * characters with nested loops.

        //  int n = 5;

        // // Upper half
        // for (int i = 1; i <= n; i++)
        // {
        //     Console.Write(new string(' ', n - i));
        //     Console.WriteLine(new string('*', 2 * i - 1));
        // }

        // // Lower half
        // for (int i = n - 1; i >= 1; i--)
        // {
        //     Console.Write(new string(' ', n - i));
        //     Console.WriteLine(new string('*', 2 * i - 1));
        // }



        // // Factorial (Large numbers): Calculate N! and handle potential overflow for larger integers.

        // Console.Write("Enter N: ");
        // int n = int.Parse(Console.ReadLine());

        // long fact = 1;

        // for (int i = 1; i <= n; i++)
        // {
        //     fact *= i;
        // }

        // Console.WriteLine("Factorial = " + fact);


        // // Guessing Game: Use do-while to let a user guess a secret number until they get it right.

        // int secret = 7;
        // int guess;

        // do
        // {
        //     Console.Write("Guess number: ");
        //     guess = int.Parse(Console.ReadLine());
        // }
        // while (guess != secret);

        // Console.WriteLine("Correct Guess!");


        // // Sum of Digits: Repeatedly sum digits of a number until the result is a single digit (Digital Root).

        // Console.Write("Enter number: ");
        // int num = int.Parse(Console.ReadLine());

        // while (num >= 10)
        // {
        //     int sum = 0;
        //     while (num > 0)
        //     {
        //         sum += num % 10;
        //         num /= 10;
        //     }
        //     num = sum;
        // }

        // Console.WriteLine("Digital Root = " + num);




        // // Continue Usage: Print numbers from 1 to 50, but skip all multiples of 3 using continue.

        // for (int i = 1; i <= 50; i++)
        // {
        //     if (i % 3 == 0)
        //         continue;

        //     Console.Write(i + " ");
        // }




        // // Menu System: Use do-while and switch to create a persistent console menu.

        // int choice;

        // do
        // {
        //     Console.WriteLine("1. Add");
        //     Console.WriteLine("2. Subtract");
        //     Console.WriteLine("0. Exit");
        //     Console.Write("Choice: ");
        //     choice = int.Parse(Console.ReadLine());

        //     switch (choice)
        //     {
        //         case 1:
        //             Console.WriteLine("Addition Selected");
        //             break;
        //         case 2:
        //             Console.WriteLine("Subtraction Selected");
        //             break;
        //         case 0:
        //             Console.WriteLine("Exiting...");
        //             break;
        //         default:
        //             Console.WriteLine("Invalid Choice");
        //             break;
        //     }
        // } while (choice != 0);


    //     // Strong Number: Check if the sum of the factorial of digits is equal to the number itself.

    //     static int Fact(int n)
    // {
    //     int f = 1;
    //     for (int i = 1; i <= n; i++)
    //         f *= i;
    //     return f;
    // }

    // static void Main()
    // {
    //     Console.Write("Enter number: ");
    //     int num = int.Parse(Console.ReadLine());
    //     int temp = num, sum = 0;

    //     while (temp > 0)
    //     {
    //         sum += Fact(temp % 10);
    //         temp /= 10;
    //     }

    //     Console.WriteLine(sum == num ? "Strong Number" : "Not Strong");




        // Search with Goto: Implement a deep-nested loop search that uses goto to exit all levels instantly upon finding a result.


    //     int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };
    //     int target = 5;

    //     for (int i = 0; i < 2; i++)
    //     {
    //         for (int j = 0; j < 3; j++)
    //         {
    //             if (arr[i, j] == target)
    //             {
    //                 Console.WriteLine("Found at [" + i + "," + j + "]");
    //                 goto FOUND;
    //             }
    //         }
    //     }

    //     Console.WriteLine("Not Found");

    // FOUND:
    //     Console.WriteLine("Search Complete");


    }
}

