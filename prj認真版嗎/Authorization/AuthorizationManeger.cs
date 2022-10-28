using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using prj認真版嗎.Models;

namespace prj認真版嗎.Authorization
{
    public class AuthorizationManeger : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString(CDictionary.SK_Admin_Login) ==null)
                context.Result=new RedirectToRouteResult(new {controller="Home",action="login"});
        }
    }
}
