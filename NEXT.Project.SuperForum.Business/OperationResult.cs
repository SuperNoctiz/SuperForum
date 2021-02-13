using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXT.Project.SuperForum.Business
{
    public class OperationResult
    {
        private bool _hasSucceededBeenChecked = false;

        private bool _hasSucceeded;

        public bool HasSucceeded
        {
            get
            {
                _hasSucceededBeenChecked = true;
                return _hasSucceeded;
            }

            set { _hasSucceeded = value; }
        }

        private Exception _exception;

        public Exception Exception
        {
            get { return _exception; }
            set { _exception = value; }
        }

        public OperationResult() { }

        public OperationResult(bool value)
        {
            HasSucceeded = value;
        }

        public OperationResult(Exception exception)
        {
            HasSucceeded = false;
            Exception = exception;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        private T _result;

        public T Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public OperationResult() { }

        public OperationResult(T result)
        {
            HasSucceeded = true;
            Result = result;
        }

        public OperationResult(Exception exception)
        {
            HasSucceeded = false;
            Exception = exception;
        }
    }
}
