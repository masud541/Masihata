using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAM.Models;

namespace MAM.Repository
{
    public class CompanyRepository : ICompany
    {
        private MAMDBEntities mAMDBEntities;

        public CompanyRepository(MAMDBEntities mAMDBEntities)
        {
            this.mAMDBEntities = mAMDBEntities;
        }

        public void DeleteCompany(int comId)
        {
            Company com = mAMDBEntities.Companies.Find(comId);
            mAMDBEntities.Companies.Remove(com);
            mAMDBEntities.SaveChanges();
        }

        public IEnumerable<Company> GetAllCompanys()
        {
            return mAMDBEntities.Companies.ToList();
        }

        public Company GetCompanyById(int comId)
        {
            return mAMDBEntities.Companies.Find(comId);
        }

        public void InsertCompany(Company company)
        {
            mAMDBEntities.Companies.Add(company);
            mAMDBEntities.SaveChanges();
        }

        public void UpdataCompany(Company company)
        {
            mAMDBEntities.Entry(company).State = System.Data.Entity.EntityState.Modified;
            mAMDBEntities.SaveChanges();
        }
    }
}