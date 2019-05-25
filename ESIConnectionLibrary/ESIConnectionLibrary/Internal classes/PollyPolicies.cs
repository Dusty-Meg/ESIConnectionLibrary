using System;
using ESIConnectionLibrary.Exceptions;
using Polly;
using Polly.Retry;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class PollyPolicies
    {
        public static readonly AsyncRetryPolicy WebExceptionRetryWithFallbackAsync = Policy.Handle<EsiException>().WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        });

        public static readonly Policy WebExceptionRetryWithFallback = Policy.Handle<EsiException>().WaitAndRetry(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        });
    }
}
