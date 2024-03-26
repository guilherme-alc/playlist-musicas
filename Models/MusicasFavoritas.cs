using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace PlaylistMusicas.Models
{
    internal class MusicasFavoritas
    {
        public string Nome { get; set; }
        public List<Musica>? ListaDeMusicasFavoritas { get; }

        public MusicasFavoritas(string nome)
        {
            Nome = nome;
            ListaDeMusicasFavoritas = new List<Musica>();
        }
        public void AdicionarMusicasFavoritas(Musica musica)
        {
            ListaDeMusicasFavoritas.Add(musica);
        }
        public void RemoverMusicaDaListaFavoritas(Musica musica)
        {
            ListaDeMusicasFavoritas.Remove(musica);
        }
        public void ExibirMusicasFavoritas()
        {
            Console.WriteLine($"Lista de músicas favoritas de {Nome}");
            foreach(var musica in ListaDeMusicasFavoritas)
            {
                Console.WriteLine($"{musica.Nome} - {musica.Artista} ");
            }
            Console.WriteLine();
        }
        public void GerarArquivoJson()
        {
            //objeto anônimo, não tem tipo. usado para criar uma estrutura temporária
            string json = JsonSerializer.Serialize(new
            {
                nome = Nome,
                musicas = ListaDeMusicasFavoritas
            });
            //criando nome do arquivo com interpolação do nome da pessoa
            string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";
            //criando arquivo json
            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine($"Caminho do arquivo json {Path.GetFullPath(nomeDoArquivo)}");
        }
        public void GeraArquivoTxt()
        {
            string nomeDoArquivo = $"musicas-favoritas-{Nome}.txt";
            using(StreamWriter arquivo = new StreamWriter(nomeDoArquivo))
            {
                arquivo.WriteLine($"Musicas favoritas do {Nome}");
                foreach(var musica in ListaDeMusicasFavoritas)
                {
                    arquivo.WriteLine(musica.Nome);
                }
            }
            Console.WriteLine($"Caminho do arquivo txt {Path.GetFullPath(nomeDoArquivo)}");
        }
    }
}
