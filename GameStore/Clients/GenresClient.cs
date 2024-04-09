using GameStore.Models;

namespace GameStore.Clients;

public class GenresClient
{
    private readonly Genre[] genres = [
        new() { 
            Id = 1, Name = "Action" 
        },
        new() { 
            Id = 2, Name = "Casual" 
        },
        new() { 
            Id = 3, Name = "Fighting" 
        },
        new() { 
            Id = 4, Name = "Music" 
        },
        new() { 
            Id = 5, Name = "Racing" 
        },
        new() { 
            Id = 6, Name = "RPG" 
        },
        new() { 
            Id = 7, Name = "Shooter"
        },
        new() { 
            Id = 8, Name = "Sports" 
        }
    ];

    public Genre[] GetGenres() => genres;
}