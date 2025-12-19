using System;
using System.Linq.Expressions;
class Day02
{
    // public bool isEven(int number)
    // {
    //     if (number % 2 == 0)
    //     {
    //         return true;

    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }
    // public static void Run()
    // {
    //     Day02 calc=new Day02();
    //     Console.WriteLine("Is even: "+calc.isEven(6));
    //     Console.WriteLine("Is even: "+calc.isEven(7));
    // }

    public static void Run()
    {
        // // Height Category: Accept height in cm. If < 150 (Dwarf), 150-165 (Average), 165-190 (Tall), >190 (Abnormal).

        // int height;
        // Console.Write("Enter height in cm: ");
        // height = Convert.ToInt32(Console.ReadLine());

        // if (height < 150)
        // {
        //     Console.WriteLine("Dwarf");
        // }
        // else if(height>=150 && height < 165)
        // {
        //     Console.WriteLine("Average");
        // }
        // else if(height>=165 && height < 190)
        // {
        //     Console.WriteLine("Tall");
        // }
        // else if (height > 190)
        // {
        //     Console.WriteLine("Abnormal");
        // }
        // else
        // {
        //     Console.WriteLine("Enter valid height");
        // }


        // // Largest of Three: Take three integers and find the maximum using nested if.

        // int a,b,c;
        // Console.WriteLine("Enter 1st no.: ");
        // a=Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine("Enter 2nd no.: ");
        // b=Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine("Enter 3rd no.: ");
        // c=Convert.ToInt32(Console.ReadLine());

        // // Conditions for checking the largest number
        // if (a > b)
        // {
        //     if (a > c)
        //     {
        //         Console.WriteLine("Largest no. is: "+a);
        //     }
        //     else
        //     {
        //         Console.WriteLine("Largest no. is: "+c);
        //     }
        // }
        // else
        // {
        //     if (b > c)
        //     {
        //         Console.WriteLine("Largest no. is: "+b);
        //     }
        //     else
        //     {
        //         Console.WriteLine("Largest no. is: "+c);
        //     }
        // }


        // Leap Year Checker: Determine if a year is leap (Divisible by 400 OR (Divisible by 4 and NOT 100)).

        // int year;
        // Console.WriteLine("Enter the year: ");
        // year=Convert.ToInt32(Console.ReadLine());
        // // check if year is a leap year or not
        // if (year%400==0 ||(year%4==0 && year % 100 != 0))
        // {
        //     Console.WriteLine(year+" is a leap year");
        // }
        // else
        // {
        //     Console.WriteLine(year+" is not a leap year");
        // }


        // // Quadratic Equation: Calculate roots of a^2 + bx + c = 0 using if-else to check the discriminant.

        // double a,b,c, discriminant;  
        // Console.Write("a= ");
        // a=Convert.ToDouble(Console.ReadLine());
        // Console.Write("b= ");
        // b=Convert.ToDouble(Console.ReadLine());
        // Console.Write("c= ");
        // c=Convert.ToDouble(Console.ReadLine());

        // // calculating discriminant
        // discriminant= b*b-(4*a*c);
        // double root1, root2;

        // // check if equation is not quadratic
        // if (a == 0)
        // {
        //     Console.WriteLine("It is not a quadratic equation.");
        //     return ;
        // }

        // if (discriminant > 0)
        // {
        //     root1=Convert.ToDouble(-b+(Math.Sqrt(discriminant))/(2*a));
        //     root2=Convert.ToDouble(-b-(Math.Sqrt(discriminant))/(2*a));

        //     Console.WriteLine("Roots are: "+root1+" and "+root2);
        // }
        // else if (discriminant == 0)
        // {
        //     root1=Convert.ToDouble(-b/(2*a));

        //     Console.WriteLine("Roots are: "+root1+ " and "+root1);   
        // }
        // // check if roots exists or not
        // else
        // {
        //     Console.WriteLine("Roots doesn't exists.");
        // }


        // // Admission Eligibility: Math ≥ 65, Phys ≥ 55, Chem ≥ 50 AND (Total ≥ 180 OR Math+Phys ≥ 140).

        // int math, physics, chemistry;
        // Console.Write("Marks in Maths: ");
        // math=Convert.ToInt32(Console.ReadLine());
        // Console.Write("Marks in Physics: ");
        // physics=Convert.ToInt32(Console.ReadLine());
        // Console.Write("Marks in CHemistry: ");
        // chemistry=Convert.ToInt32(Console.ReadLine());

        // int total=math+physics+chemistry;
        // int mathandphysics=math+physics;

        // if (math>=65 && physics>=55 && chemistry>=50 &&(total>=180 || mathandphysics >= 140))
        // {
        //     Console.WriteLine("You are eligible for admissions.");
        // }
        // else
        // {
        //     Console.WriteLine("You are not eligible for admissions.");
        // }

        // // Electricity Bill: Calculate bill: First 199 units @ 1.20; 200-400 @ 1.50; 400-600 @ 1.80; above 600 @ 2.00. Add 15% surcharge if bill > 400.

        // double noOfUnits, bill;
        // Console.Write("Enter the number of units comsumed: ");
        // noOfUnits=Convert.ToDouble(Console.ReadLine());
        // if (noOfUnits <= 199)
        // {
        //     bill=noOfUnits*1.20;
        // }
        // else if(noOfUnits>=200 && noOfUnits <= 400)
        // {
        //     bill=(199*1.20)+(noOfUnits-199)*1.50;
        // }
        // else if (noOfUnits>=400 && noOfUnits <= 600)
        // {
        //     bill=(199*1.20)+(201*1.50)+(noOfUnits-400)*1.80;
        // }
        // else
        // {
        //     bill=(199*1.20)+(201*1.50)+(200*1.80)+(noOfUnits-600)*2.0;
        // }
        // if (bill > 400)
        // {
        //     bill=bill+(bill*0.15);
        // }
        // Console.WriteLine("Total electricity bill: "+bill);


        // // Vowel or Consonant: Use a switch statement to check if a character is a vowel.

        // char character;
        // Console.Write("Enter a character: ");
        // character=Convert.ToChar(Console.ReadLine());
        // switch (character)
        // {
        //     case 'a':
        //     case 'e':
        //     case 'i':
        //     case 'o':
        //     case 'u':
        //         Console.WriteLine("Character is a vowel.");
        //         break;
        //     default:
        //         Console.WriteLine("Character is a consonent.");
        //         break;
        // }



        // // Triangle Type: Check if a triangle is Equilateral, Isosceles, or Scalene based on side lengths.

        // int firstside, secondside, thirdside;
        // Console.Write("Enter first side: ");
        // firstside=Convert.ToInt32(Console.ReadLine());
        // Console.Write("Enter 2nd side: ");
        // secondside=Convert.ToInt32(Console.ReadLine());
        // Console.Write("Enter 3rd side: ");
        // thirdside=Convert.ToInt32(Console.ReadLine());
        // if (firstside+secondside>thirdside && firstside+thirdside>secondside && secondside + thirdside > firstside)
        // {
        //     if (firstside == secondside && secondside == thirdside)
        //     {
        //         Console.WriteLine("It is an equilateral triangle.");
        //     }
        //     else if(firstside == secondside || secondside == thirdside || thirdside == firstside)
        //     {
        //         Console.WriteLine("It is an Isosceles triangle.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("It is a Scalene traiangle.");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("Sides for triangle are not valid.");
        // }



        // // Quadrant Finder: Take (x,y) coordinates and print which quadrant they lie in.

        // int x, y;
        // Console.Write("Enter the x-coordinate: ");
        // x=Convert.ToInt32(Console.ReadLine());
        // Console.Write("Enter y-coordinate: ");
        // y=Convert.ToInt32(Console.ReadLine());
        // if (x>0 && y > 0)
        // {
        //     Console.WriteLine("(x,y) coordinate lies in first co-ordinate.");
        // }
        // else if (x<0 && y > 0)
        // {
        //     Console.WriteLine("(x,y) coordinate lies in second co-ordinate.");
        // }
        // else if (x<0 && y < 0)
        // {
        //     Console.WriteLine("(x,y) coordinate lies in third co-ordinate.");
        // }
        // else if (x>0 && y < 0)
        // {
        //     Console.WriteLine("(x,y) coordinate lies in fourth co-ordinate.");
        // }
        // else if (x==0 && y==0)
        // {
        //     Console.WriteLine("(x,y) coordinate lies on origin.");
        // }
        // else if (x==0)
        // {
        //     Console.WriteLine("(x,y) coordinate lies on Y-axis.");
        // }
        // else if (y==0)
        // {
        //     Console.WriteLine("(x,y) coordinate lies on X-axis.");
        // }



        // // Grade Description: Input grade (E, V, G, A, F) and print (Excellent, Very Good, Good, Average, Fail) using switch.

        // char grade;
        // Console.Write("Enter grade(E, V, G, A, F): ");
        // grade=Convert.ToChar(Console.ReadLine());
        // switch (grade)
        // {
        //     case 'E':
        //         Console.WriteLine("Excellent.");
        //         break;
        //     case 'V':
        //         Console.WriteLine("Very Good.");
        //         break;
        //     case 'G':
        //         Console.WriteLine("Good.");
        //         break;
        //     case 'A':
        //         Console.WriteLine("Average.");
        //         break;
        //     case 'F':
        //         Console.WriteLine("Fail.");
        //         break;
        //     default:
        //         Console.WriteLine("Grade entered is not valid.");
        //         break;
        // }


        




    }
}





