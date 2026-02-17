using System;
using System.Collections.Generic;
using System.Linq;

// ================= BASE =================
public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

// ================= 1. GENERIC PRIORITY QUEUE =================
public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();

    public void Enqueue(T patient, int priority)
    {
        if (patient == null)
            throw new ArgumentNullException("Patient cannot be null");

        if (priority < 1 || priority > 5)
            throw new ArgumentException("Priority must be between 1 and 5");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    public T Dequeue()
    {
        foreach (var kv in _queues.OrderBy(p => p.Key))
        {
            if (kv.Value.Count > 0)
                return kv.Value.Dequeue();
        }
        throw new InvalidOperationException("Queue is empty");
    }

    public T Peek()
    {
        foreach (var kv in _queues.OrderBy(p => p.Key))
        {
            if (kv.Value.Count > 0)
                return kv.Value.Peek();
        }
        throw new InvalidOperationException("Queue is empty");
    }

    public int GetCountByPriority(int priority)
    {
        if (_queues.ContainsKey(priority))
            return _queues[priority].Count;

        return 0;
    }
}

// ================= 2. MEDICAL RECORD =================
public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    private List<(DateTime, string)> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient ?? throw new ArgumentNullException();
    }

    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(diagnosis))
            throw new ArgumentException("Invalid diagnosis");

        _diagnoses.Add((date, diagnosis));
    }

    public void AddTreatment(string treatment, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(treatment))
            throw new ArgumentException("Invalid treatment");

        _treatments[date] = treatment;
    }

    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        return _treatments.OrderBy(t => t.Key);
    }
}

// ================= 3. SPECIALIZED PATIENTS =================
public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; }
}

// ================= 4. MEDICATION SYSTEM =================
public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

    public void PrescribeMedication(T patient, string medication, Func<T, bool> dosageValidator)
    {
        if (patient == null || string.IsNullOrWhiteSpace(medication))
            throw new ArgumentException("Invalid medication");

        if (!dosageValidator(patient))
        {
            Console.WriteLine($"Dosage validation failed for {patient.Name}");
            return;
        }

        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        _medications[patient].Add((medication, DateTime.Now));

        Console.WriteLine($"Medication prescribed: {medication} -> {patient.Name}");
    }

    public bool CheckInteractions(T patient, string newMedication)
    {
        if (!_medications.ContainsKey(patient))
            return false;

        // Simple demo interaction rule
        var riskyPairs = new Dictionary<string, string>
        {
            { "Aspirin", "Warfarin" },
            { "Ibuprofen", "Steroids" }
        };

        foreach (var m in _medications[patient])
        {
            if ((riskyPairs.ContainsKey(m.medication) && riskyPairs[m.medication] == newMedication) ||
                (riskyPairs.ContainsKey(newMedication) && riskyPairs[newMedication] == m.medication))
            {
                return true;
            }
        }
        return false;
    }
}

// ================= 5. TEST SCENARIO =================
class Program
{
    static void Main()
    {
        // Patients
        var p1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Riya",
            DateOfBirth = new DateTime(2018, 5, 1),
            BloodType = BloodType.A,
            GuardianName = "Mohan",
            Weight = 18
        };

        var p2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Arjun",
            DateOfBirth = new DateTime(2017, 7, 10),
            BloodType = BloodType.O,
            GuardianName = "Ravi",
            Weight = 22
        };

        var g1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Mr Singh",
            DateOfBirth = new DateTime(1945, 2, 10),
            BloodType = BloodType.B,
            MobilityScore = 5
        };

        var g2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Mrs Kaur",
            DateOfBirth = new DateTime(1940, 8, 20),
            BloodType = BloodType.AB,
            MobilityScore = 3
        };

        // Priority queue
        var queue = new PriorityQueue<IPatient>();
        queue.Enqueue(g1, 1);
        queue.Enqueue(p1, 3);
        queue.Enqueue(g2, 2);
        queue.Enqueue(p2, 4);

        Console.WriteLine("Next Patient: " + queue.Peek().Name);

        // Medical record
        var record = new MedicalRecord<IPatient>(g1);
        record.AddDiagnosis("Hypertension", DateTime.Now.AddDays(-10));
        record.AddTreatment("Blood Pressure Control", DateTime.Now.AddDays(-5));

        Console.WriteLine("\nTreatment History:");
        foreach (var t in record.GetTreatmentHistory())
            Console.WriteLine($"{t.Key} -> {t.Value}");

        // Medication system
        var medSystem = new MedicationSystem<IPatient>();

        // Pediatric dosage rule (weight > 15)
        medSystem.PrescribeMedication(p1, "Ibuprofen", p =>
        {
            if (p is PediatricPatient ped)
                return ped.Weight > 15;
            return true;
        });

        // Geriatric rule (mobility score > 2)
        medSystem.PrescribeMedication(g1, "Aspirin", p =>
        {
            if (p is GeriatricPatient ger)
                return ger.MobilityScore > 2;
            return true;
        });

        // Interaction check
        bool interaction = medSystem.CheckInteractions(g1, "Warfarin");
        Console.WriteLine($"\nDrug interaction detected: {interaction}");

        // Process patients by priority
        Console.WriteLine("\nPriority Processing:");
        while (true)
        {
            try
            {
                var next = queue.Dequeue();
                Console.WriteLine($"Treating: {next.Name}");
            }
            catch
            {
                break;
            }
        }
    }
}
