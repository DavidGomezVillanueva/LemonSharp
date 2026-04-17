using System;
using System.Collections.Generic;
using System.Linq;

class ProgramSharp04
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Sex { get; set; }
        public double Temperature { get; set; }
        public int HeartRate { get; set; }
        public string? Specialty { get; set; }
        public int Age { get; set; }
    }

    public static List<Patient> ObtenerPediatricsmenorDe10(List<Patient> patients)
    {
        return patients.Where(p => p.Specialty == "pediatrics" && p.Age < 10).ToList();
    }

    public static bool ActivarProtocoloUrgencia(List<Patient> patients)
    {
        return patients.Any(p => p.HeartRate > 100 || p.Temperature > 39);
    }

    public static void ReasignarEspecialidad(List<Patient> patients, string desde, string hacia)
    {
        foreach (var paciente in patients.Where(p => p.Specialty == desde).ToList())
        {
            paciente.Specialty = hacia;
        }
    }

    public static Dictionary<string, int> ContarPacientesPorEspecialidad(List<Patient> patients)
    {
        return patients
            .Where(p => p.Specialty != null)
            .GroupBy(p => p.Specialty)
            .ToDictionary(g => g.Key!, g => g.Count());
    }

    public static List<(Patient Paciente, bool TienePrioridad)> ObtenerListaPrioridad(
        List<Patient> patients
    )
    {
        return patients.Select(p => (p, p.HeartRate > 100 || p.Temperature > 39)).ToList();
    }

    public static Dictionary<string, double> ObtenerEdadMediaPorEspecialidad(List<Patient> patients)
    {
        return patients
            .Where(p => p.Specialty != null)
            .GroupBy(p => p.Specialty)
            .ToDictionary(g => g.Key!, g => g.Average(p => p.Age));
    }

    static void MostrarPediatricsmenorDe10(List<Patient> patients)
    {
        Console.WriteLine("\n1. PACIENTES DE PEDIATRICS CON EDAD < 10 AÑOS:");
        var pediatricsPacientes = ObtenerPediatricsmenorDe10(patients);
        if (pediatricsPacientes.Any())
        {
            foreach (var p in pediatricsPacientes)
            {
                Console.WriteLine($"   - {p.Name} {p.Lastname} (Edad: {p.Age})");
            }
        }
        else
        {
            Console.WriteLine("   No hay pacientes en pediatrics menores de 10 años");
        }
    }

    static void MostrarProtocoloUrgencia(List<Patient> patients)
    {
        Console.WriteLine("\n2. PROTOCOLO DE URGENCIA:");
        bool urgenciaActivada = ActivarProtocoloUrgencia(patients);
        if (urgenciaActivada)
        {
            Console.WriteLine("   PROTOCOLO DE URGENCIA ACTIVADO");
            var pacientesUrgencia = patients
                .Where(p => p.HeartRate > 100 || p.Temperature > 39)
                .ToList();
            Console.WriteLine("   Pacientes con riesgo:");
            foreach (var p in pacientesUrgencia)
            {
                Console.WriteLine(
                    $"   - {p.Name} {p.Lastname} - HR: {p.HeartRate}, Temp: {p.Temperature}°C"
                );
            }
        }
        else
        {
            Console.WriteLine("   ✓ Todo normal, protocolo de urgencia NO activado");
        }
    }

    static void MostrarReasignacion(List<Patient> patients)
    {
        Console.WriteLine("\n3. REASIGNACIÓN DE ESPECIALIDADES:");
        Console.WriteLine("   Antes:");
        Console.WriteLine($"   - Pediatrics: {patients.Count(p => p.Specialty == "pediatrics")}");
        Console.WriteLine(
            $"   - General Medicine: {patients.Count(p => p.Specialty == "general medicine")}"
        );

        ReasignarEspecialidad(patients, "pediatrics", "general medicine");

        Console.WriteLine("   Después:");
        Console.WriteLine($"   - Pediatrics: {patients.Count(p => p.Specialty == "pediatrics")}");
        Console.WriteLine(
            $"   - General Medicine: {patients.Count(p => p.Specialty == "general medicine")}"
        );
    }

    static void MostrarConteoEspecialidades(List<Patient> patients)
    {
        Console.WriteLine("\n4. CONTEO DE PACIENTES POR ESPECIALIDAD:");
        var conteoEspecialidades = ContarPacientesPorEspecialidad(patients);
        foreach (var especialidad in conteoEspecialidades)
        {
            Console.WriteLine($"   - {especialidad.Key}: {especialidad.Value} pacientes");
        }
    }

    static void MostrarListaPrioridad(List<Patient> patients)
    {
        Console.WriteLine("\n5. PACIENTES CON INDICADOR DE PRIORIDAD:");
        var listaPrioridad = ObtenerListaPrioridad(patients);
        foreach (var item in listaPrioridad)
        {
            string prioridad = item.TienePrioridad ? "PRIORITARIO" : "✓ Normal";
            Console.WriteLine($"   - {item.Paciente.Name} {item.Paciente.Lastname}: {prioridad}");
        }
    }

    static void MostrarEdadMedia(List<Patient> patients)
    {
        Console.WriteLine("\n6. EDAD MEDIA POR ESPECIALIDAD:");
        var edadMedia = ObtenerEdadMediaPorEspecialidad(patients);
        foreach (var item in edadMedia)
        {
            Console.WriteLine($"   - {item.Key}: {item.Value:F2} años");
        }
    }

    static void Main(string[] args)
    {
        List<Patient> patients = new List<Patient>
        {
            new Patient
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Sex = "Male",
                Temperature = 36.8,
                HeartRate = 80,
                Specialty = "general medicine",
                Age = 44,
            },
            new Patient
            {
                Id = 2,
                Name = "Jane",
                Lastname = "Doe",
                Sex = "Female",
                Temperature = 36.8,
                HeartRate = 70,
                Specialty = "general medicine",
                Age = 43,
            },
            new Patient
            {
                Id = 3,
                Name = "Junior",
                Lastname = "Doe",
                Sex = "Male",
                Temperature = 36.8,
                HeartRate = 90,
                Specialty = "pediatrics",
                Age = 8,
            },
            new Patient
            {
                Id = 4,
                Name = "Mary",
                Lastname = "Wien",
                Sex = "Female",
                Temperature = 36.8,
                HeartRate = 120,
                Specialty = "general medicine",
                Age = 20,
            },
            new Patient
            {
                Id = 5,
                Name = "Scarlett",
                Lastname = "Somez",
                Sex = "Female",
                Temperature = 36.8,
                HeartRate = 110,
                Specialty = "general medicine",
                Age = 30,
            },
            new Patient
            {
                Id = 6,
                Name = "Brian",
                Lastname = "Kid",
                Sex = "Male",
                Temperature = 39.8,
                HeartRate = 80,
                Specialty = "pediatrics",
                Age = 11,
            },
        };

        Console.WriteLine("=== GESTIÓN DE PACIENTES ===");
        int option = -1;

        while (option != 0)
        {
            Console.WriteLine("\n\nQue consulta quieres ejecutar?");
            Console.WriteLine(" - 1 (Pacientes de pediatrics < 10 años)");
            Console.WriteLine(" - 2 (Protocolo de urgencia)");
            Console.WriteLine(" - 3 (Reasignar pediatrics a general medicine)");
            Console.WriteLine(" - 4 (Contar pacientes por especialidad)");
            Console.WriteLine(" - 5 (Pacientes con indicador de prioridad)");
            Console.WriteLine(" - 6 (Edad media por especialidad)");
            Console.WriteLine(" - 0 (Salir)\n ");
            option = int.TryParse(Console.ReadLine(), out int temp) ? temp : -1;

            while (option != 0 && (option < 1 || option > 6))
            {
                Console.WriteLine("Opción no válida. Intenta de nuevo.");
                Console.WriteLine("\nQue consulta quieres ejecutar?");
                Console.WriteLine(" - 1 (Pacientes de pediatrics < 10 años)");
                Console.WriteLine(" - 2 (Protocolo de urgencia)");
                Console.WriteLine(" - 3 (Reasignar pediatrics a general medicine)");
                Console.WriteLine(" - 4 (Contar pacientes por especialidad)");
                Console.WriteLine(" - 5 (Pacientes con indicador de prioridad)");
                Console.WriteLine(" - 6 (Edad media por especialidad)");
                Console.WriteLine(" - 0 (Salir)\n ");
                option = int.TryParse(Console.ReadLine(), out temp) ? temp : -1;
            }

            if (option == 1)
            {
                MostrarPediatricsmenorDe10(patients);
            }
            else if (option == 2)
            {
                MostrarProtocoloUrgencia(patients);
            }
            else if (option == 3)
            {
                MostrarReasignacion(patients);
            }
            else if (option == 4)
            {
                MostrarConteoEspecialidades(patients);
            }
            else if (option == 5)
            {
                MostrarListaPrioridad(patients);
            }
            else if (option == 6)
            {
                MostrarEdadMedia(patients);
            }
            else if (option == 0)
            {
                Console.WriteLine("\nSaliendo del programa...\n");
            }
        }
    }
}
