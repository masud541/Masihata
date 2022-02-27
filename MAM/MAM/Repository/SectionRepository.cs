using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAM.Models;
using MAM.Repository;

namespace MAM.Repository
{
    public class SectionRepository : ISection
    {
        private MAMDBEntities mAMDBEntities;

        public SectionRepository(MAMDBEntities mAMDBEntities)
        {
            this.mAMDBEntities = mAMDBEntities;
        }

        public void DeleteSection(int secId)
        {
            Section sec =  mAMDBEntities.Sections.Find(secId);
            mAMDBEntities.Sections.Remove(sec);
            mAMDBEntities.SaveChanges();
        }

        public IEnumerable<Section> GetAllSections()
        {
            return mAMDBEntities.Sections.ToList();
        }

        public Section GetSectionById(int sectId)
        {
            return mAMDBEntities.Sections.Find(sectId);
        }

        public void InsertSection(Section section)
        {
            mAMDBEntities.Sections.Add(section);
            mAMDBEntities.SaveChanges();
        }

        public void UpdataSection(Section section)
        {
            mAMDBEntities.Entry(section).State = System.Data.Entity.EntityState.Modified;
            mAMDBEntities.SaveChanges();
        }

        public IList<Division> GetAllDivisions()
        {
            var divisionList = from Division in mAMDBEntities.Divisions select Division;
            var divisionName = divisionList.ToList<Division>();
            return divisionName;
        }
    }
}