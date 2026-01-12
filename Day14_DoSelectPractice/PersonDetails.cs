using System.Runtime.InteropServices;

namespace Day14_DoSelectPractice
{
    public class Person
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
    }

    public class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            string result = "";
            foreach (var p in person)
            {
                result += p.Name + " " + p.Address + " ";
            }
            return result;
        }
        public double Average(IList<Person> person)
        {
            if (person == null || person.Count == 0) return 0;

            double sum = 0;
            foreach (var p in person)
            {
                sum += p.Age;
            }
            return sum / person.Count;
        }
        public int Max(IList<Person> person)
        {
            if (person == null || person.Count == 0) return 0;

            int maxAge = 0;
            foreach (var p in person)
            {
                if (p.Age > maxAge)
                {
                    maxAge = p.Age;
                }
            }
            return maxAge;
        }
    }

    public class PersonDetails
    {
        public static void Main()
        {
            IList<Person> p = [];
            p.Add(new Person {Name = "Aarya", Address = "19C", Age=23});
            p.Add(new Person {Name = "Pratham", Address = "19B", Age=22});
            PersonImplementation imp = new();
            Console.WriteLine(imp.GetName(p));
            Console.WriteLine(imp.Average(p));
            Console.WriteLine(imp.Max(p));
        }
    }
}



