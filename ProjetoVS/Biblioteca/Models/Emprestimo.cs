using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Emprestimo
    {
        public  Cliente cliente { get; set; }
        public Livro livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int StatusEmprestimo { get; set; }

      
    }
}
