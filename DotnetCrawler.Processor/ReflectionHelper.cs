using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DotnetCrawler.Processor
{
    public class ReflectionHelper
    {
        internal static string GetEntityExpression<TEntity>()
        {
            var entityAttribute = (typeof(TEntity)).GetCustomAttribute<CaldwellEntityAttribute>();
            if (entityAttribute == null || string.IsNullOrWhiteSpace(entityAttribute.XPath))
                throw new Exception("This entity should be xpath");

            return entityAttribute.XPath;
        }

        public static Dictionary<string, Tuple<SelectorType, string>> GetPropertyAttributes<TEntity>()
        {
            var attributeDictionary = new Dictionary<string, Tuple<SelectorType, string>>();

            PropertyInfo[] props = typeof(TEntity).GetProperties();
            var propList = props.Where(p => p.CustomAttributes.Count() > 0);

            foreach (PropertyInfo prop in propList)
            {
                var attr = prop.GetCustomAttribute<CaldwellFieldAttribute>();
                if (attr != null)
                {
                    attributeDictionary.Add(prop.Name, Tuple.Create(attr.SelectorType, attr.Expression));
                }
            }
            return attributeDictionary;
        }

        internal static object CreateNewEntity<TEntity>()
        {
            object instance = Activator.CreateInstance(typeof(TEntity));
            return instance;
        }

        internal static void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }
    }
}
