using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public override string ToString()
        {
            return "\nLogradouro: " + Logradouro
                + "\nBairro: " + Bairro
                + "\nCidade: " + Cidade
                + "\nEstado: " + Estado
                + "\nCEP: " + Cep;
        }

        public string ToCsv()
        {
            return Logradouro+";"+Bairro+";"+Cidade+";"+Estado+";"+Cep;
        }
    }


   
}