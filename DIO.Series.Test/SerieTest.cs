using NUnit.Framework;
using DIO.Series.Classes;
using Bogus;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace DIO.Series.Test
{
    [TestFixture]
    public class Tests
    {
        SerieRepositorio repositorio;
        Faker<Serie> faker;
        List<string> listafilmes = new List<string>();
        string[] filmes;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            string textFile = "filmes.txt";
            string workingDirectory  = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string testFolder = Path.Combine(projectDirectory, textFile);
            filmes = File.ReadAllLines(testFolder);
            foreach (string filme in filmes)
            {
                listafilmes.Add(filme);
            }  

            this.repositorio = new SerieRepositorio();

            var faker = new Faker<Serie>("pt_BR")
            .RuleFor(serie => serie.Id, fake => fake.IndexFaker)
            .RuleFor(serie => serie.Genero, fake => fake.PickRandom<Genero>())
            .RuleFor(serie => serie.Titulo , fake => fake.PickRandom<string>(listafilmes))
            .RuleFor(serie => serie.Descricao, fake => fake.Company.Bs())
            .RuleFor(serie => serie.Ano, fake => fake.Random.Int());

            this.faker = faker;
        }

        [Test]
        public void It_Should_Add_And_Retrieve_Series()
        {
            // Arrange
            int QTD_SERIES = 10;
            List<Serie> listaDeSeries = faker.Generate(QTD_SERIES);
            
            // Act
            listaDeSeries.ForEach(serie => repositorio.Inserir(serie));
            bool adicionouTodasAsSeries = repositorio.Listar().Count() == QTD_SERIES;
            
            // Assert
            Assert.That(adicionouTodasAsSeries);
        }

        [Test]
        public void It_Should_Update_Series()
        {
            // Arrange
            int QTD_SERIES = 10;
            int idSerieAlterada = 0;
            List<Serie> listaDeSeries = faker.Generate(QTD_SERIES);

            listaDeSeries.ForEach(serie => repositorio.Inserir(serie));
            Serie novaSerie = faker.Generate();
            
            // Act
            repositorio.Atualizar(idSerieAlterada, novaSerie);
            Serie serieAlterada = repositorio.RetornarPorId(idSerieAlterada); 
            
            // Assert
            Assert.That(serieAlterada.Equals(novaSerie));
        }

        [Test]
        public void It_Should_Delete_Series()
        {
            // Arrange
            int QTD_SERIES = 10;
            int idSerieExcluida = 0;
            List<Serie> listaDeSeries = faker.Generate(QTD_SERIES);

            listaDeSeries.ForEach(serie => repositorio.Inserir(serie));          
            // Act
            repositorio.Excluir(idSerieExcluida); 
            bool serieFoiExcluida= repositorio.RetornarPorId(idSerieExcluida)
            .retornaExcluido() == true;
            
            // Assert
            Assert.That(serieFoiExcluida);
        }

        [TearDown]

        public void Reset() 
        {
            repositorio.Listar().Clear();
        }
    }
}