using System;

// Calculate profit or loss percentage
static class ProfitLoss
{
    public static void Execute()
    {
        Console.Write("Enter Cost Price: ");
        double cp = double.Parse(Console.ReadLine());
        Console.Write("Enter Selling Price: ");
        double sp = double.Parse(Console.ReadLine());

        if (sp > cp)
            Console.WriteLine("Profit % = " + ((sp - cp) / cp) * 100);
        else
            Console.WriteLine("Loss % = " + ((cp - sp) / cp) * 100);
    }
}
