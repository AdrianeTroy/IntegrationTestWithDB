using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using S3E1.Data;

namespace IntegrationTest
{
    public class IntegrationTestBaseClass
    {
        protected readonly HttpClient _httpClient;

        public IntegrationTestBaseClass()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _httpClient = appFactory.CreateClient();
        }
    }
}
