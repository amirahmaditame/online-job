using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class JobGroupRepository : IJobGroupRepository
    {
        OnlineJobEntities db = new OnlineJobEntities();
        public IEnumerable<JobCategoryTB> GetAllGroups()
        {
            return db.JobCategoryTB;
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
