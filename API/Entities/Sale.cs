using System;

namespace API.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public Customer Customer { get; set; }
        public DateTime SaleDate { get; set; }

    }
}