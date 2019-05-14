using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Data_Layer
{
    public static class Converter
    {
        public static IEnumerable<ReturnType> ConvertDatasetToModel<ReturnType>(DataSet dataSet)
        {
            List<ReturnType> outputList = new List<ReturnType>();
            ReturnType output = (ReturnType)Activator.CreateInstance(typeof(ReturnType));

            List<Dictionary<string, object>> allData = new List<Dictionary<string, object>>();

            foreach (DataTable table in dataSet.Tables)
            {
                List<DataColumn> columnNames = new List<DataColumn>();

                foreach (DataColumn column in table.Columns)
                {
                    columnNames.Add(column);
                }

                foreach (DataRow row in table.Rows)
                {
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    for (int i = 0; i < columnNames.Count; i++)
                    {
                        data.Add(columnNames[i].ColumnName, row[i]);
                    }
                    allData.Add(data);
                }
            }

            foreach (Dictionary<string, object> row in allData)
            {
                foreach (PropertyInfo propertyInfo in output.GetType().GetProperties())
                {
                    Type propertyType = propertyInfo.PropertyType;

                    if (row.ContainsKey(propertyInfo.Name))
                    {
                        typeof(ReturnType).GetProperty(propertyInfo.Name).SetValue(output, row[propertyInfo.Name]);
                    }
                }
                outputList.Add(output);
                output = (ReturnType)Activator.CreateInstance(typeof(ReturnType));
            }

            return outputList;
        }
    }
}
