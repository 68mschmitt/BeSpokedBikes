using System;
using API.DTOs;

namespace API.Interfaces
{
    public interface IReportRepository
    {
         SalesReportDto GetSalesReport(DateTime quarterDate);
    }
}