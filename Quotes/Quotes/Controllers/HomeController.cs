using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quotes.Models; 

namespace Quotes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CarQuote(string firstName, string lastName, string emailAddress, 
            string DOB, int carYear, string carMake, string carModel,
            bool DUI, int numberOfSpeedingTickets, string coverageType)
        {
            double quoteFinal = 50; // base price

            // calculate age and modify quote as needed
            DateTime dateOfBirth = DateTime.Parse(DOB);
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dateOfBirth.Year;
            if (dateOfBirth.DayOfYear > currentDate.DayOfYear) age--;
            if (age < 25 && age >= 18) quoteFinal += 25;
            if (age < 18) quoteFinal += 100;
            if (age >= 100) quoteFinal += 25;

            // modify quote dependent upon car year
            if (carYear < 2000) quoteFinal += 25;
            if (carYear >= 2015) quoteFinal += 25;

            // modify quote dependent upon car model
            if (carMake.ToLower() == "porsche") quoteFinal += 25;
            if (carMake.ToLower() == "porsche" && carModel.ToLower() == "911 carrera") quoteFinal += 25;

            // modify quote dependent upon number of speeding tickets
            if (numberOfSpeedingTickets > 0) quoteFinal += 10 * numberOfSpeedingTickets;

            // increase price if had DUI in past
            if (DUI) quoteFinal *= 1.25;

            // increase again if full coverage
            if (coverageType == "full") quoteFinal *= 1.5;

            ViewBag.Quote = Convert.ToDecimal(quoteFinal);


            // add to database
            using (QuotesEntities db = new QuotesEntities())
            {
                var carQuote = new CarQuote();
                carQuote.Quote = Convert.ToDecimal(quoteFinal);
                carQuote.DateOfQuote = currentDate;
                carQuote.FirstName = firstName;
                carQuote.LastName = lastName;
                carQuote.EmailAddress = emailAddress;
                carQuote.DateOfBirth = dateOfBirth;
                carQuote.CarMake = carMake;
                carQuote.CarModel = carModel;
                carQuote.CarYear = carYear;
                carQuote.CoverageType = coverageType;
                carQuote.DUI = DUI.ToString();
                carQuote.NumberOfSpeedingTickets = numberOfSpeedingTickets;

                db.CarQuotes.Add(carQuote);
                db.SaveChanges();

            }

            return View();
        }

    }
}