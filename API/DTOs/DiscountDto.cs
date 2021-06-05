using System;

namespace API.DTOs
{
    public class DiscountDto
    {
        public ProductDto Product { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}