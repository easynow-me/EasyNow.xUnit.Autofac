using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace EasyNow.xUnit.Autofac.TestFramework {
    internal static class ExceptionExtensions
    {
        private const string RETHROW_MARKER = "$$RethrowMarker$$";

        /// <summary>
        ///     Rethrows an exception object without losing the existing stack trace information
        /// </summary>
        /// <param name="ex">The exception to re-throw.</param>
        /// <remarks>
        ///     For more information on this technique, see
        ///     http://www.dotnetjunkies.com/WebLog/chris.taylor/archive/2004/03/03/8353.aspx.
        ///     The remote_stack_trace string is here to support Mono.
        /// </remarks>
        public static void RethrowWithNoStackTraceLoss(this Exception ex)
        {
            ExceptionDispatchInfo.Capture(ex).Throw();
        }

        /// <summary>
        ///     Unwraps an exception to remove any wrappers, like <see cref="TargetInvocationException" />.
        /// </summary>
        /// <param name="ex">The exception to unwrap.</param>
        /// <returns>The unwrapped exception.</returns>
        public static Exception Unwrap(this Exception ex)
        {
            while (true)
            {
                var tiex = ex as TargetInvocationException;
                if (tiex == null) return ex;

                ex = tiex.InnerException;
            }
        }
    }
}
