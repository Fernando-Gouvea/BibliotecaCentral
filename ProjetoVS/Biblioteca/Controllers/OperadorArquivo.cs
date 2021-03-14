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
        Cliente cliente { set; get; }
        public string Path { get; set; }

        public OperadorArquivo()
        {
        }

        public OperadorArquivo(String Path)
        {

            this.Path = Path;

        }

        public List<Cliente> Leitor()
        {
            string pathCliente = Path + "CLIENTE.csv";
            try
            {
                using (var sr = new StreamReader(pathCliente))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        var valoresRecortados = linha.Split(',');

                        cliente.IdCliente = int.Parse(valoresRecortados[0]);
                        cliente.Cpf = valoresRecortados[1];
                        cliente.Nome = valoresRecortados[2];
                        cliente.DataNascimento = DateTime.Parse(valoresRecortados[3]);
                        cliente.Telefone = valoresRecortados[4];
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

    }

}

