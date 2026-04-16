using System;

public class GuessException : Exception
{
    public GuessException(string message)
        : base(message) { }
}

class ProgramCSharp02
{
    protected void Ejercicio1()
    {
        try
        {
            Random random = new Random();
            int numero = random.Next(0, 101);
            Console.WriteLine("Adivina el número entre 0 y 100. Tienes 10 intentos.");
            int intentos = 10;
            bool adivinado = false;
            while (intentos > 0 && !adivinado)
            {
                Console.Write("Ingresa un número: ");
                int jugador;
                if (!int.TryParse(Console.ReadLine(), out jugador))
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                    continue;
                }
                try
                {
                    if (jugador == numero)
                    {
                        Console.WriteLine("¡Felicidades! Has adivinado el número.");
                        adivinado = true;
                    }
                    else if (jugador > 100 || jugador < 0)
                    {
                        throw new GuessException("El número debe estar entre 0 y 100.");
                    }
                    else if (jugador > numero)
                    {
                        throw new GuessException("El número es más pequeño.");
                    }
                    else
                    {
                        throw new GuessException("El número es más grande.");
                    }
                }
                catch (GuessException ex)
                {
                    Console.WriteLine(ex.Message);
                    intentos--;
                    if (intentos > 0)
                    {
                        Console.WriteLine("Te quedan {0} intentos.", intentos);
                    }
                }
            }
            if (!adivinado)
            {
                Console.WriteLine("Lo siento, has agotado tus intentos. El número era: " + numero);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
        }
    }

    static void Main(string[] args)
    {
        ProgramCSharp02 program = new ProgramCSharp02();
        program.Ejercicio1();
    }
}
