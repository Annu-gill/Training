using System;

public class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message)
    {
    }
}

public class GadgetValidatorUtil
{
    // Validate Gadget ID
    public bool validateGadgetID(string gadgetID)
    {
        if (gadgetID.Length != 4)
            throw new InvalidGadgetException("Invalid gadget ID");

        if (!char.IsUpper(gadgetID[0]))
            throw new InvalidGadgetException("Invalid gadget ID");

        for (int i = 1; i < 4; i++)
        {
            if (!char.IsDigit(gadgetID[i]))
                throw new InvalidGadgetException("Invalid gadget ID");
        }

        return true;
    }

    // Validate Warranty Period
    public bool validateWarrantyPeriod(int period)
    {
        if (period < 6 || period > 36)
            throw new InvalidGadgetException("Invalid warranty period");

        return true;
    }
}

public class UserInterface
{
    public static void Main()
    {
        GadgetValidatorUtil validator = new GadgetValidatorUtil();

        Console.WriteLine("Enter the number of gadget entries");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter gadget {i} details");
            string input = Console.ReadLine();

            try
            {
                string[] parts = input.Split(':');

                string gadgetID = parts[0];
                int warrantyPeriod = int.Parse(parts[2]);

                validator.validateGadgetID(gadgetID);
                validator.validateWarrantyPeriod(warrantyPeriod);

                Console.WriteLine("Warranty accepted, stock updated");
            }
            catch (InvalidGadgetException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}