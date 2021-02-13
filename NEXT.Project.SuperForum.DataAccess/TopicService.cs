using NEXT.Project.SuperForum.Data;
using System;
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

        public Topic GetTopic(Guid id)
        {
            using (var context = new SuperForumContext())
            {
                return context.Set<Topic>().Find(id);
            }
        }

        public List<Topic> GetTopics()
        {
            using (var context = new SuperForumContext())
            {
                return (from topic in context.Topics
                        select topic).ToList();
            }
        }

        public void Update(Topic topic)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(topic).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(GetTopic(id)).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
