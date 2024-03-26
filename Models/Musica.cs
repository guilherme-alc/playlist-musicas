using System.Text.Json.Serialization;

namespace PlaylistMusicas.Models; 
internal class Musica
{
    private string[] tonalidades = { "C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B" };
    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("year")]
    public string? AnoString { get; set; }
    [JsonPropertyName("key")]
    public int Key { get; set; }
    public string Tonalidade { 
        get
        {
            return tonalidades[Key];
        } 
    }
    public int Ano {
        get
        {
            return int.Parse(AnoString);
        }
    }

    public void ExibirDetalhesMusica ()
    {
        Console.WriteLine($"Artista {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duracao em segundos: {Duracao / 1000}");
        Console.WriteLine($"Ano: {Ano}");
        Console.WriteLine($"Gênero musical: {Genero}");
        Console.WriteLine($"Tonalidade da musica: {Tonalidade}");
    }
}
