
using System;
using DIO.Series.Classes;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;

                    case "2":
                    InserirSeries();
                    break;

                    case "3":
                    AtualizarSeries();
                    break;

                    case "4":
                    ExcluirSeries();
                    break;

                    case "5":
                    VisualizarSeries();
                    break;

                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série que quer excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            string nomeDaSerie = repositorio.RetornarPorId(indiceSerie).Titulo;
            Console.WriteLine($"Tem certeza que quer exluir a série {nomeDaSerie} (N/s)?");
            string resposta = Console.ReadLine().ToUpper();

            if(resposta == "S")
            {
                repositorio.Excluir(indiceSerie);
            }

        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            (int entradaGenero, string entradaTitulo, 
            int entradaAno, string entradaDescricao) = ObterOpcoesDaSerie();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static (int, string, int, string) ObterOpcoesDaSerie()
        {
            foreach( int i in Enum.GetValues(typeof(Genero)) )
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");   
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            return (entradaGenero, entradaTitulo, entradaAno, entradaDescricao);
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série");

            (int entradaGenero, string entradaTitulo, 
            int entradaAno, string entradaDescricao) = ObterOpcoesDaSerie();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Inserir(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("### Listar séries ###");

            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#Id: {0} | Título: {1} {2}", serie.retornaId(), 
                serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
