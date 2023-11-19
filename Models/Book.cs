﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Sulea_Steliana_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        [Required(ErrorMessage = "Campul Title este obligatoriu.")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        public int? AuthorID { get; set; }
        public Author? Author { get; set; } //navigation property

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; } //navigation property

        [Column(TypeName = "decimal(6,2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}
