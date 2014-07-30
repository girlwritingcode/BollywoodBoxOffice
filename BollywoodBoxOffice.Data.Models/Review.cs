using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollywoodBoxOffice.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int Stars { get; set; }
        public int MovieId { get; set; } //this makes room for the foreign key from the movie list
        public virtual Movie Movies { get; set; } //this gives the database access to the list of movies 
        public Review() { }
        public Review(string name, string body, int stars, int movieId)
        {
            Name = name;
            Body = body;
            Stars = stars;
            MovieId = movieId;
        }
    }
}
