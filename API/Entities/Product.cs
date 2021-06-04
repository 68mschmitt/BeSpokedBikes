using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        [Column(TypeName="money")]
        public decimal PurchasePrice { get; set; }
        [Column(TypeName="money")]
        public decimal SalePrice { get; set; }
        public int QuantityOnHand { get; set; }
        public decimal CommissionPercentage { get; set; }

    }
}