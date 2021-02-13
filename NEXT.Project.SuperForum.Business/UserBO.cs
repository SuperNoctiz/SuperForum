using NEXT.Project.SuperForum.Data;
using NEXT.Project.SuperForum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXT.Project.SuperForum.Business
{
    public class UserBO
    {
        public OperationResult Create(User user)
        {
            var operationExecution = new OperationExecution();

            Action create = () =>
            {
                var userService = new UserService();
                userService.Create(user);
            };

            return operationExecution.ExecuteOperation(create);
        }

        public OperationResult Get(Guid id)
        {
            var operationExecution = new OperationExecution();

            Func<User> get = () =>
            {
                var userService = new UserService();
                return userService.GetUser(id);
            };

            return operationExecution.ExecuteOperation(get);
        }

        public OperationResult Update(User user)
        {
            var operationExecution = new OperationExecution();

            Action update = () =>
            {
                var userService = new UserService();
                userService.Update(user);
            };

            return operationExecution.ExecuteOperation(update);
        }

        public OperationResult Delete(Guid id)
        {
            var operationExecution = new OperationExecution();

            Action delete = () =>
            {
                var userService = new UserService();
                userService.Delete(id);
            };

            return operationExecution.ExecuteOperation(delete);
        }
    }
}
