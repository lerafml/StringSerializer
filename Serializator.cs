using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StringSerializer
{
    public class Serializator
    {
        public static string Stringify(object obj)
        {
            StringBuilder sb = new StringBuilder();
            Type type = obj.GetType();
            foreach (FieldInfo field in type.GetFields())
            {
                sb.Append($"{field.Name}:{(field.GetValue(obj) != null ? field.GetValue(obj).ToString() : "")};");
            }
            return sb.ToString();
        }

        public static T Destringify<T>(string str) where T : new()
        {
            T obj = new T();
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();
            var pairs = str.Split(';').Select(p => p.Split(":"));
            foreach (FieldInfo field in fields)
            {
                var pair = pairs.FirstOrDefault(s => s[0] == field.Name);
                if (pair != null)
                {
                    object val = Convert.ChangeType(pair[1], field.FieldType);
                    field.SetValue(obj, val);
                }
            }
            return obj;
        }
    }
}
