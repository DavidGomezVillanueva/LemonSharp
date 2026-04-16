using System;

class ProgramCSharp01
{
    //EJERCICIO 1:
    protected void Ejercicio1()
    {
        Console.Write("\n\nIngrese su nombre: ");
        string? nombre = Console.ReadLine();
        Console.Write("Ingrese su edad: ");
        int.TryParse(Console.ReadLine(), out int edad);
        Console.Write("Ingrese el nombre de una ciudad: ");
        string? ciudad = Console.ReadLine();
        Console.WriteLine(
            "\nTe llamas " + nombre + " y tienes " + edad + " años. Bienvenido a " + ciudad
        );
        Console.ReadLine();
    }

    // EJERCICIO 2:
    protected void Ejercicio2()
    {
        Console.Write("\n\nEscriba su primer numero: ");
        int.TryParse(Console.ReadLine(), out int num1);
        Console.Write("Escriba su segundo numero: ");
        int.TryParse(Console.ReadLine(), out int num2);
        if (num1 > num2)
        {
            Console.WriteLine("El " + num1 + " es el mayor");
        }
        else if (num2 > num1)
        {
            Console.WriteLine("El " + num2 + " es el mayor");
        }
        else
            Console.WriteLine("\nSon iguales");
        Console.ReadLine();
    }

    // EJERCICIO 3:
    protected void Ejercicio3()
    {
        Console.Write("\n\nDime el nombre del dia de la semana: ");
        string? dia = Console.ReadLine()?.ToLower();
        if (
            (dia != null)
            && (
                dia == "lunes"
                || dia == "martes"
                || dia == "miercoles"
                || dia == "jueves"
                || dia == "viernes"
            )
        )
        {
            Console.WriteLine("\nNo es fin de semana");
        }
        else if (dia == "sabado" || dia == "domingo")
        {
            Console.WriteLine("\nEs fin de semana");
        }
        else
        {
            Console.WriteLine("\nEse dia no existe");
        }
        Console.ReadLine();
    }

    // EJERCICIO 4:
    protected void Ejercicio4()
    {
        int i = 0;
        Console.WriteLine("\n\n");
        while (++i <= 100)
            if ((i % 2) == 0)
                Console.WriteLine(i);
        Console.ReadLine();
    }

    // EJERCICIO 5:
    protected void Ejercicio5()
    {
        Random rnd = new Random();
        Console.Write("\n\nCuantos numeros aleatorios quieres: ");
        int.TryParse(Console.ReadLine(), out int count);
        int i = -1;
        Console.Write("\n");
        while (++i < count)
        {
            int num = rnd.Next(1, 1000);
            if ((i + 1) == count)
                Console.Write(num + "\n");
            else
                Console.Write(num + ", ");
        }
        Console.ReadLine();
    }

    // EJERCICIO 6:
    protected void Ejercicio6()
    {
        Console.Write("\n\nEscriba un número de filas: ");
        int.TryParse(Console.ReadLine(), out int filas);
        Console.Write("Escriba un caracter: ");
        string? input = Console.ReadLine();
        char c = !string.IsNullOrEmpty(input) ? input[0] : '*';
        if (filas <= 0)
        {
            Console.WriteLine("\nDebe ingresar un número de filas mayor que 0.");
            Console.ReadLine();
            return;
        }
        Console.WriteLine();
        int i = 0;
        while (++i <= filas)
        {
            if (i == 1)
            {
                Console.WriteLine(c);
            }
            else if (i == filas)
            {
                Console.WriteLine(new string(c, filas));
            }
            else
            {
                Console.Write(c);
                Console.Write(new string(' ', i - 2));
                Console.WriteLine(c);
            }
        }
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        ProgramCSharp01 program = new ProgramCSharp01();
        Console.Write(
            "¿Que ejercicio desea ejecutar? \n - 1\n - 2\n - 3\n - 4\n - 5\n - 6\n - 0 (salir) \n\n ->"
        );
        string? ej = Console.ReadLine();
        while (ej != "0")
        {
            if (ej == "1")
            {
                program.Ejercicio1();
                ej = " ";
            }
            else if (ej == "2")
            {
                program.Ejercicio2();
                ej = " ";
            }
            else if (ej == "3")
            {
                program.Ejercicio3();
                ej = " ";
            }
            else if (ej == "4")
            {
                program.Ejercicio4();
                ej = " ";
            }
            else if (ej == "5")
            {
                program.Ejercicio5();
                ej = " ";
            }
            else if (ej == "6")
            {
                program.Ejercicio6();
                ej = " ";
            }
            else
            {
                Console.Write(
                    "\n\n¿Que ejercicio desea ejecutar? \n - 1\n - 2\n - 3\n - 4\n - 5\n - 6\n - 0 (salir) \n\n ->"
                );
                ej = Console.ReadLine();
            }
        }
    }
}
