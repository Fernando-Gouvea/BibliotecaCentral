using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        public long IdCliente { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco endereco { get; set; }

        public override string ToString()
        {
            return "\nID: " + IdCliente
                  + "\nCPF: " + Cpf
                  + "\nNome: " + Nome
                  + "\nTelefone: " + Telefone
                  + "\nData de Nascimento: " + DataNascimento
                  + "\n\nEndereço " + endereco.ToString();
        }

        public string ToCsv()
        {
            return IdCliente+";"+Cpf+";"+Nome+";"+Telefone+";"+DataNascimento+";"+endereco.ToCsv();
        }
    }
}
