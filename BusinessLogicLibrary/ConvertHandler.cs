using System.Reflection;
using System.Linq;
using System;

namespace BusinessLogicLibrary
{
    public static class ConvertHandler
    {
        public static ReturnType ConvertTo<ReturnType>(this object convertable)
        {
            ReturnType output = (ReturnType)Activator.CreateInstance(typeof(ReturnType));
            foreach(PropertyInfo propertyInfo in convertable.GetType().GetProperties())
            {
                if(typeof(ReturnType).GetProperties().Any(property => property.Name == propertyInfo.Name))
                {
                    typeof(ReturnType).GetProperty(propertyInfo.Name).SetValue(output, propertyInfo.GetValue(convertable));
                }
            }
            return output;
        }

    }
}
