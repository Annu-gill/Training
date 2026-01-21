// Question 5: 

using System;

namespace Day18_Practice
{
    public class InsufficientWalletBalanceException : Exception
    {
        public InsufficientWalletBalanceException(string message) : base(message)
        {
        }
    }
}
