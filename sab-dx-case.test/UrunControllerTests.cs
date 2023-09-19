using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using sab_dx_case.Data.ApiModels;
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
            accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXAyIiwianRpIjoiNWFjMjdkYTQtMzNlYi00OGE5LWJlMjYtM2IyNjIwOWE3MGY2IiwiZXhwIjoxNjk1MTQ3MDk3LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.bYVGY9lL7_pvnE9UAJKZ2iaph8smTIrP9shXO1LqBUI";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        [Test]
        public async Task GetAllUrunler_CheckNotAllowedMethods()
        {
            var response = await client.PostAsync("https://localhost:7074/api/Urun/GetAllUrunler", new StringContent(""));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
        }

        [Test]
        public async Task GetUrunById_CheckInvalidInputs()
        {
            
            var response = await client.GetAsync("https://localhost:7074/api/Urun/GetUrunById/a");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task CreateUrun_CheckInvalidInputs()
        {
            Urun urun = new Urun();
            urun.Adi = "invalid-test";
            urun.Kodu = "A1";
            urun.StokDurumu = 1;
            urun.Aciklama = "shouldnt exist in database";
            urun.Marka = "Invalid";
            urun.Fiyat = -1;
            urun.ParaBirimi = "TL";

            var urunJson = JsonConvert.SerializeObject(urun);
            var buffer = System.Text.Encoding.UTF8.GetBytes(urunJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://localhost:7074/api/Urun/CreateUrun", byteContent);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}