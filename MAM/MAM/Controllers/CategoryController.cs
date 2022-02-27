using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAM.Models;
using MAM.Repository;

namespace MAM.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategory icategory;

        public CategoryController() {
            this.icategory = new CategoryRepository(new MAMDBEntities());
        }
        // GET: Category
        [AllowAnonymous]
        public ActionResult Index()
        {
            var categoryList = icategory.GetAllCategories().ToList();
            return View(categoryList);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var getcat = icategory.GetCategoryById(id);
            var category = new Category();
            category.CategoryName = getcat.CategoryName;
            category.Id = getcat.Id;
            return View(category);
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Category());
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Category category)
        {
            try
            {
                // TODO: Add insert logic here
                var addCategory = new Category();
                addCategory.CategoryName = category.CategoryName;
                addCategory.CreatedBy = "Masud";
                addCategory.CreatedDate = DateTime.Now;
                icategory.InsertCategory(addCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var getcat = icategory.GetCategoryById(id);
            var category = new Category();
            category.CategoryName = getcat.CategoryName;
            category.ModifiedBy = "Masud";
            category.ModifiedDate = DateTime.Now;
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                icategory.UpdataCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var getCat = icategory.GetCategoryById(id);
            return View(getCat);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                icategory.DeleteCategory(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
