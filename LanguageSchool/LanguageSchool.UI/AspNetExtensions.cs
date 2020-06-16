using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using LanguageSchool;


namespace LanguageSchool.UI
{
    public static class AspNetExtensions
    {


        public static void PopulateValidation(this ModelStateDictionary modelState, IEnumerable<Result.Error> errors)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError(error.PropertyName, error.Message);
            }
        }
    }
}
