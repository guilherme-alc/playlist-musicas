using PlaylistMusicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistMusicas.Filters
{
    internal class LinqFilter
    {
        public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
        {
            //Acessa todas as instâncias de Musica, mas seleciona apenas a propriedade Genero do objeto, O distinct é usado para que não haja repetição de genero, e por fim transforma os resultados selecionados em uma lista
            var todosGenerosMusicais = musicas.Select(musica => musica.Genero).Distinct().ToList();
            foreach(var genero in todosGenerosMusicais)
            {
                Console.WriteLine($"- {genero}");
            }
        }
        public static void FiltrarArtistasPorGenero(List<Musica> musicas, string genero)
        {
            var artistasFiltrados = musicas
                .Where(musica => musica.Genero!
                .Contains(genero))
                .Select(musica => musica.Artista)
                .Distinct()
                .ToList();
            Console.WriteLine("Exibindo artistas por gênero musical -> {0}", genero);
            foreach(var artista in artistasFiltrados)
            {
                Console.WriteLine($"- {artista}");
            }
        }
        public static void FiltrarMusicasDeArtista(List<Musica> musicas, string nomeArtista)
        {
            var musicasFiltradas = musicas.Where(musica => musica.Artista!.Equals(nomeArtista)).Select(musica => musica.Nome).ToList();

            Console.WriteLine($"Músicas do {nomeArtista}");
            foreach(var musica in musicasFiltradas)
            {
                Console.WriteLine($"- {musica}");
            }
        }

        public static void FiltrarMusicasPorAno(List<Musica> musicas, int ano)
        {
            var musicasFiltradas = musicas
                .Where(musica => musica.Ano
                .Equals(ano))
                .OrderBy(musica => musica.Nome)
                .ToList();

            Console.WriteLine($"Músicas do ano {ano}:");
            foreach(var musica in musicasFiltradas)
            {
                Console.WriteLine($"{musica.Nome} - {musica.Artista}");
            }
        }
        public static void FiltrarMusicaPorTom(List<Musica> musicas, string tom)
        {
            var musicasFiltradas = musicas
                .Where(musica=> musica.Tonalidade
                .Equals(tom))
                .ToList();

            Console.WriteLine($"Musicas filtradas pela tonalidade {tom}");
            foreach(var musica in musicasFiltradas)
            {
                musica.ExibirDetalhesMusica();
            }
        }
    }
}
