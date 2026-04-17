using System;

class ProgramSharp03
{
    public class Book
    {
        public required string Title { get; set; }
        public bool IsRead { get; set; }
    }

    public static bool IsBookRead(Book[] books, string titleToSearch)
    {
        while (books != null)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(titleToSearch, StringComparison.OrdinalIgnoreCase))
                {
                    if (book.IsRead)
                    {
                        Console.WriteLine("El libro " + book.Title + " ha sido leído.");
                    }
                    else
                    {
                        Console.WriteLine("El libro " + book.Title + " no ha sido leído.");
                    }
                    return book.IsRead;
                }
            }
            break;
        }
        Console.WriteLine("El libro " + titleToSearch + " no se encontró.");
        return false;
    }

    public class SlotMachine()
    {
        static Random random = new Random();
        bool rnd1,
            rnd2,
            rnd3;
        int coins = 0;
        int i = 1;

        public void Spin()
        {
            i = 1;
            while (i != 0)
            {
                rnd1 = random.Next(2) == 1;
                rnd2 = random.Next(2) == 1;
                rnd3 = random.Next(2) == 1;
                if (rnd1 && rnd2 && rnd3)
                {
                    coins++;
                    Console.WriteLine("\n\nrnd1: " + rnd1);
                    Console.WriteLine("rnd2: " + rnd2);
                    Console.WriteLine("rnd3: " + rnd3);
                    Console.WriteLine("Congratulations!!! you won " + coins + " coins!!!\n\n");
                    coins = 0;
                    Console.WriteLine("\n\nDo you want to play again? \n - 1 (yes)\n - 0 (no)\n ");
                    i = int.TryParse(Console.ReadLine(), out int temp) ? temp : 1;
                }
                else
                {
                    coins++;
                    Console.WriteLine("\n\nrnd1: " + rnd1);
                    Console.WriteLine("rnd2: " + rnd2);
                    Console.WriteLine("rnd3: " + rnd3);
                    Console.WriteLine("Good luck next time!!\n\n");
                    Console.WriteLine(
                        "\n\nDo you want to play again? \n - Enter (yes)\n - 0 (no)\n "
                    );
                    i = int.TryParse(Console.ReadLine(), out int temp) ? temp : 1;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Que ejercicio quieres ejecutar? \n - 1\n - 2\n - 0 (salir)\n ");
        int.TryParse(Console.ReadLine(), out int exerciseNumber);

        var books = new Book[]
        {
            new Book { Title = "juego de tronos", IsRead = true },
            new Book { Title = "Cien Años de Soledad", IsRead = false },
            new Book { Title = "La Sombra del Viento", IsRead = true },
            new Book { Title = "El Alquimista", IsRead = false },
            new Book { Title = "El Principito", IsRead = true },
            new Book { Title = "Don Quijote de la Mancha", IsRead = false },
        };

        while (exerciseNumber != 0)
        {
            // Console.WriteLine(exerciseNumber);
            if (exerciseNumber == 1)
            {
                foreach (var book in books)
                {
                    Console.WriteLine(IsBookRead(books, book.Title) + "\n");
                }
                Console.WriteLine(IsBookRead(books, "El nombre del viento"));
                Console.WriteLine(
                    "\n\nQue ejercicio quieres ejecutar? \n - 1\n - 2\n - 0 (salir)\n "
                );
                exerciseNumber = int.TryParse(Console.ReadLine(), out int temp) ? temp : 1;
                // int.TryParse(Console.ReadLine(), out exerciseNumber);
            }
            else if (exerciseNumber == 2)
            {
                int slotMachineChoice = -1;
                SlotMachine slotMachine = new SlotMachine();
                SlotMachine slotMachine2 = new SlotMachine();
                Console.WriteLine("Que slot machine quieres jugar? \n - 1\n - 2\n - 0 (salir)\n ");
                slotMachineChoice = int.TryParse(Console.ReadLine(), out int temp) ? temp : 1;

                while (slotMachineChoice != 0)
                {
                    if (slotMachineChoice == 1)
                    {
                        slotMachine.Spin();
                    }
                    else if (slotMachineChoice == 2)
                    {
                        slotMachine2.Spin();
                    }
                    else
                    {
                        Console.WriteLine("Número de slot machine no válido.");
                    }
                    Console.WriteLine(
                        "Que slot machine quieres jugar? \n - 1\n - 2\n - 0 (salir)\n "
                    );
                    slotMachineChoice = int.TryParse(Console.ReadLine(), out int tempo) ? tempo : 1;
                }

                Console.WriteLine("Saliendo del juego...\n");
                Console.WriteLine(
                    "\n\nQue ejercicio quieres ejecutar? \n - 1\n - 2\n - 0 (salir)\n "
                );
                exerciseNumber = int.TryParse(Console.ReadLine(), out temp) ? temp : 1;
            }
            else
            {
                Console.WriteLine("Número de ejercicio no válido.");
                Console.WriteLine(
                    "\n\n Que ejercicio quieres ejecutar? \n - 1\n - 2\n - 0 (salir)\n "
                );
                exerciseNumber = int.TryParse(Console.ReadLine(), out int temp) ? temp : 1;
            }
        }
    }
}
