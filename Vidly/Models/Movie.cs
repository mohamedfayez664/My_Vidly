using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Relase Date")]
      //  [Required(ErrorMessage ="The Relaase Date Field is required")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name = "Number In Stock")]
     //   [Required]
        [Range(1,20)]//, ErrorMessage ="The Fieled Number in Stock Must bee in 1 and 20")]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
        public Genre Genre { get; set; }
        [Required]//(ErrorMessage = "The Genre Field is required")]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }
    }
}