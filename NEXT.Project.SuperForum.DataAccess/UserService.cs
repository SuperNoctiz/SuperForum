using NEXT.Project.SuperForum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXT.Project.SuperForum.DataAccess
{
    public class UserService
    {
        public void Create(User user)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public User GetUser(Guid id)
        {
            using (var context = new SuperForumContext())
            {
                return context.Set<User>().Find(id);
            }
        }

        public User GetUserByName(string name)
        {
            using (var context = new SuperForumContext())
            {
                var query = (from user in context.Users
                             where user.Name == name
                             select user);
                return query.First();
            }
        }

        public List<User> GetUsers()
        {
            using (var context = new SuperForumContext())
            {
                return (from user in context.Users
                        select user).ToList();
            }
        }

        public void Update(User user)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new SuperForumContext())
            {
                context.Entry(GetUser(id)).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
