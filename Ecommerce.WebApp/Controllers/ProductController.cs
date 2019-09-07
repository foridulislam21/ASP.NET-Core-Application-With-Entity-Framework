using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DatabaseContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            PopulateCategoryList();
            return View();
        }

        private void PopulateCategoryList(object selectedCategory = null)
        {
            var categor = _categoryRepository.GetAll();
            ViewBag.CategoryID = new SelectList(categor, "Id", "Name", selectedCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _productRepository.Add(model);
                if (isAdded)
                {
                    var product = _productRepository.GetAll();
                    ViewBag.SuccessMessage = "Save SuccessFully";
                    return View("Index", product);
                }
            }
            PopulateCategoryList(model.CategoryId);
            return View(model);
        }
    }
}