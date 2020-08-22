using Awesomecorp.Integration.Datasource;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesomecorp.Integration.Tests.Datasource
{
    public class AwesomecorpDatasourceTests
    {
        [Test]
        public async Task TestWithFakeStream()
        {
            var fakeData = "{ \"list\": [" +

                "{ \"id\": \"1\"," +
                "\"firstname\": \"Philip\"," +
      "\"lastname\": \"Norton\"," +
      "\"email\": \"Philip.Norton0@relationbrand.com\"," +
      "\"mobile\": \"+46705251120\"" +
    "}," +
    "{" +
      "\"id\": \"2\"," +
      "\"firstname\": \"Philip\"," +
      "\"lastname\": \"Norton\"," +
      "\"email\": \"Philip.Norton1@relationbrand.com\"," +
      "\"mobile\": \"+46705251121\"" +
    "}]}";

            byte[] byteArray = Encoding.ASCII.GetBytes(fakeData);
            MemoryStream stream = new MemoryStream(byteArray);
            var source = new AwesomeCorpDatasource();
            var list = await source.GetDeserilizedAsync(stream);
            Assert.IsTrue(list.List.ElementAt(0).Email == "Philip.Norton0@relationbrand.com");
            

        }
    }
}
