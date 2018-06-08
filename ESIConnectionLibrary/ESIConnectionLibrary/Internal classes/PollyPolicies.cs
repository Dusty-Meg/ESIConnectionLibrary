using System;
using ESIConnectionLibrary.Exceptions;
using Polly;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class PollyPolicies
    {
        public static readonly Policy WebExceptionRetryWithFallbackAsync = Policy.Handle<ESIException>().WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        });

        public static readonly Policy WebExceptionRetryWithFallback = Policy.Handle<ESIException>().WaitAndRetry(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        });
    }
}
