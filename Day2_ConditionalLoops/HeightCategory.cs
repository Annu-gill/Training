using System;

// Height Category: Accept height in cm. If < 150 (Dwarf), 150-165 (Average), 165-190 (Tall), >190 (Abnormal).
static class HeightCategory
{
    public static void Execute()
    {
        Console.Write("Enter height in cm: ");
        int height = Convert.ToInt32(Console.ReadLine());

        if (height < 150)
            Console.WriteLine("Dwarf");
        else if (height >= 150 && height < 165)
            Console.WriteLine("Average");
        else if (height >= 165 && height <= 190)
            Console.WriteLine("Tall");
        else
            Console.WriteLine("Abnormal");
    }
}
