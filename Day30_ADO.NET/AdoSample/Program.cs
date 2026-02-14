//using Microsoft.Data.SqlClient;
//using System.Data;

//class Program
//{
//        static void Main()
//    {
//        string cs = "Data Source=ANNU\\SQLEXPRESS01;Integrated Security=True;TrustServerCertificate=True;Initial Catalog=TrainingDB";

//        //------------------List All Employees------------------

//        //string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

//        //using (var con = new SqlConnection(cs))
//        //using (var cmd = new SqlCommand(sql, con))
//        //{
//        //    con.Open();

//        //    using (var reader = cmd.ExecuteReader())
//        //    {
//        //        while (reader.Read())
//        //        {
//        //            int id = reader.GetInt32(0);
//        //            string name = reader.GetString(1);
//        //            string dept = reader.GetString(2);
//        //            decimal salary = reader.GetDecimal(3);

//        //            Console.WriteLine($"{id} | {name} | {dept} | {salary}");
//        //        }
//        //    }
//        //    con.Close();
//        //}

//        //------------------Search By Department Safely------------------

//        //Console.Write("Enter Department (e.g., IT): ");
//        //string dept = Console.ReadLine() ?? "";

//        //string sql = @"SELECT EmployeeId, FullName, Salary
//        //       FROM dbo.Employees
//        //       WHERE Department = @dept
//        //       ORDER BY Salary DESC";

//        //using var con = new SqlConnection(cs);
//        //using var cmd = new SqlCommand(sql, con);

//        //// Add parameter
//        //cmd.Parameters.AddWithValue("@dept", dept);

//        //con.Open();
//        //using var r = cmd.ExecuteReader();
//        //while (r.Read())
//        //{
//        //    Console.WriteLine($"{r["EmployeeId"]} | {r["FullName"]} | {r["Salary"]}");
//        //}
//        //con.Close();

//        //------------------Insert a New Employee------------------

//        //string sql = @"INSERT INTO dbo.Employees(FullName, Department, Salary)
//        //       VALUES (@name, @dept, @salary)";

//        //Console.Write("Name: "); string name = Console.ReadLine() ?? "";
//        //Console.Write("Dept: "); string dept = Console.ReadLine() ?? "";
//        //Console.Write("Salary: "); decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

//        //using var con = new SqlConnection(cs);
//        //using var cmd = new SqlCommand(sql, con);

//        //cmd.Parameters.AddWithValue("@name", name);
//        //cmd.Parameters.AddWithValue("@dept", dept);
//        //cmd.Parameters.AddWithValue("@salary", salary);

//        //con.Open();
//        //int rows = cmd.ExecuteNonQuery();

//        //Console.WriteLine(rows == 1 ? "Inserted" : "Not inserted");
//        //con.Close();


//        //------------------Update Employee------------------

//        //string sql = @"UPDATE dbo.Employees SET Salary=@salary WHERE EmployeeId=@id";

//        //Console.Write("EmployeeId: "); int id = int.Parse(Console.ReadLine() ?? "0");
//        //Console.Write("New Salary: "); decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

//        //using var con = new SqlConnection(cs);
//        //using var cmd = new SqlCommand(sql, con);

//        //cmd.Parameters.AddWithValue("@id", id);
//        //cmd.Parameters.AddWithValue("@salary", salary);

//        //con.Open();
//        //int rows = cmd.ExecuteNonQuery();

//        //Console.WriteLine($"Updated rows: {rows}");
//        //con.Close();


//        //------------------Delete Employee------------------

//        //string sql = @"DELETE FROM dbo.Employees WHERE EmployeeId=@id";

//        //Console.Write("EmployeeId to delete: "); int id = int.Parse(Console.ReadLine() ?? "0");

//        //using var con = new SqlConnection(cs);
//        //using var cmd = new SqlCommand(sql, con);

//        //cmd.Parameters.AddWithValue("@id", id);

//        //con.Open();
//        //int rows = cmd.ExecuteNonQuery();

//        //Console.WriteLine(rows == 1 ? "Deleted" : "Not found");
//        //con.Close();


//        //------------------ Saving dataset in xml file------------------


//        //string sql = "SELECT EmployeeId, FullName FROM dbo.Employees ORDER BY EmployeeId;" +
//        //     "SELECT Department, Salary FROM dbo.Employees ORDER BY EmployeeId";
//        //DataSet dataSet = new DataSet();
//        //using (var con = new SqlConnection(cs))
//        //using (var cmd = new SqlCommand(sql, con))
//        //{
//        //    con.Open();
//        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//        //    adapter.Fill(dataSet);
//        //}
//        //dataSet.WriteXml("Employee.xml");
//        //dataSet.Tables[0].WriteXml("Employee.json");
//        //dataSet.Tables[1].WriteXml("EmployeeDept.json");
//        //foreach (DataRow row in dataSet.Tables[0].Rows)
//        //{
//        //    Console.WriteLine($"{row["EmployeeId"]} | {row["FullName"]}");
//        //}
//        //foreach (DataRow row in dataSet.Tables[1].Rows)
//        //{
//        //    Console.WriteLine($"{row["Department"]} | {row["Salary"]}");
//        //}


//        // ------For Insert, Select, Update, Delete in Disconnected Style (CRUD Operations)------
//        SelectData(cs);
//        InsertData(cs);
//        UpdateData(cs);
//        DeleteData(cs);
//        SelectData(cs);


//    }
//    static void SelectData(string cs)
//    {
//        Console.WriteLine("\n=== SELECT (Reading Data) ===");
//        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
//        DataSet ds = new DataSet();

//        using (var con = new SqlConnection(cs))
//        using (var cmd = new SqlCommand(sql, con))
//        {
//            con.Open();
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            adapter.Fill(ds);
//        }

//        ds.WriteXml("TestData.xml");

//        foreach (DataRow row in ds.Tables[0].Rows)
//        {
//            Console.WriteLine($"ID: {row["EmployeeId"]}, Name: {row["FullName"]}, Dept: {row["Department"]}, Salary: {row["Salary"]}");
//        }
//    }

//    static void InsertData(string cs)
//    {
//        Console.WriteLine("\n=== INSERT (Adding New Record) ===");
//        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
//        DataSet ds = new DataSet();

//        using (var con = new SqlConnection(cs))
//        {
//            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

//            adapter.Fill(ds, "Employees");

//            // Add new row to DataTable
//            DataTable table = ds.Tables["Employees"];
//            DataRow newRow = table.NewRow();
//            newRow["FullName"] = "John Doe";
//            newRow["Department"] = "IT";
//            newRow["Salary"] = 60000;
//            table.Rows.Add(newRow);

//            // Update database
//            int rows = adapter.Update(ds, "Employees");
//            Console.WriteLine($"{rows} row(s) inserted");
//        }
//    }

//    static void UpdateData(string cs)
//    {
//        Console.WriteLine("\n=== UPDATE (Modifying Existing Record) ===");
//        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
//        DataSet ds = new DataSet();

//        using (var con = new SqlConnection(cs))
//        {
//            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

//            adapter.Fill(ds, "Employees");

//            DataTable table = ds.Tables["Employees"];

//            // Update first row (if exists)
//            if (table.Rows.Count > 0)
//            {
//                DataRow row = table.Rows[0];
//                Console.WriteLine($"Updating: {row["FullName"]} - Old Salary: {row["Salary"]}");
//                row["Salary"] = Convert.ToDecimal(row["Salary"]) + 5000;
//                Console.WriteLine($"New Salary: {row["Salary"]}");
//            }

//            // Update database
//            int rows = adapter.Update(ds, "Employees");
//            Console.WriteLine($"{rows} row(s) updated");
//        }
//    }

//    static void DeleteData(string cs)
//    {
//        Console.WriteLine("\n=== DELETE (Removing Record) ===");
//        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees WHERE FullName = 'John Doe'";
//        DataSet ds = new DataSet();

//        using (var con = new SqlConnection(cs))
//        {
//            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

//            adapter.Fill(ds, "Employees");

//            DataTable table = ds.Tables["Employees"];

//            // Delete all rows that match (John Doe)
//            if (table.Rows.Count > 0)
//            {
//                foreach (DataRow row in table.Rows)
//                {
//                    Console.WriteLine($"Deleting: {row["FullName"]} from {row["Department"]}");
//                    row.Delete();
//                }
//            }

//            // Update database
//            int rows = adapter.Update(ds, "Employees");
//            Console.WriteLine($"{rows} row(s) deleted");
//        }
//    }
//}




using Microsoft.Data.SqlClient;
using System;
using System.Data;

class Program
{
    private const string ConnectionString =
        @"Data Source=ANNU\\SQLEXPRESS01;
        Integrated Security=True;
        TrustServerCertificate=True;
        Initial Catalog=TrainingDB";


    static void Main()
    {
        // ================= CONNECTED MODE =================

        PrintAllEmployees_Connected();
        InsertEmployee_Connected("John Connected", "IT", 60000);
        UpdateEmployeeSalary_Connected(1, 75000);
        DeleteEmployee_Connected(3);
        PrintAllEmployees_Connected();


        // ================= DISCONNECTED MODE =================

        /*
        PrintAllEmployees_Disconnected();
        InsertEmployee_Disconnected("John Disconnected", "HR", 55000);
        UpdateEmployeeSalary_Disconnected(1, 80000);
        DeleteEmployee_Disconnected(4);
        PrintAllEmployees_Disconnected();
        */
    }

    // ===================== CONNECTED MODE =======================

    static void PrintAllEmployees_Connected()
    {
        const string sql =
            @"SELECT EmployeeId, FullName, Department, Salary
              FROM dbo.Employees
              ORDER BY EmployeeId";

        using var con = new SqlConnection(ConnectionString);
        using var cmd = new SqlCommand(sql, con);

        con.Open();
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("\n=== CONNECTED: Employees ===");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader.GetInt32(0)} | " +
                $"{reader.GetString(1)} | " +
                $"{reader.GetString(2)} | " +
                $"{reader.GetDecimal(3)}");
        }
    }

    static void InsertEmployee_Connected(string name, string dept, decimal salary)
    {
        const string sql =
            @"INSERT INTO dbo.Employees (FullName, Department, Salary)
              VALUES (@name, @dept, @salary)";

        using var con = new SqlConnection(ConnectionString);
        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@dept", dept);
        cmd.Parameters.AddWithValue("@salary", salary);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("\nCONNECTED: Inserted");
    }

    static void UpdateEmployeeSalary_Connected(int id, decimal newSalary)
    {
        const string sql =
            @"UPDATE dbo.Employees
              SET Salary = @salary
              WHERE EmployeeId = @id";

        using var con = new SqlConnection(ConnectionString);
        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@salary", newSalary);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("\nCONNECTED: Updated");
    }

    static void DeleteEmployee_Connected(int id)
    {
        const string sql =
            @"DELETE FROM dbo.Employees
              WHERE EmployeeId = @id";

        using var con = new SqlConnection(ConnectionString);
        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("\nCONNECTED: Deleted");
    }

    // =================== DISCONNECTED MODE ======================

    static void PrintAllEmployees_Disconnected()
    {
        DataTable table = GetEmployeesTable();

        Console.WriteLine("\n=== DISCONNECTED: Employees ===");

        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine(
                $"{row["EmployeeId"]} | " +
                $"{row["FullName"]} | " +
                $"{row["Department"]} | " +
                $"{row["Salary"]}");
        }
    }

    static void InsertEmployee_Disconnected(string name, string dept, decimal salary)
    {
        using var adapter = CreateAdapter();
        DataTable table = GetEmployeesTable(adapter);

        DataRow newRow = table.NewRow();
        newRow["FullName"] = name;
        newRow["Department"] = dept;
        newRow["Salary"] = salary;
        table.Rows.Add(newRow);

        adapter.Update(table);

        Console.WriteLine("\nDISCONNECTED: Inserted");
    }

    static void UpdateEmployeeSalary_Disconnected(int id, decimal newSalary)
    {
        using var adapter = CreateAdapter();
        DataTable table = GetEmployeesTable(adapter);

        DataRow? row = table.Rows.Find(id);
        if (row != null)
        {
            row["Salary"] = newSalary;
            adapter.Update(table);
            Console.WriteLine("\nDISCONNECTED: Updated");
        }
    }

    static void DeleteEmployee_Disconnected(int id)
    {
        using var adapter = CreateAdapter();
        DataTable table = GetEmployeesTable(adapter);

        DataRow? row = table.Rows.Find(id);
        if (row != null)
        {
            row.Delete();
            adapter.Update(table);
            Console.WriteLine("\nDISCONNECTED: Deleted");
        }
    }

    // ================= HELPER METHODS =================

    static SqlDataAdapter CreateAdapter()
    {
        const string sql =
            @"SELECT EmployeeId, FullName, Department, Salary
              FROM dbo.Employees";

        var adapter = new SqlDataAdapter(sql, ConnectionString);
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        new SqlCommandBuilder(adapter);

        return adapter;
    }

    static DataTable GetEmployeesTable(SqlDataAdapter? adapter = null)
    {
        adapter ??= CreateAdapter();

        DataTable table = new DataTable();
        adapter.Fill(table);

        return table;
    }
}

