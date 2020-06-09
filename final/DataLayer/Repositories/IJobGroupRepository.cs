using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IJobGroupRepository:IDisposable
    {
        IEnumerable<JobCategoryTB> GetAllGroups();
        JobCategoryTB GetGroupById(int groupId);
        bool InsertGroup(JobCategoryTB JobCategory);
        bool UpdateGroup(JobCategoryTB JobCategory);
        bool DeleteGroup(JobCategoryTB JobCategory);
        bool DeleteGroup(int groupId);
        void save();
    }
}
