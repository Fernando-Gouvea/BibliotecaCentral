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
            return IdCliente + ";" + Cpf + ";" + Nome + ";" + Telefone + ";" + DataNascimento + ";" + endereco.ToCsv();
        }

        public bool validaCPF(string cpfCliente)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpfCliente = cpfCliente.Trim();
            cpfCliente = cpfCliente.Replace(".", "").Replace("-", "");

            if (cpfCliente.Length != 11)
                return false;

            tempCpf = cpfCliente.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpfCliente.EndsWith(digito);

        }
    }
}
