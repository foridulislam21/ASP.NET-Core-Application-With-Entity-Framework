using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DatabaseContext;
using Ecommerce.WebApp.Models.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public ProductController(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var product = _productRepository.GetAll();
            return View(product);
        }

        public IActionResult Create()
        {
            var model = new ProductViewModel
            {
                ProductList = _productRepository.GetAll() as List<Product>
            };
            PopulateCategoryList();
            return View(model);
        }

        private void PopulateCategoryList(object selectedCategory = null)
        {
            var categor = _categoryRepository.GetAll();
            ViewBag.CategoryID = new SelectList(categor, "Id", "Name", selectedCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            var products = new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                ExpireDate = model.ExpireDate,
                IsActive = model.IsActive,
                Category = model.Category,
                CategoryId = model.CategoryId
            };
            if (ModelState.IsValid)
            {
                bool isAdded = _productRepository.Add(products);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Save SuccessFully";
                    return View();
                }
            }
            PopulateCategoryList(model.CategoryId);
            return View(model);
        }
    }
}