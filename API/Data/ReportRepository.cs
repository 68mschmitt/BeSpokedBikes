using System;
using System.Collections.Generic;
using System.Linq;
using API.DTOs;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ReportRepository : IReportRepository
    {
        private readonly BeSpokedDataContext _context;
        public ReportRepository(BeSpokedDataContext context)
        {
            _context = context;
        }

        public SalesReportDto GetSalesReport(DateTime quarterDate)
        {
            var salesReport = new SalesReportDto();
            var month = quarterDate.Month;
            if (month >= 1 && month <= 3)
            {
                salesReport.StartDate = new DateTime(quarterDate.Year, 1, 1);
                salesReport.EndDate = new DateTime(quarterDate.Year, 3, 31);
            }
            else if (month >= 4 && month <= 6)
            {
                salesReport.StartDate = new DateTime(quarterDate.Year, 4, 1);
                salesReport.EndDate = new DateTime(quarterDate.Year, 6, 30);
            }
            else if (month >= 7 && month <= 9)
            {
                salesReport.StartDate = new DateTime(quarterDate.Year, 7, 1);
                salesReport.EndDate = new DateTime(quarterDate.Year, 9, 30);
            }
            else
            {
                salesReport.StartDate = new DateTime(quarterDate.Year, 10, 1);
                salesReport.EndDate = new DateTime(quarterDate.Year, 12, 31);
            }

                
            var salesCommissions = new List<SalesPersonCommission>();

            var query = _context.Sales
                .Include(s => s.SalesPerson)
                .Where(s => s.SaleDate >= salesReport.StartDate && s.SaleDate <= salesReport.EndDate)
                .AsQueryable();

            var salesPeople = query
                .Select(s => new SalesPersonCommission{
                    Id = s.SalesPerson.Id,
                    FullName = $"{s.SalesPerson.FirstName} {s.SalesPerson.LastName}",
                    Commission = 0
                })
                .Distinct()
                .ToList();
                
            for (int i = 0; i < salesPeople.Count; i++)
            {
                salesPeople[i].Commission = query.Where(s => s.SalesPerson.Id == salesPeople[i].Id).Select(s => (s.Product.SalePrice) * (s.Product.CommissionPercentage / 100)).Sum();
            }

            salesReport.SalesPeople = salesPeople;

            return salesReport;
        }
    }
}