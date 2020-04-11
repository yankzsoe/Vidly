using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos {
    public class MovieDto {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required, Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }

        [Required, Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Required, Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        [Required]
        public byte? GenreId { get; set; }
        public GenreDto Genre { get; set; }
    }
}