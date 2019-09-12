using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Json.Internal;
using Newtonsoft.Json;

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
                return PartialView(searchCustomer);
            }
            return View(customers);
        }

        public bool JsonArrayAttribute { get; set; }

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
                    Id = model.Id,
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
            return RedirectToAction("Index");
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
            return PartialView(customersById);
        }

        [HttpPost]
        public IActionResult Edit(int id, CustomerCreateViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            var customer = new Customer()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                LoyaltyPoint = model.LoyaltyPoint
            };

            if (ModelState.IsValid)
            {
                bool isUpdate = _customerRepository.Update(customer);
                if (isUpdate)
                {
                    ViewBag.UpdateMessage = "Update SuccessFully!";
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            bool isRemove = _customerRepository.Remove(customer);
            if (isRemove)
            {
                ViewBag.Deleted = "Customer data remove successfully!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}