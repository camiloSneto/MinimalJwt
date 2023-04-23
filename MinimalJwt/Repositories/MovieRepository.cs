using MinimalJwt.Models;

namespace MinimalJwt.Repositories
{
    public class MovieRepository
    {
        public static List<Movie> Movies = new()
        {
            new() { Id = 1, Title= "Eternals", Description= "The saga of the Eternals, a race od immortal beigs who lives on Earth and shaped its history and civilizations.", Rating = 6.8},
            new() { Id = 2, Title= "Dune", Description= "The saga of the Dune, a race od immortal beigs who lives on Earth and shaped its history and civilizations.", Rating = 9.8},
            new() { Id = 3, Title= "The Harder they Fall", Description= "The saga of the The Harder they Fall, a race od immortal beigs who lives on Earth and shaped its history and civilizations.", Rating = 7.5},
            new() { Id = 4, Title= "Red Notice", Description= "The saga of the Red Notice, a race od immortal beigs who lives on Earth and shaped its history and civilizations.", Rating = 3.4},
            new() { Id = 5, Title= "No Time to Die", Description= "The saga of the No Time to Die, a race od immortal beigs who lives on Earth and shaped its history and civilizations.", Rating = 6.6}
        };
    }
}
