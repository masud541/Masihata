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
    public class CompanyController : Controller
    {
        private ICompany icompany;

        public CompanyController()
        {
            this.icompany = new CompanyRepository(new MAMDBEntities());
        }
        [AllowAnonymous]
        // GET: Company
        public ActionResult Index()
        {
            var companyList = icompany.GetAllCompanys().ToList();
            return View(companyList);
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Company company)
        {
            try
            {
                // TODO: Add insert logic here

                var addCompany = new Company();
                addCompany.CompanyName = company.CompanyName;
                addCompany.Address = company.Address;
                addCompany.CreatedBy = "Masud";
                addCompany.CreatedDate = DateTime.Now;

                icompany.InsertCompany(addCompany);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            var com = icompany.GetCompanyById(id);
            Company company = new Company();
            company.CompanyName = com.CompanyName;
            company.Address = com.Address;
            company.ModifiedBy = "Masud";
            company.ModifiedDate = DateTime.Now;

            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(Company company, FormCollection collection)
        {
            try
            {
                icompany.UpdataCompany(company);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            var getCom = icompany.GetCompanyById(id);
            return View(getCom);
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                icompany.DeleteCompany(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
