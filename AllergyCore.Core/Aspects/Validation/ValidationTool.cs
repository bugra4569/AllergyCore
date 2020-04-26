using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Core.Aspects.Validation
{
    public static class ValidationTool
    {
        public static ValidationResult Validate(IValidator validator, object entity)
        {
            ValidationResult result = validator.Validate(entity);
            return result;
        }
    }
}
