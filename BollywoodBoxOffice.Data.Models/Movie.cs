using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollywoodBoxOffice.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int Gross { get; set; }
        public int Year { get; set; }
        public string Studio { get; set; }
        public string Director { get; set; }
        public Movie() { }
        public Movie(string name, string url, int gross, int year, string studio, string director)
        {
            Name = name;
            URL = url;
            Gross = gross;
            Year = year;
            Studio = studio;
            Director = director;
        }
    }
}
