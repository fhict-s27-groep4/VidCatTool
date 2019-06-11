namespace Data_Layer.ErrorLog
{
    internal interface IDataBaseErrorLogger
    {
        void LogDataBaseError(string _query, string _errorMessage, string _callStack, string _dateTime);
    }
}