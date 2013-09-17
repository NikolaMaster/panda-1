using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.Engine.Binders
{

    [AttributeUsage(AttributeTargets.Property)]
    public class ValueFromAttribute : Attribute
    {
        public string AttributeCode { get; private set; }

        public ValueFromAttribute(string attributeCode)
        {
            AttributeCode = attributeCode;
        }
    }

    public class ValueFromAttributeConverter
    {
        public static void ModelFromAttributes<TModel>(TModel model, IEnumerable<AttribValue> attributeValues, DataAccessLayer dataAccessLayer)
        {
            var attribValues = attributeValues as AttribValue[] ?? attributeValues.ToArray();
            //get all properties from model object with ValueFromAttribute attribute
            var type = typeof(TModel);
            var properties = type.GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof (ValueFromAttribute)))
                .Select(x => new
                {
                    property = x,
                    attribute = Attribute.GetCustomAttribute(x, typeof (ValueFromAttribute)) as ValueFromAttribute,
                });

            foreach (var property in properties)
            {
                //get attribute
                var attributeCode = property.attribute.AttributeCode;

                var attrib = attribValues.Single(x => x.Attrib.Code == attributeCode);
                
                //try to parse to different types
                var stringValue = attrib.Value;
                DateTime? dateTimeValue;
                int intValue;
                bool boolValue;

                DateTime tmpDateTime;
                dateTimeValue = DateTime.TryParse(stringValue, out tmpDateTime) ? tmpDateTime : (DateTime?)null;
                int.TryParse(stringValue, out intValue);
                bool.TryParse(stringValue, out boolValue);

                //find type and set value to finalValue
                object finalValue; 
                var attribTypeName = attrib.Attrib.AttribType.Type;
                var isPropertyString = property.property.PropertyType == typeof (string);
                if (attribTypeName == typeof (DateTime).FullName)
                {
                    finalValue = isPropertyString ? (object)dateTimeValue.ToPandaString() : dateTimeValue;
                }
                else if (attribTypeName == typeof (bool).FullName)
                {
                    finalValue = isPropertyString ? (object)boolValue.ToPandaString() : boolValue;
                }
                else if (attribTypeName == typeof (int).FullName)
                {
                    finalValue = isPropertyString ? (object)intValue.ToPandaString() : intValue;
                }
                else
                {
                    finalValue = stringValue;
                }

                property.property.SetValue(model, finalValue); 
            }
        }

        public static void AttributesFromModel<TModel>(TModel model, IEnumerable<AttribValue> attributeValues, DataAccessLayer dataAccessLayer)
        {

            var type = typeof(TModel);
            var properties = type.GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(ValueFromAttribute)))
                .Select(x => new
                {
                    property = x,
                    attribute = Attribute.GetCustomAttribute(x, typeof(ValueFromAttribute)) as ValueFromAttribute,
                });

            var attribValues = attributeValues as AttribValue[] ?? attributeValues.ToArray();

            foreach (var property in properties)
            {
                var attributeCode = property.attribute.AttributeCode;

                var attrib = attribValues.Single(x => x.Attrib.Code == attributeCode);

                var rawValue = property.property.GetValue(model);
                string finalValue;


                var attribTypeName = attrib.Attrib.AttribType.Type;
                if (rawValue is DateTime)
                {
                    finalValue = ((DateTime)rawValue).ToPandaString();
                }
                else if (rawValue is bool)
                {
                    finalValue = ((bool)rawValue).ToPandaString();
                }
                else if (rawValue is double)
                {
                    finalValue = ((double)rawValue).ToPandaString();
                }
                else if (rawValue is int)
                {
                    finalValue = ((int)rawValue).ToPandaString();
                }
                else
                {
                    finalValue = rawValue != null ? rawValue.ToString() : null;
                }
                attrib.Value = finalValue;    
            }
        }
    }
}