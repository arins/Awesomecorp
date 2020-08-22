using Awesomecorp.Integration.Datasource.Models;
using Awesomecorp.Integration.ExcelWriter;
using ClosedXML.Excel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Awesomecorp.Integration.Tests.ExcelWriter
{
    public class ExcelHeaderWriterTests
    {

        [Test]
        public void ShouldWritePropertiesToFirstRow()
        {
            var list = new PropertyLister<Subscriber>();
            list.Load();
            var writer = new ExcelHeaderWriter<Subscriber>(list);
            using (var workBook = new XLWorkbook())
            {
                var worksheet = workBook.AddWorksheet("test");
                writer.WriteHeader(worksheet);
                var writtenValue = (string)workBook.Worksheet("test").Cell("A1").Value;
                Assert.AreEqual(writtenValue, "id");
            }
            

        }
    }
}
