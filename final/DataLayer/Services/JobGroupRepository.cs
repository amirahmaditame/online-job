using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public JobCategoryTB GetGroupById(int groupId)
        {
            return db.JobCategoryTB.Find(groupId);
        }
        public bool InsertGroup(JobCategoryTB JobCategory)
        {
            try
            {
                db.JobCategoryTB.Add(JobCategory);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateGroup(JobCategoryTB JobCategory)
        {
            try
            {
                db.Entry(JobCategory).State = EntityState.Modified; 
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteGroup(JobCategoryTB JobCategory)
        {
            try
            {
                db.Entry(JobCategory).State = EntityState.Deleted;
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                var group = GetGroupById(groupId);
                DeleteGroup(group);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
