using System;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReportsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<SalesReportDto> GetCommissionReport(DateTime date)
        {
            var report = _unitOfWork.ReportRepository.GetSalesReport(date);

            if (report != null) return Ok(report);

            return BadRequest();
        }
    }
}