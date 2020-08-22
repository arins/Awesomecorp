using Awesomecorp.Integration.Datasource.Models;
using Awesomecorp.Integration.ExcelWriter;
using ClosedXML.Excel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Awesomecorp.Integration.Tests.ExcelWriter
{
    public class ExcelRowWriterTests
    {

        [Test]
        public void ShouldWriteOneRowToWorkBook()
        {
            var list = new PropertyLister<Subscriber>();
            list.Load();
            var writer = new ExcelRowWriter<Subscriber>(list);
            using (var workBook = new XLWorkbook())
            {
                var worksheet = workBook.AddWorksheet("test");
                writer.WriteRow(worksheet, new Subscriber { 
                    Id = "1",
                    Email = "Hej"
                }, 1);
                var writtenValue = (string)workBook.Worksheet("test").Cell("A1").Value;
                Assert.IsTrue(writtenValue == "1");
            }
            

        }
    }
}
