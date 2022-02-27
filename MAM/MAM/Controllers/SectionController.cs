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
    
    public class SectionController : Controller
    {
        private ISection isection;

        public SectionController()
        {
            this.isection = new SectionRepository(new MAMDBEntities());
        }

        [AllowAnonymous]
        // GET: Section
        public ActionResult Index()
        {
            var secList = isection.GetAllSections().ToList();
            List<Section> sections = new List<Section>();

            Section obj = new Section();

            foreach(var sec in secList)
            {
                obj.SectionName = sec.SectionName;
                obj.DivisionName = sec.Division.DivisionName;
                obj.Id = sec.Id;
                sections.Add(obj);
            }

            return View(sections);
        }

        // GET: Section/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Section/Create
        public ActionResult Create()
        {            
            ViewBag.divisionNames = getDivisionList().ToList();
            return View();
        }

        // POST: Section/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Section section)
        {
            try
            {
                var addSection = new Section();
                addSection.SectionName = section.SectionName;
                addSection.DivisionID = section.DivisionID;
                addSection.CreatedBy = "Masud";
                addSection.CreatedDate = DateTime.Now;
                isection.InsertSection(addSection);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Section/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.divisionNames = getDivisionList().ToList();

                var getSection = isection.GetSectionById(id);

                Section section = new Section();
                section.SectionName = getSection.SectionName;
                section.DivisionID = getSection.DivisionID;
                section.ModifiedBy = "Masud";
                section.ModifiedDate = DateTime.Now;
                section.DivisionName = getSection.Division.DivisionName;

                return View(section);
            }
            catch
            {
                return View();
            }           
        }

        // POST: Section/Edit/5
        [HttpPost]
        public ActionResult Edit(Section sec, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                isection.UpdataSection(sec);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Section/Delete/5
        public ActionResult Delete(int id)
        {
            var getSection = isection.GetSectionById(id);
            return View(getSection);
        }

        // POST: Section/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                isection.DeleteSection(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public List<SelectListItem> getDivisionList()
        {
            List<Division> div = new List<Division>();
            div = isection.GetAllDivisions().ToList();

            List<SelectListItem> divNames = new List<SelectListItem>();
            foreach (var d in div)
            {
                divNames.Add(new SelectListItem
                {
                    Text = d.DivisionName,
                    Value = d.Id.ToString()
                });
            }
            return divNames;
        }
    }
}
