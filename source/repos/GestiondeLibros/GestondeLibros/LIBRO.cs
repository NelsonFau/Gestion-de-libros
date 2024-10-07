using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestondeLibros
{
    public class LIBRO
    {
        public int ID { get; private set; }
        
        private static int contadorId = 0;

        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int anioPublicacion { get; set; }


        public LIBRO(string titulo, string autor, int anio)
        {
            Titulo = titulo;
            Autor = autor;
            anioPublicacion = anio;
            contadorId++;
            ID = contadorId;
        }
        public LIBRO(int id)
        {
            ID = id;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Título: {Titulo}, Autor: {Autor}, Año: {anioPublicacion}";
        }

    }
}
