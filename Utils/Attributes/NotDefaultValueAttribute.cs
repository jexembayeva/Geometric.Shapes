using System;
using System.ComponentModel.DataAnnotations;

namespace Utils.Attributes
{
    public class NotDefaultValueAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not have the default value";

        public NotDefaultValueAttribute()
            : base(DefaultErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var type = value.GetType();
            if (type.IsValueType)
            {
                var defaultValue = Activator.CreateInstance(type);
                return !value.Equals(defaultValue);
            }

            // non-null ref type
            return true;
        }
    }
}
