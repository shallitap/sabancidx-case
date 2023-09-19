using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;

namespace sab_dx_case.test
{
    public class Tests
    {
        private HttpClient client;
        private WebApplicationFactory<Program> factory;
        private string accessToken;

        [SetUp]
        public void Setup()
        {
            factory = new WebApplicationFactory<Program>();
            client = factory.CreateClient();
            accessToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXAyIiwianRpIjoiNWFjMjdkYTQtMzNlYi00OGE5LWJlMjYtM2IyNjIwOWE3MGY2IiwiZXhwIjoxNjk1MTQ3MDk3LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.bYVGY9lL7_pvnE9UAJKZ2iaph8smTIrP9shXO1LqBUI";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", accessToken);
        }

        [Test]
        public async Task GetAllUrunler_CheckNotAllowedMethods()
        {
            var response = await client.PostAsync("https://localhost:7074/api/Urun/GetAllUrunler", new StringContent(""));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
        }

        [Test]
        public async Task GetUrunById_CheckUnvalidInputs()
        {
            var response = await client.PostAsync("https://localhost:7074/api/Urun/GetUrunById/a", new StringContent(""));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}