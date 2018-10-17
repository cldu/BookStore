using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [Required]
        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        [Required]
        public DateTime? PublishedDate { get; set; }
        
        public DateTime? AddedDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
    }
}