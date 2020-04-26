using AllergyCore.Entity.EntityFramework.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Business.ValidationRules
{
    public class IngredientValidator : AbstractValidator<Ingredients>
    {
        public IngredientValidator()
        {
            RuleFor(p => p.Amount).GreaterThan(0);
            RuleFor(p => p.FoodId).NotNull().GreaterThan(0);
            RuleFor(p => p.MaterialId).NotNull().GreaterThan(0);
            RuleFor(p => p.UnitId).NotNull().GreaterThan(0);
        }
    }
}
