using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            string path = @"C:\Users\ferna\Google Drive\Estagio Five\Repositorio\ProjetoBibliotecaComunitaria\"; 
            List<Livro> listLivro = new List<Livro>();
            List<Cliente> listCliente = new List<Cliente>();
            Cliente cliente = new Cliente();
            OperadorArquivo OperadorArquivo = new OperadorArquivo(path);
            listCliente = OperadorArquivo.Leitor();


            MenuPrincipal();

            if (int.TryParse(Console.ReadLine(), out op)) ;

            switch (op)
            {
                case '1':
                   
                    listCliente.Add(MenuCadastroCliente(cliente));

                    break;

                case '2':
                    MenuCadastroLivro();
                    break;
                case '3':
                    MenuEmprestimoLivro();
                    break;
                case '4':
                    MenuDevolucaoLivro();
                    break;
                case '5':
                    MenuRelatorio();
                    break;
            }

        }

        static void MenuPrincipal()
        {


            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1- Cadastro de cliente");
            Console.WriteLine("2- Cadastro de livro");
            Console.WriteLine("3- Emprestimo de livro");
            Console.WriteLine("4- Devolução de livro");
            Console.WriteLine("5- Relatorio de emprestimos e devoluções");


        }
        static Cliente MenuCadastroCliente(Cliente cliente)
        {
            
            bool teste = false;
            
            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|   Cadastro de Cliente  |");
            Console.WriteLine("--------------------------");
           
            cliente.IdCliente++;
            Console.WriteLine("Cliente numero"+ cliente.IdCliente);
            Console.WriteLine("Digite o CPF: ");
            cliente.Cpf = CampoVazioString();
            Console.WriteLine("Digite o Nome: ");
            cliente.Nome = CampoVazioString();
            do
            {
                DateTime nascimento;
                Console.Write("Data de nascimento (dd/mm/aaaa): ");
                if (DateTime.TryParse(Console.ReadLine(), out nascimento))
                {
                    teste = true;
                    cliente.DataNascimento = nascimento;
                }
            }
            while (!teste);

            cliente.Telefone = CampoVazioString();
            cliente.endereco.Logradouro = CampoVazioString();
            cliente.endereco.Bairro = CampoVazioString();
            cliente.endereco.Cidade = CampoVazioString();
            cliente.endereco.Estado = CampoVazioString();
            cliente.endereco.Cep = CampoVazioString();

            return cliente;

        }

        static void MenuCadastroLivro()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|    Cadastro de Livro   |");
            Console.WriteLine("--------------------------");
        }
        static void MenuEmprestimoLivro()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|   Emprestimo de Livro  |");
            Console.WriteLine("--------------------------");
        }
        static void MenuDevolucaoLivro()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|   Devolução  de Livro  |");
            Console.WriteLine("--------------------------");
        }

        static void MenuRelatorio()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|        Relatório       |");
            Console.WriteLine("| Emprestimo e Devolução |");
            Console.WriteLine("|        de Livros       |");
            Console.WriteLine("--------------------------");
        }

        static public string CampoVazioString()
        {
            string tratamento;
            do
            {
                tratamento = Console.ReadLine();
                if (tratamento == "") Console.WriteLine(" Por favor não deixe o campo vazio. Digite novamente");
            }
            while (tratamento == "");

            return tratamento;
        }
    }
}
