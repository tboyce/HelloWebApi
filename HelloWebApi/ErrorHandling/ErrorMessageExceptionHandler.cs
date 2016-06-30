using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace HelloWebApi.ErrorHandling
{
    /// <summary>
    ///     Returns an ErrorMessage result when an error occurs.
    /// </summary>
    public class ErrorMessageExceptionHandler : ExceptionHandler
    {
        public ErrorMessageExceptionHandler()
        {
            Logger.SetLogWriter(new LogWriterFactory().Create());
            ExceptionPolicy.SetExceptionManager(new ExceptionPolicyFactory().CreateManager());
        }
       

        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var exception = context.Exception;
            if (!exception.Data.Contains("RequestId"))
            {
                exception.Data.Add("RequestId", context.Request.GetCorrelationId());
            }

            ExceptionPolicy.HandleException(context.Exception, "Logging Policy");

            context.Result = new ErrorMessage(context.Request);

            return base.HandleAsync(context, cancellationToken);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}