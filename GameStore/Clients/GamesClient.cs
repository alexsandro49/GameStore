using GameStore.Models;

namespace GameStore.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = [
        new() {
            Id = 1, Name = "Mortal Kombat", Genre = "Fighting",
            Price = 59.99m, ReleaseDate = new DateOnly(1992, 8, 1)
        },
        new() {
            Id = 2, Name = "J-League Winning Eleven", Genre = "Sports",
            Price = 44.99m, ReleaseDate = new DateOnly(1995, 7, 21)
        },
        new() {
            Id = 3, Name = "Castlevania: Symphony of the Night", Genre = "Action",
            Price = 51.99m, ReleaseDate = new DateOnly(1997, 3, 20)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary 
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

    public GameDetails GetGame(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);

        var genre = genres.Single(genre => string.Equals(
            genre.Name,
            game.Name,
            StringComparison.OrdinalIgnoreCase
        ));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
}