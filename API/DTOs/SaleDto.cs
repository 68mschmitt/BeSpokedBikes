using System;
using API.Entities;

namespace API.DTOs
{
    public class SaleDto
    {
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int SalesPersonId { get; set; }
        public SalesPersonDto SalesPerson { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    }
}