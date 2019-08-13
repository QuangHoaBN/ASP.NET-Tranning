using FirstExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstExample.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title
        {
            get
            {
                return Movie.Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}