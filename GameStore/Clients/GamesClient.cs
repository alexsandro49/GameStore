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
            Id = 2, Name = "Sunset Riders", Genre = "Action",
            Price = 44.99m, ReleaseDate = new DateOnly(1993, 8, 6)
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
        var genre = GetGenreById(game.GenreId);

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
        var game = GetGameSummaryById(id);
        ArgumentNullException.ThrowIfNull(game);

        var genre = genres.Single(genre => string.Equals(
            genre.Name,
            game.Genre,
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

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        var existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }
}