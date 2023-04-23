using MinimalJwt.Models;

namespace MinimalJwt.Service
{
    public interface IMovieService
    {
        public Movie Create(Movie movie);
        public Movie Update(Movie newMovie);
        public bool Delete(int id);    
        public Movie Get(int id);
        public List<Movie> GetAll();
     

    }
}
