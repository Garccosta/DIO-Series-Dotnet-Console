using DIO.Series.Enum;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase   
    {
        private Genero Genero { get; set; }
        public string Titulo { get; set; }  
        public string Descricao { get; set; }
        public int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        public override string ToString()
        {
            return $@"Gênero {this.Genero} \n
                    Título: {this.Titulo} \n
                    Descrição: {this.Descricao} \n
                    Ano de Início: {this.Ano}";
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        
    }

}