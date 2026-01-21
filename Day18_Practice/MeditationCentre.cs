// Question 4: 

using System;
using System.Collections;

namespace Day18_Practice
{
    public class MeditationCenter
    {
        // Properties
        public int MemberId { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Goal { get; set; }
        public double BMI { get; set; }

        // Provided ArrayList
        public static ArrayList memberList = new ArrayList();

        // Add Yoga Member
        public static void AddYogaMember(int memberId, int age, double weight, double height, string goal)
        {
            MeditationCenter member = new MeditationCenter
            {
                MemberId = memberId,
                Age = age,
                Weight = weight,
                Height = height,
                Goal = goal
            };

            memberList.Add(member);
        }

        // Calculate BMI
        public static double CalculateBMI(int memberId)
        {
            foreach (MeditationCenter member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    double bmi = member.Weight / (member.Height * member.Height);
                    bmi = Math.Floor(bmi * 100) / 100; // two decimal places
                    member.BMI = bmi;
                    return bmi;
                }
            }
            return 0;
        }

        // Calculate Yoga Fee
        public static int CalculateYogaFee(int memberId)
        {
            foreach (MeditationCenter member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    if (member.Goal.Equals("Weight Loss", StringComparison.OrdinalIgnoreCase))
                    {
                        if (member.BMI >= 25 && member.BMI < 30)
                            return 2000;
                        else if (member.BMI >= 30 && member.BMI < 35)
                            return 2500;
                        else if (member.BMI >= 35)
                            return 3000;
                    }
                    else if (member.Goal.Equals("Weight Gain", StringComparison.OrdinalIgnoreCase))
                    {
                        return 2500;
                    }
                }
            }
            return 0;
        }
    }
}

