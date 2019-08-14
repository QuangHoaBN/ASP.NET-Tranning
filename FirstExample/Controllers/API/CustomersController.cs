using AutoMapper;
using FirstExample.Dtos;
using FirstExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstExample.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        // GET /api/customer/id
        public IHttpActionResult GetCustomer(int id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cus == null) return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>(cus));
        }
        // POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        //PUT /api/customer/id
        [HttpPut]
        public void  UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cusInDB = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (cusInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, cusInDB);
            _context.SaveChanges();
        }
        //DELETE /api/customer/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var cusInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cusInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(cusInDB);
            _context.SaveChanges();
        }
    }
}
