// Question 10:

using System;

namespace Day18_Practice
{
    public class VerifiedUser
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string message) : base(message)
        {
        }
    }
}
