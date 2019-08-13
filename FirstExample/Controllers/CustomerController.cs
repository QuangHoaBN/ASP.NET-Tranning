using FirstExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FirstExample.ViewModels;

namespace FirstExample.Controllers
{
    
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        private ProductDbContext _context;
        public CustomerController()
        {
            _context = new ProductDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membership = _context.MembershipTypes.ToList();
            var viewModel = new CustomerViewModel
            {
                Customer=new Customer(),
                MembershipTypes = membership
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Customerform", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var cusUpDb = _context.Customers.Single(c=>c.Id==customer.Id);
                cusUpDb.Name = customer.Name;
                cusUpDb.DOB = customer.DOB;
                cusUpDb.MembershipTypeId = customer.MembershipTypeId;
                cusUpDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }   
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.membership).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.membership).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cus == null) return HttpNotFound();
            var viewModel = new CustomerViewModel
            {
                Customer = cus,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
    }
}