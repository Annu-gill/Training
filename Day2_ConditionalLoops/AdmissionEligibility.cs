using System;

// Admission Eligibility based on marks
static class AdmissionEligibility
{
    public static void Execute()
    {
        Console.Write("Math marks: ");
        int math = Convert.ToInt32(Console.ReadLine());

        Console.Write("Physics marks: ");
        int physics = Convert.ToInt32(Console.ReadLine());

        Console.Write("Chemistry marks: ");
        int chemistry = Convert.ToInt32(Console.ReadLine());

        int total = math + physics + chemistry;

        if (math >= 65 && physics >= 55 && chemistry >= 50 &&
            (total >= 180 || (math + physics) >= 140))
            Console.WriteLine("Eligible for admission");
        else
            Console.WriteLine("Not eligible for admission");
    }
}
