using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quotes.Models;
using Quotes.ViewModels;

namespace Quotes.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (QuotesEntities db = new QuotesEntities())
            {
                var carQuotes = db.CarQuotes;
                var carQuoteVms = new List<CarQuoteVm>();
                foreach(var carQuote in carQuotes)
                {
                    var carQuoteVm = new CarQuoteVm();
                    carQuoteVm.Id = carQuote.Id;
                    carQuoteVm.FirstName = carQuote.FirstName;
                    carQuoteVm.LastName = carQuote.LastName;
                    carQuoteVm.EmailAddress = carQuote.EmailAddress;
                    carQuoteVm.DateOfBirth = carQuote.DateOfBirth;
                    carQuoteVm.Quote = carQuote.Quote;
                    carQuoteVm.DateOfQuote = carQuote.DateOfQuote;
                    carQuoteVm.CarMake = carQuote.CarMake;
                    carQuoteVm.CarModel = carQuote.CarModel;
                    carQuoteVm.CarYear = carQuote.CarYear;
                    carQuoteVm.DUI = carQuote.DUI;
                    carQuoteVm.NumberOfSpeedingTickets = carQuote.NumberOfSpeedingTickets;
                    carQuoteVm.CoverageType = carQuote.CoverageType;

                    carQuoteVms.Add(carQuoteVm);

                }

                return View(carQuoteVms);
            }

        }
    }
}