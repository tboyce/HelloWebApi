using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace HelloWebApi.ErrorHandling
{
    /// <summary>
    ///     Returns an ErrorMessage result when an error occurs.
    /// </summary>
    public class ErrorMessageExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
        }

        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            context.Result = new ErrorMessage(context.Request);

            return base.HandleAsync(context, cancellationToken);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}