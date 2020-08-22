using NUnit.Framework;
using Awesomecorp.Integration.ExcelWriter;
using Awesomecorp.Integration.Datasource.Models;
using System.Collections.Generic;
using Moq;
using System;
using ClosedXML.Excel;

namespace Awesomecorp.Integration.Tests.ExcelWriter
{
    public class ExcelDataWriterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldWriteHeader()
        {

            
            var datasoure = new List<Subscriber> {
            };
            var excelRowWriter = Mock.Of<IExcelRowWriter<Subscriber>>();
            var headerWriter = Mock.Of<IExcelHeaderWriter<Subscriber>>();
            var t = new ExcelListWriter<Subscriber>(headerWriter, excelRowWriter);

            var excel = t.Write(datasoure);
            Mock.Get(headerWriter).Verify(x =>
                x.WriteHeader(It.IsAny<IXLWorksheet>()), Times.Once);
            Assert.Pass();
        }

        [Test]
        public void ShouldWriteTwoRows()
        {


            var datasoure = new List<Subscriber> {
                new Subscriber
                {

                },
                new Subscriber
                {

                }
            };
            var excelRowWriter = Mock.Of<IExcelRowWriter<Subscriber>>();
            var headerWriter = Mock.Of<IExcelHeaderWriter<Subscriber>>();
            var t = new ExcelListWriter<Subscriber>(headerWriter, excelRowWriter);

            var excel = t.Write(datasoure);
            Mock.Get(excelRowWriter).Verify(x =>
                x.WriteRow(It.IsAny<IXLWorksheet>(), It.IsAny<Subscriber>(), It.IsAny<int>()), Times.Exactly(2));

            Assert.Pass();
        }
    }
}