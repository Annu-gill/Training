using System;
using System.IO;

class FileReader
{
    public static void Main()
    {
        string filePath = "data.txt";

        try
        {
            // 1. Read file content (resource safely handled)
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
        }
        catch (FileNotFoundException)
        {
            // 2. Handle file not found exception
            Console.WriteLine("Error: File not found.");
        }
        catch (UnauthorizedAccessException)
        {
            // 3. Handle unauthorized access exception
            Console.WriteLine("Error: Access denied to the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            // 4. Ensure resource is closed properly
            // (Handled automatically by 'using' block)
            Console.WriteLine("File operation completed.");
        }
    }
}
