using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAM.Models;

namespace MAM.Repository
{
    interface ICompany
    {
        void InsertCompany(Company company);
        IEnumerable<Company> GetAllCompanys();
        void UpdataCompany(Company company);
        void DeleteCompany(int comId);
        Company GetCompanyById(int comId);
    }
}
