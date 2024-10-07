
using GestondeLibros;
using System.Collections.Generic;
using System.Runtime.InteropServices;

List<LIBRO> listaLibros = new List<LIBRO>();

bool salir = false;

while (!false)
{
    Console.Clear();
    Console.WriteLine("Bienvenido a Gestion de Libros");
    Console.WriteLine("");
    Console.WriteLine("1. Ingresa los datos del libro.");
    Console.WriteLine("2. Listar todos los libros ingresados.");
    Console.WriteLine("3. Eliminar un libro por ID o título.");
    Console.WriteLine("4. Filtrar libros por año de publicación.");
    Console.WriteLine("5. Salir del programa.");
    Console.WriteLine("");
    Console.Write("Ingrese la opción deseada; ");

    string? entrada = Console.ReadLine();
    if (int.TryParse(entrada, out int opcion))
    {
        switch (opcion)
        {
            case 1:
                ingresarDatos();
                break;
            case 2:
                listarDatos();
                break;
            case 3:
                eliminarLibro();
                break;
            case 4:
                filtroAño();
                break;
            case 5:
                salir = true;
                break;
            default:
                Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                Console.ReadKey();
                break;
        }
    } else {
        Console.WriteLine("Por favor, ingrese un número válido. Presione una tecla para continuar.");
        Console.ReadKey();
    }

void ingresarDatos()
{
    Console.Clear();
    Console.WriteLine("Ingresar los datos del libro:");
    
    string? titulo;
    do
    {
        Console.Write("Ingrese el Titulo: ");
        titulo = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(titulo))
        {
          Console.WriteLine("No puede estar vacía o contener espacios en blanco.Intente de nuevo.");
        }
        
    } while (string.IsNullOrWhiteSpace(titulo)); // Repetir mientras sea nula o vacía
    string? autor;
    do
    {
        Console.Write("Ingrese el Autor: ");
        autor = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(autor))
        {
            Console.WriteLine("El autor no puede estar vacío o contener solo espacios en blanco.Intente de nuevo.");
        }
    } while (string.IsNullOrWhiteSpace(autor));
    int anio;
    string? anioTexto;
    do
    {
        Console.Write("Ingrese el año: ");
        anioTexto = Console.ReadLine();
        if (!int.TryParse(anioTexto, out anio))
        {
            Console.WriteLine("Por favor, ingrese un año válido ");
        }
    } while (!int.TryParse(anioTexto, out anio));
   
    
    LIBRO nuevoLibro = new LIBRO(titulo!, autor!, anio);
    listaLibros.Add(nuevoLibro);
    Console.WriteLine("Libro ingresada con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}
}


void listarDatos()
{
    Console.Clear();
    Console.WriteLine("Listado de Libros:");
    if (listaLibros.Count == 0)
    {
        Console.WriteLine("No hay libros ingresadas.");
    }
    else
    {
        foreach (var libro in listaLibros)
        {
            Console.WriteLine(libro);
        }
    }
    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}


void eliminarLibro()
{
    Console.Clear();
    int id;
    string? idString;
    do
    {
        Console.Write("Ingrese el ID: ");
        idString = Console.ReadLine();
        if (!int.TryParse(idString, out id))
        {
            Console.WriteLine("Por favor, ingrese un id válido ");
        }
    } while (!int.TryParse(idString, out id));

    var eliminarLibro = listaLibros.FirstOrDefault(libro=> libro.ID  == id);
   
    if (eliminarLibro != null)
    {
        listaLibros.Remove(eliminarLibro);
        Console.WriteLine($"El libro con ID {id} ha sido eliminado.");
    }
    else
    {
        Console.WriteLine($"No se encontró un libro con ID {id}.");
    }
}

void filtroAño()
{
    Console.Clear();
    int anio;
    string? anioString;
    do
    {
        Console.Write("Ingrese el año: ");
        anioString = Console.ReadLine();
        if (!int.TryParse(anioString, out anio))
        {
            Console.WriteLine("Por favor, ingrese un año válido ");
        }
    } while (!int.TryParse(anioString, out anio));

    var librosFiltrados = listaLibros.Where(libro => libro.anioPublicacion == anio).ToList();

    if (librosFiltrados.Count > 0)
    {
        Console.WriteLine($"Libros encontrados en el año {anio}:");
        foreach (var libro in librosFiltrados)
        {
            Console.WriteLine(libro); 
        }
    }
    else
    {
        Console.WriteLine($"No se encontró un libro con el año {anio}.");
    }

    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}
