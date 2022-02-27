using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAM.Models;

namespace MAM.Repository
{
    public class RequisitionInfoRepository : IRequisitionInfo
    {
        private MAMDBEntities mAMDBEntities;

        public RequisitionInfoRepository(MAMDBEntities mAMDBEntities)
        {
            this.mAMDBEntities = mAMDBEntities;
        }

        public void DeleteRequisitionInfo(int reqId)
        {
            RequisitionInfo req = mAMDBEntities.RequisitionInfoes.Find(reqId);
            mAMDBEntities.RequisitionInfoes.Remove(req);
            mAMDBEntities.SaveChanges();
        }

        public IList<Category> GetAllCategories()
        {
            var CategoryList = from Category in mAMDBEntities.Categories select Category;
            var Categories = CategoryList.ToList<Category>();
            return Categories;
        }

        public IList<Company> GetAllCompanies()
        {
            var CompanyList = from Company in mAMDBEntities.Companies select Company;
            var Companies = CompanyList.ToList<Company>();
            return Companies;
        }

        public IList<Division> GetAllDivisions()
        {
            var DivisionList = from Division in mAMDBEntities.Divisions select Division;
            var Divisions = DivisionList.ToList<Division>();
            return Divisions;
        }

        public IEnumerable<RequisitionInfo> GetAllRequisitionInfos()
        {
            return mAMDBEntities.RequisitionInfoes.ToList();
        }

        public IList<Section> GetAllSections()
        {
            var SectionList = from Section in mAMDBEntities.Sections select Section;
            var Sections = SectionList.ToList<Section>();
            return Sections;
        }

        public RequisitionInfo GetRequisitionInfoById(int reqId)
        {
            return mAMDBEntities.RequisitionInfoes.Find(reqId);
        }

        public void InsertRequisition(RequisitionInfo requisition)
        {
            mAMDBEntities.RequisitionInfoes.Add(requisition);
            mAMDBEntities.SaveChanges();
        }

        public void UpdataRequisitionInfo(RequisitionInfo requisition)
        {
            mAMDBEntities.Entry(requisition).State = System.Data.Entity.EntityState.Modified;
            mAMDBEntities.SaveChanges();
        }
    }
}