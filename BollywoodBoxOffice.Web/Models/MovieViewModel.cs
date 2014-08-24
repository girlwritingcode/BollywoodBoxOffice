using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BollywoodBoxOffice.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int Gross { get; set; }
        public double Crores { get; set; }
        public MovieViewModel() { }
        public MovieViewModel(int id, string name, string url, int gross)
        {
            Id = id;
            Name = name;
            URL = url;
            Gross = gross;
            Crores = Math.Round(((gross * 60.92) / 10), 2);
        }
    }
}