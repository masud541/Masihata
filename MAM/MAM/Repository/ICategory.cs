using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAM.Models;

namespace MAM.Repository
{
    interface ICategory
    {
        void InsertCategory(Category category);
        IEnumerable<Category> GetAllCategories();
        void UpdataCategory(Category category);
        void DeleteCategory(int catId);
        Category GetCategoryById(int catId);

    }
}
