using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Emprestimo
    {
        public  Cliente cliente  { get; set; }
        public Livro livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int StatusEmprestimo { get; set; }

        public override string ToString()
        {
            string status="", dataDevolucao="";
            if (StatusEmprestimo == 1)
            {
                status = "1 - Emprestado";
                dataDevolucao = "Pendente";
            }
            else
            {
                status = "2 - Devolvido";
                dataDevolucao = DataDevolucao.ToString();
            }
            return "\nCPF: "+ cliente.Cpf
                +"\nTitulo do Livro: "+ livro.Titulo
                +"\nStatus do Emprestimo: "+ status
                +"\nData do Emprestimo: "+ DataEmprestimo
                +"\nData da Devolucao: "+ dataDevolucao;
        }

    }
}
