using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class SalesReportDto
    {
        public IEnumerable<SalesPersonCommission> SalesPeople { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class SalesPersonCommission
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Commission { get; set; }
    }
}