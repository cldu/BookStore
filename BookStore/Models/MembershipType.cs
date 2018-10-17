using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int MembershipPrice { get; set; }
        public int MonthsDuration { get; set; }
        public int Discount { get; set; }
    }
}