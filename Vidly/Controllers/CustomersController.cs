using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.Identity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }


        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var customerFormVM = new CustomerFormVM
            {
                Customer = new Customer(),
                MembershipTypes = membershipType,
            };
            return View("CustomerForm", customerFormVM);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            var customerFormVM = new CustomerFormVM
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
            };
            return View("CustomerForm", customerFormVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerFormVM = new CustomerFormVM
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),
                };
                return View("CustomerForm", customerFormVM);
            }
          


            if(customer.Id==0)  _context.Customers.Add(customer);
            else
            {
                var customerInDb=_context.Customers.Single(c=>c.Id==customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter=customer.IsSubscribedToNewsletter;

                //TryUpdateModel(customerInDb,"",new string[] {"Name","Email"} );
            }
            _context.SaveChanges();

           return RedirectToAction("Index","Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

          //  var customers = _context.Customers.Include(c=> c.MembershipType).ToList();

            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


    }
}