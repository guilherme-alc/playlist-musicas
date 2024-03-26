using System.Text.Json;
using PlaylistMusicas.Models;
using PlaylistMusicas.Filters;

namespace PlaylistMusicas
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Musica> musicas = null;
            //HttpClient é uma classe que fornece um cliente HTTP para enviar e receber requisições e respostas
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Método assíncrono que faz uma requisição get e retorna a resposta em string. O await é usado para aguardar a operação assíncrona
                    string resposta = await client
                        .GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
                    //Desserialização transforma o json string em uma lista de objeto manipulável
                    musicas = JsonSerializer.Deserialize<List<Musica>>(resposta);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Erro na requisição: " + ex.Message);
                    return; // Encerra o método Main se houver erro na requisição
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Erro ao desserializar JSON: " + ex.Message);
                    return; // Encerra o método Main se houver erro na desserialização JSON
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro inesperado: " + ex.Message);
                    return;
                }
            }

            if (musicas != null) 
            {
                //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
                //LinqOrder.OrdenaArtistasPorNome(musicas);
                //LinqFilter.FiltrarArtistasPorGenero(musicas, "rock");
                //LinqFilter.FiltrarMusicasDeArtista(musicas, "Foo Fighters");
                //LinqFilter.FiltrarMusicasPorAno(musicas, 2018);
                LinqFilter.FiltrarMusicaPorTom(musicas, "C#");

                MusicasFavoritas favoritasDeGuilherme = new MusicasFavoritas("Guilherme");
                favoritasDeGuilherme.AdicionarMusicasFavoritas(musicas[247]);
                favoritasDeGuilherme.AdicionarMusicasFavoritas(musicas[321]);
                favoritasDeGuilherme.AdicionarMusicasFavoritas(musicas[196]);
                favoritasDeGuilherme.AdicionarMusicasFavoritas(musicas[742]);
                favoritasDeGuilherme.AdicionarMusicasFavoritas(musicas[98]);
                favoritasDeGuilherme.AdicionarMusicasFavoritas(musicas[1005]);

                //musicasGuilherme.ExibirMusicasFavoritas();
                //musicasGuilherme.GerarArquivoJson();
                //musicasGuilherme.GeraArquivoTxt();
            }
        }
    }
}
