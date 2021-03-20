
namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase   
    {
        public Genero Genero { get; set; }
        public string Titulo { get; set; }  
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }

        public Serie()
        {
        }
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return  $"Gênero {this.Genero} \n" +
                    $"Título: {this.Titulo} \n" +
                    $"Descrição: {this.Descricao} \n" +
                    $"Ano de Início: {this.Ano} \n" +
                    $"Excluido: {this.Excluido}";
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }       
    }

}