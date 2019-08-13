using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstExample.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Movie's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string DateAdd { get; set; }
        [StockRange1to200]
        [Range(1,200)]
        public int Stock { get; set; }
        
    }
}