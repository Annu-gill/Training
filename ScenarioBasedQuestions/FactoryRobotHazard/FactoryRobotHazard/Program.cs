using System;

/// <summary>
/// Custom exception class used to handle robot safety validation errors.
/// </summary>
public class RobotSafetyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the RobotSafetyException class
    /// with a specific error message.
    /// </summary>
    public RobotSafetyException(string message) : base(message)
    {
    }
}

public class RobotHazardAuditor
{
    /// <summary>
    /// Calculates and returns the hazard risk score of a factory robot
    /// based on arm precision, worker density, and machinery state.
    /// </summary>
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validate arm precision range
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");
        }

        // Validate worker density range
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        double machineRiskFactor;

        // Determine machine risk factor based on machinery state
        if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Calculate hazard risk using the given formula
        double hazardRisk =
            ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);

        return hazardRisk;
    }
}

public class Program
{
    /// <summary>
    /// Entry point of the Factory Robot Hazard Analyzer application.
    /// Reads user input, invokes hazard calculation, and displays results.
    /// </summary>
    public static void Main()
    {
        try
        {
            // Read arm precision input
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = double.Parse(Console.ReadLine());

            // Read worker density input
            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = int.Parse(Console.ReadLine());

            // Read machinery state input
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            // Create auditor object
            RobotHazardAuditor auditor = new RobotHazardAuditor();

            // Calculate hazard risk
            double risk = auditor.CalculateHazardRisk(
                armPrecision, workerDensity, machineryState);

            // Display result
            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }
        catch (RobotSafetyException ex)
        {
            // Display custom exception message
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            // Handle unexpected runtime errors
            Console.WriteLine("Invalid input format");
        }
    }
}
