using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem
{
    // ===================== Patient Class =====================
    public class Patient
    {
        public int PatientId { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public List<string> MedicalHistory { get; set; }

        public Patient(int id, string name, int age, string bloodGroup)
        {
            PatientId = id;
            Name = name;
            Age = age;
            BloodGroup = bloodGroup;
            MedicalHistory = new List<string>();
        }
    }

    // ===================== Doctor Class =====================
    public class Doctor
    {
        public int DoctorId { get; private set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<DateTime> AvailableSlots { get; set; }

        public Doctor(int id, string name, string specialization)
        {
            DoctorId = id;
            Name = name;
            Specialization = specialization;
            AvailableSlots = new List<DateTime>();
        }
    }

    // ===================== Appointment Class =====================
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; } // Scheduled / Completed / Cancelled
    }

    // ===================== Hospital Manager =====================
    public class HospitalManager
    {
        private readonly List<Patient> patients = new List<Patient>();
        private readonly List<Doctor> doctors = new List<Doctor>();
        private readonly List<Appointment> appointments = new List<Appointment>();

        private int nextPatientId = 1;
        private int nextDoctorId = 1;
        private int nextAppointmentId = 1;

        // Add Patient
        public void AddPatient(string name, int age, string bloodGroup)
        {
            if (age <= 0)
                throw new ArgumentException("Invalid age.");

            patients.Add(new Patient(nextPatientId++, name, age, bloodGroup));
        }

        // Add Doctor
        public void AddDoctor(string name, string specialization)
        {
            doctors.Add(new Doctor(nextDoctorId++, name, specialization));
        }

        // Schedule Appointment
        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            Patient patient = patients.FirstOrDefault(p => p.PatientId == patientId);
            Doctor doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);

            if (patient == null || doctor == null)
                return false;

            // Check if doctor already has appointment at that time
            bool slotTaken = appointments.Any(a =>
                a.DoctorId == doctorId &&
                a.AppointmentTime == time &&
                a.Status == "Scheduled");

            if (slotTaken)
                return false;

            appointments.Add(new Appointment
            {
                AppointmentId = nextAppointmentId++,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentTime = time,
                Status = "Scheduled"
            });

            return true;
        }

        // Group Doctors by Specialization
        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return doctors
                .GroupBy(d => d.Specialization)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get Today's Appointments
        public List<Appointment> GetTodayAppointments()
        {
            DateTime today = DateTime.Today;
            return appointments
                .Where(a => a.AppointmentTime.Date == today && a.Status == "Scheduled")
                .OrderBy(a => a.AppointmentTime)
                .ToList();
        }

        // Add Medical History
        public void AddMedicalHistory(int patientId, string record)
        {
            Patient patient = patients.FirstOrDefault(p => p.PatientId == patientId);
            if (patient != null)
                patient.MedicalHistory.Add(record);
        }

        public List<Patient> GetAllPatients() => patients;
        public List<Doctor> GetAllDoctors() => doctors;
    }

    // ===================== Program Class =====================
    class Program
    {
        public static void Main()
        {
            HospitalManager manager = new HospitalManager();

            while (true)
            {
                Console.WriteLine("\n===== Hospital Patient Management =====");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Schedule Appointment");
                Console.WriteLine("4. View Doctors by Specialization");
                Console.WriteLine("5. Today's Appointments");
                Console.WriteLine("6. Add Medical History");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Patient Name: ");
                            string pname = Console.ReadLine();

                            Console.Write("Age: ");
                            int age = int.Parse(Console.ReadLine());

                            Console.Write("Blood Group: ");
                            string bg = Console.ReadLine();

                            manager.AddPatient(pname, age, bg);
                            Console.WriteLine("Patient registered successfully.");
                            break;

                        case 2:
                            Console.Write("Doctor Name: ");
                            string dname = Console.ReadLine();

                            Console.Write("Specialization: ");
                            string spec = Console.ReadLine();

                            manager.AddDoctor(dname, spec);
                            Console.WriteLine("Doctor added successfully.");
                            break;

                        case 3:
                            Console.Write("Patient ID: ");
                            int pid = int.Parse(Console.ReadLine());

                            Console.Write("Doctor ID: ");
                            int did = int.Parse(Console.ReadLine());

                            Console.Write("Appointment Time (yyyy-MM-dd HH:mm): ");
                            DateTime time = DateTime.Parse(Console.ReadLine());

                            bool scheduled = manager.ScheduleAppointment(pid, did, time);
                            Console.WriteLine(scheduled
                                ? "Appointment scheduled."
                                : "Scheduling failed (invalid ID or slot unavailable).");
                            break;

                        case 4:
                            var grouped = manager.GroupDoctorsBySpecialization();
                            foreach (var group in grouped)
                            {
                                Console.WriteLine($"\n{group.Key} Doctors:");
                                foreach (var doc in group.Value)
                                {
                                    Console.WriteLine($"ID: {doc.DoctorId}, Name: {doc.Name}");
                                }
                            }
                            break;

                        case 5:
                            var todayAppointments = manager.GetTodayAppointments();
                            foreach (var a in todayAppointments)
                            {
                                Console.WriteLine($"Appointment ID: {a.AppointmentId}, Patient ID: {a.PatientId}, Doctor ID: {a.DoctorId}, Time: {a.AppointmentTime}");
                            }
                            break;

                        case 6:
                            Console.Write("Patient ID: ");
                            int mid = int.Parse(Console.ReadLine());

                            Console.Write("Medical Record: ");
                            string record = Console.ReadLine();

                            manager.AddMedicalHistory(mid, record);
                            Console.WriteLine("Medical history updated.");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
