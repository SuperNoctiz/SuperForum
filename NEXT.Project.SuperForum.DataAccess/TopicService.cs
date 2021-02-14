using NEXT.Project.SuperForum.Data;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXT.Project.SuperForum.DataAccess
{
    public class TopicService
    {
        public void Create(Topic topic)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(topic).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public Topic GetTopic(Guid? id)
        {
            using (var context = new SuperForumContext())
            {
                return GetTopics().Where(t => t.Id == id).FirstOrDefault();
            }
        }

        public IList<Topic> GetTopics()
        {
            using (var context = new SuperForumContext())
            {
                return context.Topics.Include(t => t.User).ToList();
            }
        }

        public void Update(Topic topic)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(topic).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(GetTopic(id)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
