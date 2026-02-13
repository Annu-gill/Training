using System;

// Custom exception
public class InvalidCreditDataException : Exception
{
    public InvalidCreditDataException(string message) : base(message)
    {
    }
}

// Utility class
public class CreditRiskProcessor
{
    // Validation method
    public static bool ValidateCustomerDetails(
        int age,
        string employmentType,
        double monthlyIncome,
        double dues,
        int creditScore,
        int defaults)
    {
        if (age < 21 || age > 65)
            throw new InvalidCreditDataException("Invalid age");

        if (employmentType != "Salaried" && employmentType != "Self-Employed")
            throw new InvalidCreditDataException("Invalid employment type");

        if (monthlyIncome < 20000)
            throw new InvalidCreditDataException("Invalid monthly income");

        if (dues < 0)
            throw new InvalidCreditDataException("Invalid credit dues");

        if (creditScore < 300 || creditScore > 900)
            throw new InvalidCreditDataException("Invalid credit score");

        if (defaults < 0)
            throw new InvalidCreditDataException("Invalid default count");

        return true;
    }

    // Credit limit calculation
    public static double CalculateCreditLimit(
        double monthlyIncome,
        double dues,
        int creditScore,
        int defaults)
        {
        double debtRatio = dues / (monthlyIncome * 12);

        // High Risk
        if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
            return 50000;

        // Medium Risk
        if ((creditScore >= 600 && creditScore <= 749) || (defaults == 1 || defaults == 2))
            return 150000;

        // Low Risk
        if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            return 300000;

        // Default fallback
        return 50000;
    }
}

// User interface class
public class UserInterface
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter employment type: ");
            string employmentType = Console.ReadLine();

            Console.Write("Enter monthly income: ");
            double income = double.Parse(Console.ReadLine());

            Console.Write("Enter existing credit dues: ");
            double dues = double.Parse(Console.ReadLine());

            Console.Write("Enter credit score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter number of loan defaults: ");
            int defaults = int.Parse(Console.ReadLine());

            // Validation
            CreditRiskProcessor.ValidateCustomerDetails(
                age, employmentType, income, dues, creditScore, defaults);

            // Credit limit calculation
            double creditLimit = CreditRiskProcessor.CalculateCreditLimit(
                income, dues, creditScore, defaults);

            Console.WriteLine("Customer Name: " + name);
            Console.WriteLine("Approved Credit Limit: ₹" + creditLimit);
        }
        catch (InvalidCreditDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input format");
        }
    }
}
