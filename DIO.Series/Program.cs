using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System;
using DIO.Series.classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new  SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:

                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado pro ultilizar nossos serviços!");
            Console.ReadLine();
        }
        
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Seriees");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Neenhuma Serie Cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}" , serie.retornaId(), serie.retornaTitulo(), excluido ? "Excluido" : "");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inseerir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digitee o Titulo da Série: ");
            string entraTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entraAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entraDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero:(Genero)entraGenero,
                                        titulo: entraTitulo,
                                        ano: entraAno,
                                        descricao: entraDescricao);
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da serie que deseja atualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entraTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entraAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entraDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero:(Genero)entraGenero,
                                        titulo: entraTitulo,
                                        ano: entraAno,
                                        descricao: entraDescricao);
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Tiago Series ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova Serie");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Excluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
