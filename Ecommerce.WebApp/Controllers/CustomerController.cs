using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        public IActionResult Index(string search)
        {
            var customers = _customerRepository.GetAll();
            ViewData["searchData"] = search;
            var searchCustomer = from customer in customers select customer;
            if (!String.IsNullOrEmpty(search))
            {
                searchCustomer = searchCustomer.Where(c => c.Name.StartsWith(search));
                return View(searchCustomer);
            }
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _customerRepository.Add(model);
                if (isAdded)
                {
                    var customers = _customerRepository.GetAll();
                    ViewBag.SuccessMessage = "Saved Successfully";
                    return View("Index", customers);
                }
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customersById = _customerRepository.GetById(id);
            if (customersById == null)
            {
                return NotFound();
            }
            return View(customersById);
        }

        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool isUpdate = _customerRepository.Update(customer);
                if (isUpdate)
                {
                    ViewBag.SuccessMessage = "Update SuccessFully!";
                    return View();
                }
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerId = _customerRepository.GetById(id);
            if (customerId == null)
            {
                return NotFound();
            }
            return View(customerId);
        }

        [HttpPost]
        public IActionResult Delete(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                bool isRemove = _customerRepository.Remove(customer);
                if (isRemove)
                {
                    ViewBag.Deleted = "Customer data remove successfully!";
                    return View();
                }
            }

            return View();
        }
    }
}