using DotnetCrawler.Data.Repository;
using DotnetCrawler.Processor.Attributes;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Processor
{
    public class DotnetCrawlerProcessor<TEntity> where TEntity : class, IEntity
    {
        public async Task<IEnumerable<TEntity>> Process(HtmlDocument document)
        {
            var nameValueDictionary = GetColumnNameValuePairsFromHtml(document);

            var processorEntity = ReflectionHelper.CreateNewEntity<TEntity>();
            foreach (var pair in nameValueDictionary)
            {
                ReflectionHelper.TrySetProperty(processorEntity, pair.Key, pair.Value);
            }

            // TODO : Remove
            ReflectionHelper.TrySetProperty(processorEntity, "CatalogTypeId", 1);
            ReflectionHelper.TrySetProperty(processorEntity, "CatalogBrandId", 1);

            return new List<TEntity>
            {
                processorEntity as TEntity
            };
        }

        private static Dictionary<string, string> GetColumnNameValuePairsFromHtml(HtmlDocument document)
        {
            var columnNameValueDictionary = new Dictionary<string, string>();

            var entityExpression = ReflectionHelper.GetEntityExpression<TEntity>();
            var propertyExpressions = ReflectionHelper.GetPropertyAttributes<TEntity>();

            var entityNode = document.DocumentNode.SelectSingleNode(entityExpression);

            foreach (var expression in propertyExpressions)
            {
                var columnName = expression.Key;
                var columnValue = string.Empty;
                var fieldExpression = expression.Value.Item2;

                switch (expression.Value.Item1)
                {
                    case SelectorType.XPath:
                        var node = entityNode.SelectSingleNode(fieldExpression);
                        if (node != null)
                            columnValue = node.InnerText;
                        break;
                    case SelectorType.CssSelector:
                        var nodeCss = entityNode.QuerySelector(fieldExpression);
                        if (nodeCss != null)
                            columnValue = nodeCss.InnerText;
                        break;
                    default:
                        break;
                }

                columnNameValueDictionary.Add(columnName, columnValue);
            }

            return columnNameValueDictionary;
        }
    }
}
