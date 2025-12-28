using System;

// OOPS Concept -> Overloading of Constructor && Changing Namespace

class Visitor
{
    private int id;
    private string name;
    private string requirement;

    public string LogHistory { get; private set; }

    public int Id
    {
        get => id;
        set
        {
            if (value <= 0)
                throw new Exception("Invalid Id");
            id = value;
        }
    }

    public string Name
    {
        get => name;
        set
        {
            if (value.ToLower().Contains("idiot"))
                throw new Exception("Invalid name...");
            name = value;
        }
    }

    public string Requirement
    {
        get => requirement;
        set => requirement = value;
    }

    public Visitor()
    {
        LogHistory = $"Object created at {DateTime.Now}\n";
    }

    public Visitor(int id) : this()
    {
        Id = id;
        LogHistory += $"Id created at {DateTime.Now}\n";
    }

    public Visitor(int id, string name) : this(id)
    {
        Name = name;
        LogHistory += $"Name created at {DateTime.Now}\n";
    }

    public Visitor(int id, string name, string requirement) : this(id, name)
    {
        Requirement = requirement;
        LogHistory += $"Requirement created at {DateTime.Now}\n";
    }
}
