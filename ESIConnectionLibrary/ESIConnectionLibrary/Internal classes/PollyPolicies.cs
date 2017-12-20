using System;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using Polly;
using Polly.Fallback;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class PollyPolicies
    {
        private static readonly Policy WebExceptionRetryPolicyAsync = Policy.Handle<WebException>().WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        });

        private static readonly Policy WebExceptionFallBackPolicyAsync = Policy.Handle<WebException>().FallbackAsync(b => throw new ESIException("WebClient cannot connect to the ESI"));

        public static readonly IAsyncPolicy WebExceptionRetryWithFallbackAsync = WebExceptionFallBackPolicyAsync.WrapAsync(WebExceptionRetryPolicyAsync);



        private static readonly Policy WebExceptionRetryPolicy = Policy.Handle<WebException>().WaitAndRetry(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        });

        private static readonly Policy WebExceptionFallBackPolicy = Policy.Handle<WebException>().Fallback(b => throw new ESIException("WebClient cannot connect to the ESI"));

        public static readonly Policy WebExceptionRetryWithFallback = WebExceptionFallBackPolicy.Wrap(WebExceptionRetryPolicy);
    }
}
