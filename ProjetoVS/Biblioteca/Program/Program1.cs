using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Program
{
    class Program1
    {
        static void Main(string[] args)
        {

            int op;
            string path = @"C:\Users\ferna\Google Drive\Estagio Five\Repositorio\ProjetoBibliotecaComunitaria\";
            List<Livro> listLivro = new List<Livro>();
            Livro livro = new Livro();
            List<Cliente> listCliente = new List<Cliente>();
            Cliente cliente = new Cliente { endereco = new Endereco { } };
            OperadorArquivo OperadorArquivo = new OperadorArquivo(path);
            listCliente = OperadorArquivo.Leitor(cliente);
            do
            {

                MenuPrincipal();

                if (int.TryParse(Console.ReadLine(), out op)) { }

                switch (op)
                {
                    case 1:
                        int id = listCliente.Count;
                        listCliente.Add(MenuCadastroCliente(cliente, id));

                        break;

                    case 2:
                        int idLivro = listLivro.Count;
                        MenuCadastroLivro(livro, idLivro);
                        break;
                    case 3:
                        MenuEmprestimoLivro();
                        break;
                    case 4:
                        MenuDevolucaoLivro();
                        break;
                    case 5:
                        MenuRelatorio(listCliente);

                        break;
                }

                Console.ReadKey();
            }
            while (true);

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
        static Cliente MenuCadastroCliente(Cliente cliente, int id)
        {

            bool teste = false;

            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|   Cadastro de Cliente  |");
            Console.WriteLine("--------------------------");
            id++;
            cliente.IdCliente = id;
            Console.WriteLine("Cliente numero: " + cliente.IdCliente);
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
            Console.WriteLine("Digite o Telefone: ");
            cliente.Telefone = CampoVazioString();
            Console.WriteLine("\nDados do endereco do cliente");
            Console.WriteLine("Digite Logradouro: ");
            cliente.endereco.Logradouro = CampoVazioString();
            Console.WriteLine("Digite o Bairro: ");
            cliente.endereco.Bairro = CampoVazioString();
            Console.WriteLine("Digite a cidade: ");
            cliente.endereco.Cidade = CampoVazioString();
            Console.WriteLine("Digite o estado: ");
            cliente.endereco.Estado = CampoVazioString();
            Console.WriteLine("Digite o CEP: ");
            cliente.endereco.Cep = CampoVazioString();

            return cliente;

        }

        static Livro MenuCadastroLivro(Livro livro, int idLivro)
        {
            bool teste = false;

            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|    Cadastro de Livro   |");
            Console.WriteLine("--------------------------");

            idLivro++;
            livro.NumeroTombo = idLivro;
           
            Console.WriteLine("Digite o ISBN: ");
            livro.ISBN = CampoVazioString();
            Console.WriteLine("Digite o Titulo: ");
            livro.Titulo = CampoVazioString();
            Console.WriteLine("Digite o genero: ");
            livro.Genero = CampoVazioString();
            do
            {
                DateTime dataPublicacao;
                Console.Write("Data de publicacao (dd/mm/aaaa): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataPublicacao))
                {
                    teste = true;
                    livro.DataPublicacao = dataPublicacao;
                }
            }
            while (!teste);
            Console.WriteLine("Digite o Autor: ");
            livro.Autor = CampoVazioString();

            Console.WriteLine("Atencao: Coloque o numero tag no exemplar");
            Console.WriteLine("Numero tombo: " + livro.NumeroTombo);

            return livro;

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

        static void MenuRelatorio(List<Cliente> listCliente)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|        Relatório       |");
            Console.WriteLine("| Emprestimo e Devolução |");
            Console.WriteLine("|        de Livros       |");
            Console.WriteLine("--------------------------");

            listCliente.ForEach(i => Console.WriteLine(i.ToString()));
            Console.ReadKey();


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
