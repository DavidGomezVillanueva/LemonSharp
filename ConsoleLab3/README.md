1 - Read Books

Crea una función isBookRead que reciba una lista de libros y un título y devuelva si se ha leído o no dicho libro. Un libro es un objeto con title como string y isRead como booleano. En caso de no existir el libro devolver false.

public bool IsBookRead(Boook books, string titleToSearch)
{
    // Implementation here
}
Ejemplo
var books = new Book[] {
    new Book
    {
        Title = "Harry Potter y la piedra filosofal",
        IsRead = true
    },
    new Book
    {
        Title = "Canción de hielo y fuego",
        IsRead = false
    },
    new Book
    {
        Title = "Devastación",
        IsRead = true
    },
}; 

Console.WriteLine(IsBookRead(books, "Devastación")); // true
Console.WriteLine(IsBookRead(books, "Canción de hielo y fuego")); // false
Console.WriteLine(IsBookRead(books, "Los Pilares de la Tierra")); // false

![Ejercicio 1](./images/ej1.png)

2 - Slot Machine

El objetivo de este ejercicio es crear una máquina tragaperras utilizando clases donde cada vez que juguemos insertemos una moneda. Cada máquina tragaperras (instancia) tendrá un contador de monedas que automáticamente se irá incrementando conforme vayamos jugando.

Cuando se llame al método play el número de monedas se debe incrementar de forma automática y debe generar tres booleanos aleatorios que representarán el estado de las 3 ruletas. El usuario habrá ganado en caso de que los tres booleanos sean true, y por tanto deberá mostrarse por consola el mensaje:

"Congratulations!!!. You won <número de monedas> coins!!";
y reiniciar las monedas almacenadas, ya que las hemos conseguido y han salido de la máquina. En caso contrario deberá mostrar otro mensaje:

"Good luck next time!!".
Se preguntará al usuario si quiere jugar o dejar.

Si el usuario elige jugar. Se llamará al método play.
Si usuario elige cualquier otra opción se terminará la ejecución de la aplicación.

![Ejercicio 2](./images/ej2.png)