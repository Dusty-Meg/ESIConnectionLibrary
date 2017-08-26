using System;
using System.Net;
using ESIConnectionLibrary.Exceptions;
using Polly;

namespace ESIConnectionLibrary.Internal_classes
{
    internal static class PollyPolicies
    {
        private static readonly Policy WebExceptionRetryPolicy = Policy.Handle<WebException>().WaitAndRetry(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        });

        private static readonly Policy WebExceptionFallBackPolicy = Policy.Handle<WebException>().Fallback(() => throw new ESIException("WebClient cannot connect to the ESI"));

        public static readonly Policy WebExceptionRetryWithFallback = WebExceptionFallBackPolicy.Wrap(WebExceptionRetryPolicy);
    }
}
