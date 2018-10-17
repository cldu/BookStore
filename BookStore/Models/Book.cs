using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        
        public Category Category { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Published date")]
        [Required]
        public DateTime? PublishedDate { get; set; }

        [Display(Name = "Added to store on")]
        public DateTime AddedDate { get; set; }

        [Display(Name = "Number in stock")]
        [Required]
        [Range(1,20)]
        public int? NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}