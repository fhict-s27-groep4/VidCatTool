using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLayer.DataLogger
{
    internal class JSonLogger : IDataBaseErrorLogger
    {
        public JSonLogger()
        {

        }

        public void LogDataBaseError(string _query, string _errorMessage, string _callStack, string _dateTime)
        {
            JObject dbErrors = JObject.Parse(File.ReadAllText(@"..\Data Layer\ErrorLog\DataBaseErrorLog.json"));
            JObject error = new JObject();
            error.Add("query", _query);
            error.Add("errormessage", _errorMessage);
            JArray callstack = new JArray();
            foreach(string call in _callStack.Split("\r\n"))
            {
                JObject jCall = new JObject();
                jCall.Add("call", call.Replace("   ", string.Empty));
                callstack.Add(jCall);
            }
            error.Add("callstack", callstack);
            error.Add("datetime", _dateTime);
            ((JArray)dbErrors["errorlog"]).Add(error);
            StreamWriter stream = new StreamWriter(@"..\DataAccessLayer\DataLogger\DataBaseErrorLog.json");
            stream.Write(JsonConvert.SerializeObject(dbErrors, Formatting.Indented));
            stream.Close();
        }
    }
}
