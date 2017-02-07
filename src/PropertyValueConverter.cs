using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;

namespace mindrevolution.ContentTracking
{
    [PropertyValueType(typeof(Models.PageMeta))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.ContentCache)]
    public class ContentTrackingPropertyConverter : IPropertyValueConverter
    {
        /*
         * There are two options for implementing the meta data for a value converter, 
         * the first method is to use class attributes and the second is to implement
         * the IPropertyValueConverterMeta interface, this is only available in Umbraco v7.1.5+
         * 
         * https://our.umbraco.org/documentation/extending/property-editors/value-converters
         */
        //public Type GetPropertyValueType(PublishedPropertyType propertyType)
        //{
        //    return typeof(IPublishedContent);
        //}

        public bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("mindrevolution.ContentTracking");
        }
        
        public ContentTrackingPropertyConverter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public object ConvertDataToSource(PublishedPropertyType propertyType, object data, bool preview)
        {
            return Models.PageMeta.Deserialize(data as string);
        }

        public object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }

        /*
         * Note: This method is not currently requested in Umbraco v7.1.x but it will be in a future version
         * 
         * https://our.umbraco.org/documentation/extending/property-editors/value-converters
         */
        public object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            return null;
        }
    }
}
