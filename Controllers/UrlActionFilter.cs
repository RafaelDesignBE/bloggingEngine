using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Reflection;
public class UrlActionFilter : ActionFilterAttribute
{
  // public override void OnActionExecuting(ActionExecutingContext context)
  // {
  //   System.Console.WriteLine(context.HttpContext.Request.Path + context.HttpContext.Request.QueryString);
  // }
  // public override void OnActionExecuted(ActionExecutedContext context)
  // {
  //   // System.Console.WriteLine($"TEST 456 {context.Controller.GetType().Name} - {context.ActionDescriptor.DisplayName}");
  // }

  public override void OnActionExecuting(ActionExecutingContext context)
    {
      ILogger<UrlActionFilter> log = (ILogger<UrlActionFilter>)context.HttpContext.RequestServices.GetService(typeof(ILogger<UrlActionFilter>));
      log.LogInformation("Executing: " + context.HttpContext.Request.Path + context.HttpContext.Request.QueryString);
      System.Console.WriteLine("Executing: " + context.HttpContext.Request.Path + context.HttpContext.Request.QueryString);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
      ILogger<UrlActionFilter> log = (ILogger<UrlActionFilter>)context.HttpContext.RequestServices.GetService(typeof(ILogger<UrlActionFilter>));
      log.LogInformation("Executed: " + context.HttpContext.Request.Path + context.HttpContext.Request.QueryString);
      System.Console.WriteLine("Executed: " + context.HttpContext.Request.Path + context.HttpContext.Request.QueryString);
    }
}