using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class Result<T>
    {
        int _code;
        string _message;
        T _object;

        public Result(CampaignMonitorAPI.Result result, T returnObject)
        {
            _code = result.Code;
            _message = result.Message;
            _object = returnObject;
        }

        public Result(int code, string message, T returnObject)
        {
            _code = code;
            _message = message;
            _object = returnObject;
        }

        public int Code
        {
            get { return _code; }
        }

        public string Message
        {
            get { return _message; }
        }

        public T ReturnObject
        {
            get { return _object; }
        }
    }
}
