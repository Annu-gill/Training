using System;
using System.Collections.Generic;
using System.Globalization;

class ForensicReport
{
    // Holds Reporting Officer Name as Key and Report Filed Date as Value
    private Dictionary<string, DateTime> reportMap = new Dictionary<string, DateTime>();

    // Adds report details to the map
    public void addReportDetails(string reportingOfficerName, DateTime reportFiledDate)
    {
        reportMap[reportingOfficerName] = reportFiledDate;
    }

    // Returns list of officers who filed reports on the given date
    public List<string> getOfficersWhoFiledReportsOnDate(DateTime reportFiledDate)
    {
        List<string> officers = new List<string>();

        foreach (var report in reportMap)
        {
            if (report.Value.Date == reportFiledDate.Date)
            {
                officers.Add(report.Key);
            }
        }

        return officers;
    }
}

class UserInterface
{
    static void Main()
    {
        ForensicReport forensicReport = new ForensicReport();

        Console.WriteLine("Enter number of reports to be added");
        int numberOfReports = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Forensic reports (Reporting Officer: Report Filed Date)");

        for (int i = 0; i < numberOfReports; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            string officerName = parts[0].Trim();
            string dateString = parts[1].Trim();

            DateTime reportDate = DateTime.ParseExact(
                dateString,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture
            );

            forensicReport.addReportDetails(officerName, reportDate);
        }

        Console.WriteLine("Enter the filed date to identify the reporting officers");

        DateTime searchDate = DateTime.ParseExact(
            Console.ReadLine().Trim(),
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture
        );

        List<string> officers =
            forensicReport.getOfficersWhoFiledReportsOnDate(searchDate);

        if (officers.Count == 0)
        {
            Console.WriteLine("No reporting officer filed the report");
        }
        else
        {
            Console.WriteLine($"Reports filed on the {searchDate:yyyy-MM-dd} are by");
            foreach (string officer in officers)
            {
                Console.WriteLine(officer);
            }
        }
    }
}