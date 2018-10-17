using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        public DateTime? Birthday { get; set; }

        public bool IsStudent { get; set; }
        
        public int MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}