using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes1
{
    class LinqToObjects
    {
        static void Main(string[] args)
        {
            var generos = new List<Genero>
            {
                new Genero {Id = 1, Nome = "Rock"},
                new Genero {Id = 2, Nome = "Reggae"},
                new Genero {Id = 3, Nome = "Rock Progressivo"},
                new Genero {Id = 4, Nome = "Punk Rock"},
                new Genero {Id = 5, Nome = "Clássica"}

            };

            foreach (var genero in generos)
            {
                if (genero.Nome.Contains("Rock"))
                {
                    Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
                }
            }

            var query = from g in generos
                        where g.Nome.Contains("Rock")
                        select g;

            //Linq = Language Integrated Query - Consulta Integrada a Linguagem


            Console.WriteLine();

            foreach (var genero in query)
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            }

            //listar música
            var musicas = new List<Musica>
            {
                new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1},
                new Musica { Id = 2, Nome = "I Shot the Sheriff", GeneroId = 2 },
                new Musica { Id = 3, Nome = "Danúbio Azul" , GeneroId = 5},
            };

            var musicaQuery = from m in musicas
                              where m.GeneroId == 1
                              join g in generos on m.GeneroId equals g.Id
                              where g.Nome == "Reggae"
                              select m.Nome;

            Console.WriteLine();
            foreach (var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.g.Nome);
            }

            

            Console.ReadKey();

           
        }
    }
}


class Genero
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Musica
{ 
    public int Id { get; set; }
    public string Nome { get; set; }

    public int GeneroId { get; set; }
}
