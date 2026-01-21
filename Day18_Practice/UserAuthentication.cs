// Question 6: 

using System;

namespace Day18_Practice
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
    }

    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException(string message) : base(message)
        {
        }
    }
}
