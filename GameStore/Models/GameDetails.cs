using GameStore.Converters;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models;

public class GameDetails
{
    public int Id { get; set; }

    [Required][StringLength(40)]
    public required string Name { get; set; }

    [Required(ErrorMessage = "The Genre field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }

    [Range(1, 300)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}