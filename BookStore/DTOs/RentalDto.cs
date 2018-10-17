using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DTOs
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> BookIds { get; set; }
    }
}