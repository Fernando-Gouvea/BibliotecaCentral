using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Controllers
{
    public class OperadorArquivo
    {

        List<Cliente> listCliente = new List<Cliente>();
        List<Livro> listLivro = new List<Livro>();

        public string Path { get; set; }

        public OperadorArquivo()
        {
        }

        public OperadorArquivo(String Path)
        {

            this.Path = Path;

        }

        public List<Cliente> LeitorCliente(Cliente cliente)
        {           

            string pathCliente = Path + "CLIENTE.csv";
            try
            {
                using (var sr = new StreamReader(pathCliente))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        var valoresRecortados = linha.Split(';');
                        cliente = new Cliente {endereco = new Endereco { } };

                        cliente.IdCliente = int.Parse(valoresRecortados[0]);
                        cliente.Cpf = valoresRecortados[1];
                        cliente.Nome = valoresRecortados[2];
                        cliente.Telefone = valoresRecortados[3];
                        cliente.DataNascimento = DateTime.Parse(valoresRecortados[4]);
                        cliente.endereco.Logradouro = valoresRecortados[5];
                        cliente.endereco.Bairro = valoresRecortados[6];
                        cliente.endereco.Cidade = valoresRecortados[7];
                        cliente.endereco.Estado = valoresRecortados[8];
                        cliente.endereco.Cep = valoresRecortados[9];

                        listCliente.Add(cliente);

                    }
                    listCliente = listCliente.OrderBy(x => x.IdCliente).ToList();
                    Console.WriteLine("<<Clientes recuperados do arquivo CLIENTE.CSV>>");
                }
            }

            catch (IOException e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (IndexOutOfRangeException e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            return listCliente;
        }

        public void SalvaCliente(List<Cliente> listCliente)
        {
            string pathCliente = Path + "CLIENTE.csv";
            
            using (StreamWriter sw = File.CreateText(pathCliente))//cria um arquivo ou sobre escreve
            {
                foreach (Cliente cliente in listCliente)
                {
                    sw.WriteLine(cliente.ToCsv());

                }

                Console.WriteLine("<<Clientes salvos no arquivo CLIENTE.csv >>");
            }
        }

        public List<Livro> LeitorLivro(Livro livro)
        {

            string pathLivro = Path + "LIVRO.csv";
            try
            {
                using (var sr = new StreamReader(pathLivro))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        var valoresRecortados = linha.Split(';');
                        livro = new Livro();

                        livro.NumeroTombo = int.Parse(valoresRecortados[0]);
                        livro.ISBN = valoresRecortados[1];
                        livro.Titulo = valoresRecortados[2];
                        livro.Genero = valoresRecortados[3];
                        livro.DataPublicacao = DateTime.Parse(valoresRecortados[4]);
                        livro.Autor = valoresRecortados[5];
                        
                        listLivro.Add(livro);

                    }
                    listLivro = listLivro.OrderBy(x => x.NumeroTombo).ToList();
                    Console.WriteLine("<<Exemplares recuperados do arquivo LIVRO.CSV>>");
                }
            }

            catch (IOException e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (IndexOutOfRangeException e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            return listLivro;
        }

        public void SalvaLivro(List<Livro> listLivro)
        {
            string pathLivro = Path + "LIVRO.csv";

            using (StreamWriter sw = File.CreateText(pathLivro))//cria um arquivo ou sobre escreve
            {
                foreach (Livro livro in listLivro)
                {
                    sw.WriteLine(livro.ToCsv());

                }

                Console.WriteLine("<<Exemplares salvos no arquivo LIVRO.csv >>");
            }
        }

    }

}

