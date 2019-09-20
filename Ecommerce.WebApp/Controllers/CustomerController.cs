using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Abstraction.BLL;
using Ecommerce.Abstraction.Repositories;
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
        private ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public IActionResult Index(string search)
        {
            var customers = _customerManager.GetAll();
            ViewData["searchData"] = search;

            if (!string.IsNullOrEmpty(search))
            {
                var searchCustomer = _customerManager.GetByName(search);
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
                CustomerList = _customerManager.GetAll()
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
                bool isAdded = _customerManager.Add(customer);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Saved Successfully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Operation Failed";
                }
            }

            model.CustomerList = _customerManager.GetAll();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customersById = _customerManager.GetById(id);
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
                bool isUpdate = _customerManager.Update(customer);
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
            var customers = _customerManager.GetAll();
            if (id != customer.Id)
            {
                return NotFound();
            }
            bool isRemove = _customerManager.Remove(customer);
            if (isRemove)
            {
                return RedirectToAction("Index", customers);
            }

            return RedirectToAction("Index", customers);
        }
    }
}