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
            List<Emprestimo> listEmprestimo = new List<Emprestimo>();
            Emprestimo emprestimo = new Emprestimo();

            List<Livro> listLivro = new List<Livro>();
            Livro livro = new Livro();

            List<Cliente> listCliente = new List<Cliente>();
            Cliente cliente = new Cliente { endereco = new Endereco { } };

            OperadorArquivo OperadorArquivo = new OperadorArquivo(path);
            listCliente = OperadorArquivo.LeitorCliente(cliente);
            listLivro = OperadorArquivo.LeitorLivro(livro);
            listEmprestimo = OperadorArquivo.LeitorEmprestimo(emprestimo, listCliente, listLivro);

            do
            {
                MenuPrincipal();

                if (int.TryParse(Console.ReadLine(), out op)) { }

                switch (op)
                {
                    case 1:
                        int id = listCliente.Count;
                        cliente = MenuCadastroCliente(listCliente, id);

                        if (cliente != null)
                        {
                            listCliente.Add(cliente);
                            OperadorArquivo.SalvaCliente(listCliente);
                        }
                        break;

                    case 2:
                        int idLivro = listLivro.Count;
                        livro = MenuCadastroLivro(listLivro, idLivro);

                        if (livro != null)
                        {
                            listLivro.Add(livro);
                            OperadorArquivo.SalvaLivro(listLivro);
                        }
                        break;

                    case 3:
                        emprestimo = MenuEmprestimoLivro(emprestimo, listCliente, listLivro);
                        if (emprestimo.cliente != null)
                        {
                            listEmprestimo.Add(emprestimo);
                            OperadorArquivo.SalvaEmprestimo(listEmprestimo);

                        }
                        break;

                    case 4:
                        MenuDevolucaoLivro(listEmprestimo, listLivro);
                        OperadorArquivo.SalvaEmprestimo(listEmprestimo);
                        break;
                    case 5:
                        MenuRelatorio();
                        listEmprestimo.ForEach(i => Console.WriteLine(i.ToString()));
                        break;
                }
                Console.ReadKey();
                Console.Clear();
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
        static Cliente MenuCadastroCliente(List<Cliente> listCliente, int id)
        {
            bool teste = false, testeCPF = false, clienteExistente = false;
            string CPF = "";

            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|   Cadastro de Cliente  |");
            Console.WriteLine("--------------------------");
            id++;
            Cliente cliente = new Cliente { endereco = new Endereco { } };
            cliente.IdCliente = id;

            Console.WriteLine("Cliente numero: " + cliente.IdCliente);
            do
            {
                Console.WriteLine("Digite o CPF: ");
                CPF = CampoVazioString();
                testeCPF = cliente.validaCPF(CPF);
                clienteExistente = listCliente.Exists(x => x.Cpf.Contains(CPF));
                if (testeCPF)
                    if (!clienteExistente) cliente.Cpf = CPF;
                    else
                    {
                        Console.WriteLine("Cliente existente!!!");
                        return cliente = null;
                    }
                else Console.WriteLine("\nCPF invalido!!!");
            }
            while (!testeCPF);
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

        static Livro MenuCadastroLivro(List<Livro> listLivro, int idLivro)
        {
            bool teste = false, testISBN = false;

            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|    Cadastro de Livro   |");
            Console.WriteLine("--------------------------");

            idLivro++;
            Livro livro = new Livro();
            livro.NumeroTombo = idLivro;

            Console.WriteLine("Digite o ISBN: ");
            string ISBN = CampoVazioString();

            testISBN = listLivro.Exists(x => x.ISBN.Contains(ISBN));

            if (!testISBN) livro.ISBN = ISBN;
            else
            {
                Console.WriteLine("Livro existente!!!");
                return livro = null;
            }

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

            Console.WriteLine("\nAtencao!!!! Coloque a tag no exemplar");
            Console.WriteLine("Numero tombo: " + livro.NumeroTombo);
            Console.WriteLine("<<<<Pressione enter para voltar ao menu principal>>>>");

            return livro;

        }
        static Emprestimo MenuEmprestimoLivro(Emprestimo emprestimo, List<Cliente> listCliente, List<Livro> listLivro)
        {
            bool findLivro = false, findCPF = false;
            long nTombo = 0;
            string CPF = "";
            int sair = 1;
            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|   Emprestimo de Livro  |");
            Console.WriteLine("--------------------------");

            do
            {
                Console.WriteLine("Digite o NumeroTombo do exemplar: ");
                long.TryParse(Console.ReadLine(), out nTombo);

                findLivro = listLivro.Exists(x => x.NumeroTombo == nTombo);
                if (findLivro)
                {
                    emprestimo.livro = listLivro.Find(x => x.NumeroTombo == nTombo);
                    sair = 0;
                }
                else
                {
                    Console.WriteLine("Livro indisponivel para emprestimo!!! entre com outro NumeroTombo.");
                    Console.WriteLine("Deseja voltar ao menu principal? 0 - Sim , 1 - Nao");
                    int.TryParse(Console.ReadLine(), out sair);
                    if (sair == 0) return emprestimo;

                }
            }
            while (sair != 0);

            sair = 1;

            do
            {
                Console.WriteLine("Digite o CPF do cliente: ");
                CPF = Console.ReadLine();

                findCPF = listCliente.Exists(x => x.Cpf.Contains(CPF));
                if (findCPF)
                {
                    emprestimo.cliente = listCliente.Find(x => x.Cpf.Contains(CPF));
                    emprestimo.StatusEmprestimo = 1;
                    emprestimo.DataEmprestimo = DateTime.Now;
                    bool teste = false;
                    do
                    {
                        DateTime dataDevolucao;
                        Console.Write("Data de devolucao (dd/mm/aaaa): ");
                        if (DateTime.TryParse(Console.ReadLine(), out dataDevolucao))
                        {
                            string dDevolucao = dataDevolucao.ToString();
                            string dataAtual = DateTime.Now.ToString();

                            if (Convert.ToDateTime(dataAtual) < Convert.ToDateTime(dDevolucao))
                            {
                                teste = true;
                                emprestimo.DataDevolucao = dataDevolucao;
                            }
                            else Console.WriteLine("Digite uma data maior que a atual " + dataAtual);
                        }
                    }
                    while (!teste);
                    sair = 0;
                }
                else
                {
                    Console.WriteLine("Cliente não cadastrado para emprestimo!!! entre com outro NumeroTombo.");
                    Console.WriteLine("Deseja voltar ao menu principal? 0 - Sim , 1 - Nao");
                    int.TryParse(Console.ReadLine(), out sair);
                    if (sair == 0) return emprestimo;
                }
            }
            while (sair != 0);
            return emprestimo;
        }
        static List<Emprestimo> MenuDevolucaoLivro(List<Emprestimo> listEmprestimo, List<Livro> listLivro)
        {
            long nTombo;
            int sair = 1;
            double multa;

            Console.WriteLine("--------------------------");
            Console.WriteLine("|   Biblioteca  Central  |");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("|           MENU         |");
            Console.WriteLine("|   Devolução  de Livro  |");
            Console.WriteLine("--------------------------");

            Emprestimo emprestimo = new Emprestimo { livro = new Livro { } };

            do
            {
                Console.WriteLine("Digite o NumeroTombo do exemplar a ser devolvido: ");
                long.TryParse(Console.ReadLine(), out nTombo);

                emprestimo = listEmprestimo.Find(x => x.livro.NumeroTombo == nTombo);
                if (emprestimo != null)
                {
                    if (emprestimo.livro.NumeroTombo == nTombo)
                    {
                        if (emprestimo.StatusEmprestimo == 1)
                        {
                            multa = CalculaMulta(emprestimo.DataDevolucao);
                            foreach (Emprestimo e in listEmprestimo)
                            {
                                if (nTombo == e.livro.NumeroTombo)
                                {
                                    e.multa = multa;
                                    e.StatusEmprestimo = 2;
                                    e.DataDevolucao = DateTime.Now;
                                    Console.WriteLine("Devolução feita com sucesso!!!");
                                    if (multa > 0)
                                    {
                                        Console.Write("\nVoce tem multa a pagar: R$ ");
                                        Console.WriteLine(multa.ToString("0,0.00"));
                                    }

                                }
                            }

                            sair = 0;
                        }
                        else
                        {
                            sair = 0;
                            Console.WriteLine("Livro não encontrado para devolução!!!");
                        }
                    }
                    else
                    {
                        sair = 0;
                        Console.WriteLine("Livro não encontrado para devolução!!!");
                    }
                }

                else
                {
                    Console.WriteLine("Livro não cadastrado ou indisponivel!!! entre com outro NumeroTombo.");
                    Console.WriteLine("Deseja voltar ao menu principal? 0 - Sim , 1 - Nao");
                    int.TryParse(Console.ReadLine(), out sair);
                    if (sair == 0) return listEmprestimo;
                }
            }
            while (sair != 0);

            return listEmprestimo;
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

        static public double CalculaMulta(DateTime DataDevolucao)
        {
            double multa = 0;
            string dataEmprestimo = DataDevolucao.ToString();
            string dataAtual = DateTime.Now.ToString();

            TimeSpan date = Convert.ToDateTime(dataAtual) - Convert.ToDateTime(dataEmprestimo);

            int dias = date.Days;
            if (dias > 0) multa = dias * 0.10;
            else multa = 0;

            return multa;
        }

    }
}
