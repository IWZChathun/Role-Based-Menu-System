using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace RBMS.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Authorizer : ActionFilterAttribute
    {
        private readonly string _module;

        public Authorizer(string module)
        {
            _module = module;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            bool isAuthorized = true;

            if (identity != null)
            {
                var accesses = identity.Claims.Where(c => c.Type == "access").Select(c => c.Value).SingleOrDefault();
                var accessarr = accesses.Split(";");

                if(!accessarr.Any((a) => a == _module))
                    isAuthorized = false;
            }
            else
            {
                isAuthorized = false;
            }

            if (!isAuthorized)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.HttpContext.Response.Headers.Clear();
                context.Result = new EmptyResult();
            }
        }
    }
}
