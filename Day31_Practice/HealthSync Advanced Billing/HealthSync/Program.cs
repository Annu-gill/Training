using System;

// 🔹 Abstract Base Class (Abstraction)
public abstract class Consultant
{
    public string ConsultantId { get; set; }

    // Constructor
    public Consultant(string id)
    {
        if (!ValidateConsultantId(id))
        {
            Console.WriteLine("Invalid doctor id");
            Environment.Exit(0);   // terminate process
        }
        ConsultantId = id;
    }

    // Validation method
    public bool ValidateConsultantId(string id)
    {
        if (id.Length != 6) return false;
        if (!id.StartsWith("DR")) return false;

        for (int i = 2; i < 6; i++)
        {
            if (!char.IsDigit(id[i]))
                return false;
        }
        return true;
    }

    // Abstract method (must be overridden)
    public abstract double CalculateGrossPayout();

    // 🔹 Virtual Tax method
    public virtual double CalculateTDS(double gross)
    {
        if (gross <= 5000)
            return gross * 0.05;
        else
            return gross * 0.15;
    }

    // Common payout display
    public void DisplayPayout()
    {
        double gross = CalculateGrossPayout();
        double tds = CalculateTDS(gross);
        double net = gross - tds;

        double rate = (tds / gross) * 100;

        Console.WriteLine($"Gross: {gross:F2} | TDS Applied: {rate}% | Net Payout: {net:F2}");
    }
}


// 🔹 In-House Consultant (Polymorphism)
public class InHouseConsultant : Consultant
{
    public double MonthlyStipend { get; set; }

    public InHouseConsultant(string id, double stipend) : base(id)
    {
        MonthlyStipend = stipend;
    }

    public override double CalculateGrossPayout()
    {
        double allowances = 2000;
        double bonus = 1000;
        return MonthlyStipend + allowances + bonus;
    }
}


// 🔹 Visiting Consultant (Overrides Tax Logic)
public class VisitingConsultant : Consultant
{
    public int ConsultationCount { get; set; }
    public double RatePerVisit { get; set; }

    public VisitingConsultant(string id, int count, double rate) : base(id)
    {
        ConsultationCount = count;
        RatePerVisit = rate;
    }

    public override double CalculateGrossPayout()
    {
        return ConsultationCount * RatePerVisit;
    }

    // Override virtual tax
    public override double CalculateTDS(double gross)
    {
        return gross * 0.10; // flat 10%
    }
}


// 🔹 Main Program
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Consultant Type (1-InHouse, 2-Visiting): ");
        int type = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Consultant ID: ");
        string id = Console.ReadLine();

        if (type == 1)
        {
            Console.WriteLine("Enter Monthly Stipend: ");
            double stipend = double.Parse(Console.ReadLine());

            Consultant c = new InHouseConsultant(id, stipend);
            c.DisplayPayout();
        }
        else if (type == 2)
        {
            Console.WriteLine("Enter Consultation Count: ");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Rate per Visit: ");
            double rate = double.Parse(Console.ReadLine());

            Consultant c = new VisitingConsultant(id, count, rate);
            c.DisplayPayout();
        }
        else
        {
            Console.WriteLine("Invalid type");
        }
    }
}
