using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAM.Models;

namespace MAM.Repository
{
    public class CategoryRepository : ICategory
    {
        //private MAMDBEntities mamdb;
        private MAMDBEntities mAMDBEntities;

        public CategoryRepository(MAMDBEntities mAMDBEntities)
        {
            this.mAMDBEntities = mAMDBEntities;
        }

        public void DeleteCategory(int catId)
        {
            Category cat = mAMDBEntities.Categories.Find(catId);
            mAMDBEntities.Categories.Remove(cat);
            mAMDBEntities.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return mAMDBEntities.Categories.ToList();
        }

        public Category GetCategoryById(int catId)
        {
            return mAMDBEntities.Categories.Find(catId);
        }

        public void InsertCategory(Category category)
        {
            mAMDBEntities.Categories.Add(category);
            mAMDBEntities.SaveChanges();
        }

        public void UpdataCategory(Category category)
        {
            mAMDBEntities.Entry(category).State = System.Data.Entity.EntityState.Modified;
            mAMDBEntities.SaveChanges();
        }
    }
}