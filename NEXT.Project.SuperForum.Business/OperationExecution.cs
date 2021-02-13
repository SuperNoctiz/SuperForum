using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NEXT.Project.SuperForum.Business
{
    public class OperationExecution
    {
        public TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.Timeout = TimeSpan.FromSeconds(30);
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        public OperationResult ExecuteOperation(Action action)
        {
            try
            {
                using (var transaction = CreateTransactionScope())
                {
                    action.Invoke();
                    transaction.Complete();
                    return new OperationResult(true);
                }
            } catch(Exception exception)
            {
                return new OperationResult(exception);
            }
        }

        public OperationResult<T> ExecuteOperation<T>(Func<T> func)
        {
            try
            {
                using (var transaction = CreateTransactionScope())
                {
                    var result = func.Invoke();
                    transaction.Complete();
                    return new OperationResult<T>(result);
                }
            } catch(Exception exception)
            {
                return new OperationResult<T>(exception);
            }
        }
    }
}
