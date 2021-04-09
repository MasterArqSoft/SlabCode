using CodeFirst.Core.Exceptions;
using CodeFirst.Domain.Settings;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Core
{
    public class ValidateFilterAttribute : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                (string Key, IEnumerable<string>)[] prueba = context.ModelState
                                    .Where(x => x.Value.Errors.Count > 0).Select(x => (x.Key, x.Value.Errors.Select(x => x.ErrorMessage))).ToArray();

                List<ErrorSetting> Errors = new List<ErrorSetting>();

                foreach ((string Key, IEnumerable<string>) item in prueba)
                {
                    foreach (string item2 in item.Item2)
                    {

                        var errorSetting = new ErrorSetting
                        {

                            PropertyName = item.Key,
                            ErrorMessage = item2
                        };
                        Errors.Add(errorSetting);
                    };
                }
                if (Errors.Count != 0)
                {
                    throw new ValidationException(Errors);
                }

            }
            
            await next();

        }
    }


    //public class ValidateFilterAttribute : ResultFilterAttribute
    //{
    //    //public void OnActionExecuted(ActionExecutedContext context)
    //    //{
    //    //    throw new System.NotImplementedException();
    //    //}

    //    //public void OnActionExecuting(ActionExecutingContext context)
    //    //{
    //    //    if (!context.ModelState.IsValid)
    //    //    {
    //    //        context.Result = new BadRequestObjectResult(context.ModelState);
    //    //    }

    //    //}

    //    public override void OnResultExecuting(ResultExecutingContext context)
    //    {
    //        if (!context.ModelState.IsValid)
    //        {
    //            context.Result = new BadRequestObjectResult(context.ModelState);
    //            (string Key, IEnumerable<string>)[] prueba = context.ModelState
    //                                .Where(x => x.Value.Errors.Count > 0).Select(x => (x.Key, x.Value.Errors.Select(x => x.ErrorMessage))).ToArray();

    //            List<ErrorSetting> Errors = new List<ErrorSetting>();

    //            foreach ((string Key, IEnumerable<string>) item in prueba)
    //            {
    //                foreach (string item2 in item.Item2)
    //                {

    //                    var errorSetting = new ErrorSetting
    //                    {

    //                        PropertyName = item.Key,
    //                        ErrorMessage = item2
    //                    };
    //                    Errors.Add(errorSetting);
    //                };





    //            }
    //            if (Errors.Count != 0)
    //            {
    //                throw new ValidationException(Errors);
    //            }
    //            base.OnResultExecuting(context);
    //        }
    //    }
    //}
}
