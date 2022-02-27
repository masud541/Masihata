using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAM.Models;

namespace MAM.Repository
{
    interface IRequisitionInfo
    {
        void InsertRequisition(RequisitionInfo requisition);
        IEnumerable<RequisitionInfo> GetAllRequisitionInfos();
        void UpdataRequisitionInfo(RequisitionInfo requisition);
        void DeleteRequisitionInfo(int secId);
        RequisitionInfo GetRequisitionInfoById(int ReqId);

        IList<Category> GetAllCategories();
        IList<Company> GetAllCompanies();
        IList<Division> GetAllDivisions();
        IList<Section> GetAllSections();
    }
}
