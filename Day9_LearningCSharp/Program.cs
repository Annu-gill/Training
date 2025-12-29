using System;
using Day9_LearningCSharp;  

﻿namespace LearningCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            YoungProfessional yp = new YoungProfessional();
        
            PartialClass p=new PartialClass();
            p.MethodA();
            p.MethodB();

            Console.WriteLine(GeneralUses.GetRollNo());
            Console.WriteLine(GeneralUses.GetRollNo());

        }
    }

}


// can we use sealed class in abstract class
// how can we hide the method from parent class to child class