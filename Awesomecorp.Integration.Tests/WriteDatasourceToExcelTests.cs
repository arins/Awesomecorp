using Awesomecorp.Integration.Datasource;
using Awesomecorp.Integration.Datasource.Models;
using Awesomecorp.Integration.ExcelWriter;
using ClosedXML.Excel;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Awesomecorp.Integration.Tests
{
    public class WriteDatasourceToExcelTests
    {

        [Test]
        public async Task ShouldWriteFile()
        {

            

            var awesomeCorpDatasource = Mock.Of<IAwesomeCorpDatasource>();
            var excelListWriter = Mock.Of<IExcelListWriter<Subscriber>>();
            var propertyLister = Mock.Of<IPropertyLister<Subscriber>>();
            var logger = Mock.Of<ILogger<WriteDatasourceToExcel>>();
            var fakeExcel = Mock.Of<IXLWorkbook>();
            var t = new WriteDatasourceToExcel(awesomeCorpDatasource, excelListWriter, propertyLister, logger);
            Mock.Get(awesomeCorpDatasource).Setup(x =>
              x.GetSubscribers()).ReturnsAsync(new GetSubscriberResponse { List = new List<Subscriber> { } });
            Mock.Get(fakeExcel).Setup(excel => excel.SaveAs(It.Is<string>(s => s == "c:\\test\\filename")));
            Mock.Get(excelListWriter).Setup(x =>
                x.Write(It.IsAny<IEnumerable<Subscriber>>())).Returns(fakeExcel);
            await t.WriteFileTo(new DirectoryInfo("c:\\test"), "filename");
          

            Assert.Pass();
        }
    }
}
