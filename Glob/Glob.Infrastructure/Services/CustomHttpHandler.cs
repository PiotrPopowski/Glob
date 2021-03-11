using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public class CustomHttpHandler : DelegatingHandler
    {
        private readonly AuthenticationHeaderValue _authorization;
        public CustomHttpHandler(AuthenticationHeaderValue auth, HttpMessageHandler innerHandler): base(innerHandler)
        {
            _authorization = auth;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Clear();
            request.Headers.Authorization = _authorization;
            return base.SendAsync(request, cancellationToken);
        }
    }
}
