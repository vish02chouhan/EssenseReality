using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EssenceRealty.Scheduler.ServiceProcessors
{
    public class JsonProcessor<T>
    {
        public T ExtractData<T>(JToken item)
        {
            try
            {
                T obj = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] properties = typeof(T).GetProperties();

                var dataDictionary = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(item.ToString());

                foreach (PropertyInfo property in properties)
                {
                    SetData(dataDictionary, property, ref obj);
                }
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetData<T>(Dictionary<string, dynamic> dataDictionary, PropertyInfo property, ref T obj)
        {
            if (!(property.PropertyType.IsClass || property.PropertyType.BaseType == null) || (property.PropertyType == typeof(string)))
            {
                string fieldName = char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1);

                if (!string.IsNullOrEmpty(fieldName))
                {
                    if (dataDictionary.ContainsKey(fieldName))
                    {
                        GetValue(dataDictionary[fieldName], property, fieldName, ref obj);
                    }
                    else
                    {
                        GetValueFromChild(dataDictionary, property, fieldName, ref obj);
                    }
                }
            }
        }

        private void GetValue<T>(dynamic fieldValue, PropertyInfo property, string fieldName, ref T obj)
        {
            if (fieldValue != null && fieldValue.ToString().Length > 0)
            {
                var type = GetValueType(property);
                var value = Convert.ChangeType(fieldValue, type);
                property.SetValue(obj, value);
            }
        }

        private void GetValueFromChild<T>( Dictionary<string, dynamic> dataDictionary, PropertyInfo property, string fieldName, ref T obj)
        {
            foreach (var item in dataDictionary)
            {
                if (item.Value != null)
                {
                    if (item.Value.ToString().Contains(fieldName))
                    {
                        try
                        {
                            var fieldValue = item.Value[fieldName];
                            if (fieldValue != null && fieldValue.ToString().Length > 0)
                            {
                                var type = GetValueType(property);
                                var value = Convert.ChangeType(fieldValue, type);
                                property.SetValue(obj, value);
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private Type GetValueType(PropertyInfo property)
        {
            var type = property.PropertyType;
            if (property.PropertyType.ToString().Contains("Nullable"))
            {
                type = Nullable.GetUnderlyingType(property.PropertyType);
            }

            return type;
        }

    }
}
