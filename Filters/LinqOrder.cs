using PlaylistMusicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistMusicas.Filters
{
    internal class LinqOrder
    {
        public static void OrdenaArtistasPorNome (List<Musica> musicas)
        {
            var artistasOrdenados = musicas.Select(artista => artista.Artista).Distinct().Order().ToList();
            Console.WriteLine("Lista de artistas ordenados:");
            foreach (var artista in artistasOrdenados)
            {
                Console.WriteLine($"- {artista}");
            }
        }
    }
}
