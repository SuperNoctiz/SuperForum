using NEXT.Project.SuperForum.Data;
using NEXT.Project.SuperForum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXT.Project.SuperForum.Business
{
    public class TopicBO
    {
        public OperationResult Create(Topic topic)
        {
            var operationExecution = new OperationExecution();

            Action create = () =>
            {
                var topicService = new TopicService();
                topicService.Create(topic);
            };

            return operationExecution.ExecuteOperation(create);
        }

        public OperationResult<IQueryable<Topic>> Get()
        {
            var operationExecution = new OperationExecution();

            Func<IQueryable<Topic>> get = () =>
            {
                var topicService = new TopicService();
                return topicService.GetTopics().AsQueryable();
            };

            return operationExecution.ExecuteOperation(get);
        }

        public OperationResult<Topic> Get(Guid? id)
        {
            var operationExecution = new OperationExecution();

            Func<Topic> get = () =>
            {
                var topicService = new TopicService();
                return topicService.GetTopic(id);
            };

            return operationExecution.ExecuteOperation(get);
        }

        public OperationResult Update(Topic topic)
        {
            var operationExecution = new OperationExecution();

            Action update = () =>
            {
                var topicService = new TopicService();
                topicService.Update(topic);
            };

            return operationExecution.ExecuteOperation(update);
        }

        public OperationResult Delete(Guid id)
        {
            var operationExecution = new OperationExecution();

            Action delete = () =>
            {
                var topicService = new TopicService();
                topicService.Delete(id);
            };

            return operationExecution.ExecuteOperation(delete);
        }
    }
}
