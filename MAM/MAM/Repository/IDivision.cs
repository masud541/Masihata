using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAM.Models;

namespace MAM.Repository
{
    interface IDivision
    {
        void InsertDivision(Division division);
        IEnumerable<Division> GetAllDivisions();
        void UpdataDivision(Division division);
        void DeleteDivision(int divId);
        Division GetDivisionById(int divId);
    }
}
