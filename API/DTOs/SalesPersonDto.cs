using System;

namespace API.DTOs
{
    public class SalesPersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? TerminationDate { get; set; }
        public string Manager { get; set; }
    }
}