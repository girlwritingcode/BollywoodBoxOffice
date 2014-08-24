using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollywoodBoxOffice.Data.Models
{
    public class DetailReviews
    {
        public Movie Movie { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
