using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

/// <summary>
/// Stores forensic report details and finds officers by report date.
/// </summary>
class ForensicReport
{
    // Holds Reporting Officer Name as Key and Report Filed Date as Value
    private readonly Dictionary<string, DateTime> reports = [];
    // Adds report details to the map
    public void AddReport(string officerName, DateTime filedDate)
    {
        reports[officerName] = filedDate;
    }
    // Returns list of officers who filed reports on the given date
    public List<string> GetOfficersByDate(DateTime date)
    {
        return reports
            .Where(r => r.Value.Date == date.Date)
            .Select(r => r.Key)
            .ToList();
    }
}

class Program
{
    public static void Main()
    {
        ForensicReport report = new();

        Console.WriteLine("Enter number of reports:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter reports (Officer : yyyy-MM-dd)");
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(':');
            string officer = input[0].Trim();
            DateTime date = DateTime.Parse(input[1].Trim());
            report.AddReport(officer, date);
        }

        Console.WriteLine("Enter date to search (yyyy-MM-dd):");
        DateTime searchDate = DateTime.Parse(Console.ReadLine().Trim());

        List<string> officers = report.GetOfficersByDate(searchDate);

        if (officers.Count == 0)
        {
            Console.WriteLine("No reporting officer filed the report");
        }
        else
        {
            Console.WriteLine($"Reports filed on {searchDate:yyyy-MM-dd} are by:");
            foreach (string officer in officers)
            {
                Console.WriteLine(officer);
            }
        }
    }
}