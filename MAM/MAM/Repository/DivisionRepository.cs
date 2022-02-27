using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAM.Models;
using MAM.Repository;

namespace MAM.Repository
{
    public class DivisionRepository : IDivision
    {
        private MAMDBEntities mAMDBEntities;

        public DivisionRepository(MAMDBEntities mAMDBEntities)
        {
            this.mAMDBEntities = mAMDBEntities;
        }

        public void DeleteDivision(int divId)
        {
            Division div = mAMDBEntities.Divisions.Find(divId);
            mAMDBEntities.Divisions.Remove(div);
            mAMDBEntities.SaveChanges();
        }

        public IEnumerable<Division> GetAllDivisions()
        {
            return mAMDBEntities.Divisions.ToList();
        }

        public Division GetDivisionById(int divId)
        {
            return mAMDBEntities.Divisions.Find(divId);
        }

        public void InsertDivision(Division division)
        {
            mAMDBEntities.Divisions.Add(division);
            mAMDBEntities.SaveChanges();
        }

        public void UpdataDivision(Division division)
        {
            mAMDBEntities.Entry(division).State = System.Data.Entity.EntityState.Modified;
            mAMDBEntities.SaveChanges();
        }
    }
}