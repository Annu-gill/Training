using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Linq;

class AdventureWorks
{
    private const string ConnectionString =
        @"Data Source=ANNU\SQLEXPRESS01;
        Integrated Security=True;
        TrustServerCertificate=True;
        Initial Catalog=AdventureWorks2025;";

    public static void Main()
    {
        Console.WriteLine("===== ADO.NET + LINQ Demo =====\n");

        // ==========================================================
        // 1) CONNECTED MODE (SqlDataReader)
        // ==========================================================
        // Best for fast, forward-only reading
        // Connection stays open while reading

        /*
        using (var con = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(
            "SELECT StudentId, FullName, City, Marks FROM Students WHERE IsActive = 1", con))
        {
            con.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string city = reader.GetString(2);
                int marks = reader.GetInt32(3);

                Console.WriteLine($"{id} | {name} | {city} | {marks}");
            }
        }
        */

        // ==========================================================
        // 2) DISCONNECTED MODE (DataAdapter + DataTable)
        // ==========================================================
        // Data is loaded into memory
        // Connection closes after Fill()

        DataTable students = new();

        using (var con = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(
            "SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con))
        using (var adapter = new SqlDataAdapter(cmd))
        {
            con.Open();
            adapter.Fill(students);
        }

        Console.WriteLine("Rows loaded: " + students.Rows.Count);

        // ==========================================================
        // 3) PARAMETERIZED QUERY (Safe against SQL Injection)
        // ==========================================================

        /*
        string cityParam = "Chennai";

        using (var con = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(
            "SELECT FullName FROM Students WHERE City = @City", con))
        {
            cmd.Parameters.AddWithValue("@City", cityParam);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                Console.WriteLine(reader["FullName"]);
        }
        */

        // ==========================================================
        // 4) LINQ – WHERE + SELECT
        // ==========================================================

        var toppers = students.AsEnumerable()
            .Where(r => r.Field<int>("Marks") >= 80)
            .Select(r => new
            {
                Name = r.Field<string>("FullName"),
                Marks = r.Field<int>("Marks")
            })
            .ToList();

        Console.WriteLine("\n--- Students with Marks >= 80 ---");
        toppers.ForEach(x => Console.WriteLine($"{x.Name} - {x.Marks}"));


        // ==========================================================
        // 5) LINQ – ORDER BY
        // ==========================================================

        var sorted = students.AsEnumerable()
            .OrderByDescending(r => r.Field<int>("Marks"))
            .ThenBy(r => r.Field<string>("FullName"))
            .ToList();

        Console.WriteLine("\n--- Sorted by Marks Desc ---");
        foreach (var row in sorted)
            Console.WriteLine($"{row["FullName"]} - {row["Marks"]}");


        // ==========================================================
        // 6) LINQ – GROUP BY
        // ==========================================================

        var groupByCity = students.AsEnumerable()
            .GroupBy(r => r.Field<string>("City"))
            .Select(g => new
            {
                City = g.Key,
                Count = g.Count(),
                Avg = g.Average(x => x.Field<int>("Marks"))
            })
            .ToList();

        Console.WriteLine("\n--- Grouped by City ---");
        foreach (var g in groupByCity)
            Console.WriteLine($"{g.City} | Count={g.Count} | Avg={g.Avg:0.00}");


        // ==========================================================
        // 7) LINQ – AGGREGATES
        // ==========================================================

        int max = students.AsEnumerable().Max(r => r.Field<int>("Marks"));
        int min = students.AsEnumerable().Min(r => r.Field<int>("Marks"));
        double avg = students.AsEnumerable().Average(r => r.Field<int>("Marks"));

        Console.WriteLine($"\nMax={max}, Min={min}, Avg={avg:0.00}");


        // ==========================================================
        // 8) LINQ – ANY / ALL / FIRST
        // ==========================================================

        bool anyInactive = students.AsEnumerable()
            .Any(r => r.Field<bool>("IsActive") == false);

        var firstTopper = students.AsEnumerable()
            .Where(r => r.Field<int>("Marks") >= 90)
            .Select(r => r.Field<string>("FullName"))
            .FirstOrDefault();

        Console.WriteLine("\nAny inactive students? " + anyInactive);
        Console.WriteLine("First topper: " + firstTopper);


        // ==========================================================
        // 9) LINQ – PAGING (Skip / Take)
        // ==========================================================

        int pageNumber = 1;
        int pageSize = 3;

        var page = students.AsEnumerable()
            .OrderByDescending(r => r.Field<int>("Marks"))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        Console.WriteLine("\n--- Paging (Top 3) ---");
        foreach (var row in page)
            Console.WriteLine($"{row["FullName"]} - {row["Marks"]}");


        // ==========================================================
        // 10) CRUD OPERATIONS
        // ==========================================================

        // INSERT
        /*
        using (var con = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(
            "INSERT INTO Students (FullName, City, Marks, IsActive) VALUES (@Name,@City,@Marks,1)", con))
        {
            cmd.Parameters.AddWithValue("@Name", "Test User");
            cmd.Parameters.AddWithValue("@City", "Mumbai");
            cmd.Parameters.AddWithValue("@Marks", 70);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        */

        // UPDATE
        /*
        using (var con = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(
            "UPDATE Students SET Marks = @Marks WHERE StudentId = @Id", con))
        {
            cmd.Parameters.AddWithValue("@Marks", 85);
            cmd.Parameters.AddWithValue("@Id", 1);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        */

        // DELETE
        /*
        using (var con = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(
            "DELETE FROM Students WHERE StudentId = @Id", con))
        {
            cmd.Parameters.AddWithValue("@Id", 10);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        */


        // ==========================================================
        // 11) STORED PROCEDURE CALL
        // ==========================================================

        /*
        using (var con = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand("dbo.AddStudent", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FullName", "Stored Proc User");
            cmd.Parameters.AddWithValue("@City", "Delhi");
            cmd.Parameters.AddWithValue("@Marks", 88);

            con.Open();
            var newId = cmd.ExecuteScalar();
            Console.WriteLine("New Student ID: " + newId);
        }
        */


        // ==========================================================
        // 12) TRANSACTION (Commit / Rollback)
        // ==========================================================

        /*
        using (var con = new SqlConnection(ConnectionString))
        {
            con.Open();
            using var tx = con.BeginTransaction();

            try
            {
                var cmd1 = new SqlCommand(
                    "INSERT INTO Students (FullName, City, Marks, IsActive) VALUES ('TX User','Pune',80,1)",
                    con, tx);

                cmd1.ExecuteNonQuery();

                var cmd2 = new SqlCommand(
                    "UPDATE Students SET Marks = Marks + 1 WHERE StudentId = 1",
                    con, tx);

                cmd2.ExecuteNonQuery();

                tx.Commit();
                Console.WriteLine("Transaction Committed");
            }
            catch
            {
                tx.Rollback();
                Console.WriteLine("Transaction Rolled Back");
            }
        }
        */

        Console.WriteLine("\n===== END OF DEMO =====");
    }
}
