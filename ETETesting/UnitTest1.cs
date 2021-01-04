using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ETETesting
{
    [TestClass]
    public class UnitTest1
    {
        static HttpClient client = new HttpClient();

        [TestMethod]
        public async Task TestMethod1()
        {
            var isin = "XS0085732716";
            var dateFrom = new DateTime(2020,01,01);
            var dateTo = new DateTime(2020, 01, 03);


            await RunAsync(isin, dateFrom, dateTo);
            
        }

        static async Task RunAsync(string isin, DateTime dateFrom, DateTime dateTo)
        {
        
            client.BaseAddress = new Uri("https://localhost:44325/");

            var urlCheck = $"{client.BaseAddress}Returns/isin/?isin={isin}&valuationDate={dateTo}";

            var response = await client.GetAsync($"{client.BaseAddress}Returns/isin/?isin={isin}&dateFrom={dateFrom}&dateTo={dateTo}");

            var result = await response.Content.ReadAsAsync<ReturnsDTO>();

            //assert
        }


        public class ReturnsDTO
        {
            public double DecimalReturn { get; set; }
            public double PercentageReturn { get; set; }
            public double BPSReturn { get; set; }
        }


    }
}
