﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts("");

            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var response = await _productService.Create(model, token);
                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var model = await _productService.FindProductById(id, token);

            if (model != null)
            {
                return View(model);
            }
            return NotFound();

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var response = await _productService.Update(model, token);
                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var model = await _productService.FindProductById(id, token);
            if (model != null)
            {
                return View(model);
            }
            return NotFound();

        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var response = await _productService.Delete(model.Id, token);
            if (response)
            {
                return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }
    }
}
