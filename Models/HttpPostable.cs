using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TEFL_App.Models
{
    public abstract class HttpPostable
    {
        public virtual Dictionary<string, string> ConvertToDict()
        {
            return this.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
               .ToDictionary(prop => prop.Name, prop => GetPropStringVal(prop));
        }

        private string GetPropStringVal(PropertyInfo prop)
        {
            if (prop.GetValue(this, null) != null)
            {
                if (prop.PropertyType == typeof(byte[]))
                {
                    return Convert.ToBase64String((byte[])prop.GetValue(this, null));
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    return ((DateTime)prop.GetValue(this, null)).ToString("dd/MM/yyyy HH:mm:ss", App.CultureInfo);//API controller required date format
                }
                else if (prop.PropertyType == typeof(Nullable<DateTime>))
                {
                    DateTime? val = (DateTime?)prop.GetValue(this, null);

                    if (val.HasValue)
                    {
                        return val.Value.ToString("dd/MM/yyyy HH:mm:ss", App.CultureInfo);//API controller required date format
                    }
                    else
                    {
                        return "null";
                    }
                }
                else
                {
                    return prop.GetValue(this, null).ToString();
                }
            }
            else
            {
                return "";
            }
        }
    }
}
