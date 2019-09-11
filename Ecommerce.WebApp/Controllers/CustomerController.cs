using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models.Customer;
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

            if (!string.IsNullOrEmpty(search))
            {
                var searchCustomer = _customerRepository.GetByName(search);
                return View(searchCustomer);
            }
            return PartialView(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerCreateViewModel
            {
                CustomerList = _customerRepository.GetAll()
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    Name = model.Name,
                    Address = model.Address,
                    LoyaltyPoint = model.LoyaltyPoint
                };
                bool isAdded = _customerRepository.Add(customer);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Saved Successfully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Operation Failed";
                }
            }

            model.CustomerList = _customerRepository.GetAll();
            return RedirectToAction("Index", model);
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
                    ViewBag.UpdateMessage = "Update SuccessFully!";
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