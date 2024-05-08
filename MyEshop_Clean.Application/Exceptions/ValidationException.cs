using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace MyEshop_Clean.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validation)
        {
            foreach (var validationFailure in validation.Errors)
            {
                Errors.Add(validationFailure.ErrorMessage);
            }
        }
    }
}
