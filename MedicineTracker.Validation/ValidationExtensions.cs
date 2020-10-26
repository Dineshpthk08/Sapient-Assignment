using System.Collections.Generic;
using FluentValidation.Results;
using MedicineTracker.Models;

namespace MedicineTracker.Validation
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this Medicine medicine, out IEnumerable<string> errors)
        {
            var validator = new TrackerValidator();

            var validationResult = validator.Validate(medicine);

            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

            return errors;
        }
    }
}
