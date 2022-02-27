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
    public class RequisitionInfoController : Controller
    {
        private  IRequisitionInfo iRequisitionInfo;

        public RequisitionInfoController()
        {
            this.iRequisitionInfo = new RequisitionInfoRepository(new MAMDBEntities());
        }


        // GET: RequisitionInfo
        [AllowAnonymous]
        public ActionResult Index()
        {
            var reqList = iRequisitionInfo.GetAllRequisitionInfos().ToList();
            List<RequisitionInfo> requisitions = new List<RequisitionInfo>();

            

            foreach (var req in reqList)
            {
                RequisitionInfo obj = new RequisitionInfo();

                obj.CategoryName = req.Category.CategoryName;
                obj.DivisionName = req.Division.DivisionName;
                obj.CompanyName = req.Company.CompanyName;
                obj.SectionName = req.Section.SectionName;
                obj.ItemName = req.ItemName;
                obj.RequisitionNo = req.RequisitionNo;
                obj.ProductHistory = req.ProductHistory;
                obj.ReqDate = req.ReqDate;
                obj.FloorName = req.FloorName;
                obj.QuotationImage = req.QuotationImage;
                obj.Id = req.Id;
                requisitions.Add(obj);
            }

            return View(requisitions);
        }

        // GET: RequisitionInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequisitionInfo/Create
        public ActionResult Create()
        {
            ViewBag.divisionNames = getDivisionList().ToList();
            ViewBag.SectionName = getSectionList().ToList();
            ViewBag.CompanyName = getCompanyList().ToList();
            ViewBag.CategoryName = getCategoryList().ToList();
            ViewBag.FloorList = getFloorList().ToList();
            return View();
        }

        // POST: RequisitionInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, RequisitionInfo requisition, HttpPostedFileBase qImage)
        {
            try
            {
                // TODO: Add insert logic here

                var addReq = new RequisitionInfo();
                addReq.SectionId = requisition.SectionId;
                addReq.DivisionId = requisition.DivisionId;
                addReq.CompanyId = requisition.CompanyId;
                addReq.CategoryId = requisition.CategoryId;
                addReq.ReqDate = requisition.ReqDate;
                addReq.RequisitionNo = requisition.RequisitionNo;
                addReq.ReqQty = requisition.ReqQty;
                addReq.FloorName = requisition.FloorName;
                addReq.RequisitionPurpose = requisition.RequisitionPurpose;
                addReq.ProductHistory = requisition.ProductHistory;
                addReq.CreatedBy = "Masud";
                addReq.CreatedDate = DateTime.Now;
                if(qImage != null)
                {
                    addReq.QuotationImage = new byte[qImage.ContentLength];
                    qImage.InputStream.Read(addReq.QuotationImage, 0, qImage.ContentLength);
                }
                iRequisitionInfo.InsertRequisition(addReq);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequisitionInfo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.divisionNames = getDivisionList().ToList();
                ViewBag.SectionName = getSectionList().ToList();
                ViewBag.CompanyName = getCompanyList().ToList();
                ViewBag.CategoryName = getCategoryList().ToList();
                ViewBag.FloorList = getFloorList().ToList();

                var requisition = iRequisitionInfo.GetRequisitionInfoById(id);

                RequisitionInfo req = new RequisitionInfo();
                req.SectionName = requisition.Section.SectionName;
                req.SectionId = requisition.SectionId;
                req.DivisionName = requisition.Division.DivisionName;
                req.DivisionId = requisition.DivisionId;
                req.CategoryName = requisition.Category.CategoryName;
                req.CategoryId = requisition.CategoryId;
                req.CompanyName = requisition.Company.CompanyName;
                req.CompanyId = requisition.CompanyId;
                req.FloorName = requisition.FloorName;
                req.RequisitionPurpose = requisition.RequisitionPurpose;
                req.ProductHistory = requisition.ProductHistory;
                req.ItemName = requisition.ItemName;
                req.ReqQty = requisition.ReqQty;
                req.RequisitionNo = requisition.RequisitionNo;
                req.QuotationImage = requisition.QuotationImage;
                req.ReqDate = requisition.ReqDate;

                return View(req);
            }
            catch
            {
                return View();
            }
            return View();
        }

        // POST: RequisitionInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequisitionInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequisitionInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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
            div = iRequisitionInfo.GetAllDivisions().ToList();

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
        public List<SelectListItem> getSectionList()
        {
            List<Section> sec = new List<Section>();
            sec = iRequisitionInfo.GetAllSections().ToList();

            List<SelectListItem> secNames = new List<SelectListItem>();
            foreach (var s in sec)
            {
                secNames.Add(new SelectListItem
                {
                    Text = s.SectionName,
                    Value = s.Id.ToString()
                });
            }
            return secNames;
        }

        public List<SelectListItem> getCompanyList()
        {
            List<Company> com = new List<Company>();
            com = iRequisitionInfo.GetAllCompanies().ToList();

            List<SelectListItem> comNames = new List<SelectListItem>();
            foreach (var c in com)
            {
                comNames.Add(new SelectListItem
                {
                    Text = c.CompanyName,
                    Value = c.Id.ToString()
                });
            }
            return comNames;
        }

        public List<SelectListItem> getCategoryList()
        {
            List<Category> cats = new List<Category>();
            cats = iRequisitionInfo.GetAllCategories().ToList();

            List<SelectListItem> catNames = new List<SelectListItem>();
            foreach (var cat in cats)
            {
                catNames.Add(new SelectListItem
                {
                    Text = cat.CategoryName,
                    Value = cat.Id.ToString()
                });
            }
            return catNames;
        }

        public List<SelectListItem> getFloorList()
        {
            string[] enumNames = System.Enum.GetNames(typeof(FloorName));
            List<string> names = new List<string>(enumNames);
            List<SelectListItem> fNames = new List<SelectListItem>();

            for (int i=0;i<names.Count; i++)
            {
                fNames.Add(new SelectListItem
                {
                    Text = names[i],
                    Value = names[i]
                });
            }
            return fNames;
        }

        [HttpPost]
        public ActionResult GetSectionsByDivisionId(int divId)
        {
            int statId;
            List<SelectListItem> sectionName = new List<SelectListItem>();
            if (divId>0)
            {
                statId = Convert.ToInt32(divId);
                List<Section> sections = iRequisitionInfo.GetAllSections().Where(x => x.DivisionID == divId).ToList();
                sections.ForEach(x =>
                {
                    sectionName.Add(new SelectListItem { Text = x.SectionName, Value = x.Id.ToString() });
                });
            }
            return Json(sectionName, JsonRequestBehavior.AllowGet);
        }
    }
}
