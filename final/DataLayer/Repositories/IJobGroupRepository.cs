using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IJobGroupRepository
    {
        IEnumerable<JobCategoryTB> GetAllGroups();
        void save();
    }
}
