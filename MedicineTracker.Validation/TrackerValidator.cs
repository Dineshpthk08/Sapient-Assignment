using System;
using FluentValidation;
using FluentValidation.Results;
using MedicineTracker.Models;

namespace MedicineTracker.Validation
{
    public class TrackerValidator : AbstractValidator<Medicine>
    {
        public TrackerValidator()
        {
            RuleFor(m => m.Name).NotNull().WithMessage("Please specify a Name.");

            RuleFor(m => m.Quantity).NotNull().WithMessage("Please specify a Quantity.");

            RuleFor(m => m.ExpiryDate).NotNull().WithMessage("Please specify a Expiry Date.");
        }

        protected override bool PreValidate(ValidationContext<Medicine> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please submit a non-null model."));

                return false;
            }
            return true;
        }
    }
}
