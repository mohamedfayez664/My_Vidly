using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.Identity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context= new ApplicationDbContext();
        }

        //Get  /api/customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers.Include(c=>c.MembershipType);

            if (!String.IsNullOrEmpty(query))
            {
                customersQuery= customersQuery.Where(c=>c.Name.Contains(query));
            }
            var lisOfDto = customersQuery.ToList()
                .Select (Mapper.Map<Customer, CustomerDto>);

            return Ok(lisOfDto);
        }

        //Get  /api/customers/id
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) 
                return NotFound(); 

            return Ok (Mapper.Map<CustomerDto>(customer) );
        }

        //Post /api/custpmers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id =customer.Id;
            return Created(new Uri(Request.RequestUri +"/" +customer.Id) ,customerDto) ;
        }

        // PUT  /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb=_context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //  customerInDb = Mapper.Map<Customer>(customerDto);
            // Mapper.Map<CustomerDto ,Customer>(customerDto, customerInDb);
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

        }

        // Delete /api /customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
