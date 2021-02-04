using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utils.Helpers;

namespace Models.Attributes
{
  public class RequiredIfRadiusDisabledAttribute : ValidationAttribute
    {
        public string PropertyName { get; set; }

        public RequiredIfRadiusDisabledAttribute(string propertyName)
        {
            propertyName.ThrowIfNullOrEmpty(nameof(propertyName));

            PropertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var type = instance.GetType();

            var propertyValue = (bool)type.GetProperty(PropertyName)?.GetValue(instance, null);

            if (!propertyValue)
            {
                if (value != null)
                {
                    var valueType = value.GetType();

                    if (valueType.IsValueType)
                    {
                        var defaultValue = Activator.CreateInstance(valueType);

                        if (value.Equals(defaultValue))
                        {
                            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                        }
                    }
                }
                else
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }
}
