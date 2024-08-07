﻿using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal(new Context()));
        public IActionResult Index()
        {
            string userName = User.Identity.Name;

            // Hoşgeldiniz mesajı için ViewBag kullan
            ViewBag.WelcomeMessage = $"Hoşgeldiniz, {userName}";

            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryValidation = new CategoryValidatior();
            ValidationResult results = categoryValidation.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index", "AdminCategory"); // Bu satırın AdminCategory'ye yönlendiğinden emin olun
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(); // Validasyon hataları ile AddCategory görünümünü geri döndür
            }
        }

        public ActionResult DeleteCategory(int id)
        {
            var categorvalue = cm.GetById(id);
            cm.CategoryDelete(categorvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetById(id);
            return View(categoryValue);
        }

        [HttpPost]

         public IActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }

}
