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
    public class DivisionController : Controller
    {
        private IDivision idivision;

        public DivisionController()
        {
            this.idivision = new DivisionRepository(new MAMDBEntities());
        }
        [AllowAnonymous]
        // GET: Disision
        public ActionResult Index()
        {
            var divList = idivision.GetAllDivisions().ToList();
            return View(divList);
        }

        // GET: Disision/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Disision/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disision/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Division division)
        {
            try
            {
                var addDivision = new Division();
                addDivision.DivisionName = division.DivisionName;
                addDivision.CreatedBy = "Masud";
                addDivision.CreatedDate = DateTime.Now;
                idivision.InsertDivision(addDivision);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Disision/Edit/5
        public ActionResult Edit(int id)
        {
            var getDiv = idivision.GetDivisionById(id);

            Division division = new Division();
            division.DivisionName = getDiv.DivisionName;
            division.ModifiedBy = "Masud";
            division.ModifiedDate = DateTime.Now;

            return View(division);
        }

        // POST: Disision/Edit/5
        [HttpPost]
        public ActionResult Edit(Division division, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                idivision.UpdataDivision(division);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Disision/Delete/5
        public ActionResult Delete(int id)
        {
            var getDiv = idivision.GetDivisionById(id);
            return View(getDiv);
        }

        // POST: Disision/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                idivision.DeleteDivision(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
