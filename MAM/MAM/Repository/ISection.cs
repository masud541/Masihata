using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAM.Models;

namespace MAM.Repository
{
    interface ISection
    {
        void InsertSection(Section section);
        IEnumerable<Section> GetAllSections();
        void UpdataSection(Section section);
        void DeleteSection(int secId);
        Section GetSectionById(int sectId);
        IList<Division> GetAllDivisions();
        
    }
}
