using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Awesomecorp.Integration
{

    public interface IPropertyLister<T>
    {
        public IEnumerable<PropertyInfo> Properties { get;  }
        public void Load();
    }
    /// <summary>
    /// List Properties of Type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyLister<T> : IPropertyLister<T>
    {

        public IEnumerable<PropertyInfo> Properties { get; private set; }

        public PropertyLister()
        {
            
        }

        public void Load()
        {
            if(Properties == null)
            {
                Type myType = typeof(T);
                Properties = new List<PropertyInfo>(myType.GetProperties().Where(prop => prop.PropertyType.IsPublic));
            }
            

        }

    }
}
