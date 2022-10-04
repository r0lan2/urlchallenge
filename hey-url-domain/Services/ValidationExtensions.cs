using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using hey_url_domain.Model;

namespace hey_url_domain.Services
{
    public static class ValidationExtensions
    {
        public static void SetValidationsWhenValidationsAreNotOk(this ResponseBase response, ValidationResult result)
        {
            response.IsOk = false;
            response.ValidationErrors = new List<string>();
            foreach (var error in result.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }
    }
}
