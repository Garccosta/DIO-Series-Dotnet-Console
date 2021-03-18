
using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario)
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
}
