using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quotes.ViewModels
{
    public class CarQuoteVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime DateOfQuote { get; set; }
        public decimal Quote { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string DUI { get; set; }
        public int NumberOfSpeedingTickets { get; set; }
        public string CoverageType { get; set; }
    }
}