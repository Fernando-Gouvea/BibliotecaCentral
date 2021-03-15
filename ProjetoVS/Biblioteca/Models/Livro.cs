using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Livro
    {
        public long NumeroTombo { get; set; }
        public string ISBN { get; set; }
        public string  Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }

        public override string ToString()
        {
            return "\nNumero Tombo: "+NumeroTombo
                +"\nISBN: "+ISBN
                +"\nTitulo: "+Titulo
                +"\nGenero: "+Genero
                +"\nData da publicacao: "+DataPublicacao
                +"\nAutor: "+ Autor;
        }
    }


}
