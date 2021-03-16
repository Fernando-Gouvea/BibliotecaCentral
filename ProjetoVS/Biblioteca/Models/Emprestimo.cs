using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Emprestimo
    {
        public Cliente cliente { get; set; }
        public Livro livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double multa { get; set; }
        public int StatusEmprestimo { get; set; }

        public override string ToString()
        {
            string status = "";
            if (StatusEmprestimo == 1)
            {
                status = "1 - Emprestado";

            }
            else
            {
                status = "2 - Devolvido";

            }
            return "\nCPF: " + cliente.Cpf
                + "\nTitulo do Livro: " + livro.Titulo
                + "\nStatus do Emprestimo: " + status
                + "\nData do Emprestimo: " + DataEmprestimo
                + "\nData da Devolucao: " + DataDevolucao;
        }
        public string ToCsv()
        {
            string status = "";
            if (StatusEmprestimo == 1)
            {
                status = "1 - Emprestado";

            }
            else
            {
                status = "2 - Devolvido";

            }
            return cliente.IdCliente + ";" + livro.NumeroTombo + ";"
                + DataEmprestimo + ";" + DataDevolucao + ";" + StatusEmprestimo;
        }

    }
}
