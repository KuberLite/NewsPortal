using NewsPortal.FetcherFacade.Abstraction;
using NewsPortal.FetcherFacade.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace NewsPortal.FetcherFacade
{
    internal class XmlFetcher<TModel> : IXmlFetcher<TModel>
        where TModel : class, IModelFromXml
    {
        public List<TModel> GetItems(string xmlContent, string containingNodeName)
        {
            try
            {
                using (var reader = new StringReader(xmlContent))
                {
                    var xmlFeedItems = XDocument.Load(reader, LoadOptions.PreserveWhitespace)
                    .Descendants(containingNodeName);

                    return xmlFeedItems.Select(x => GetItemFromXElement(x))
                        .ToList();
                }
            }
            catch (Exception e)
            {
                // TODO: add logging
                throw e;
            }
        }

        private TModel GetItemFromXElement(XElement element)
        {
            var item = Activator.CreateInstance<TModel>();
            var properties = typeof(TModel)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var names = element.Elements().Select(x => x);

                var propertyValue = element.Elements()
                    .FirstOrDefault(x => string.Equals(x.Name.LocalName, property.Name, StringComparison.InvariantCultureIgnoreCase))
                    ?.Value;

                if (propertyValue != null)
                {
                    property.SetValue(
                        item,
                        Convert.ChangeType(propertyValue, property.PropertyType, CultureInfo.InvariantCulture));
                }
            }

            return item;
        }
    }
}
