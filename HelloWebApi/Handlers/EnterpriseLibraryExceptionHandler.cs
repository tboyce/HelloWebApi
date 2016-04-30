using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using IExceptionHandler = System.Web.Http.ExceptionHandling.IExceptionHandler;

namespace HelloWebApi.Handlers
{
    public class EnterpriseLibraryExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            if (ShouldHandle(context))
            {
                // handle exception with the ServiceAbend exception policy
                ExceptionPolicy.HandleException(context.Exception, "ServiceAbend");
            }
            return Task.FromResult(0);
        }

        private bool ShouldHandle(ExceptionHandlerContext context)
        {
            // only log top level exceptions
            return context.CatchBlock.IsTopLevel;
        }
    }
}