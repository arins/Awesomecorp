using NUnit.Framework;
using Awesomecorp.Integration;
using System.Collections.Generic;
using Moq;
using System;
using ClosedXML.Excel;

namespace Awesomecorp.Integration.Tests
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
            var headerWriter = Mock.Of<IHeaderWriter<Subscriber>>();
            var t = new ExcelListWriter<Subscriber>(headerWriter, excelRowWriter);

            var excel = t.Write(datasoure);
            Mock.Get(headerWriter).Verify(x =>
                x.WriteHeader(It.IsAny<XLWorkbook>()), Times.Once);
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
            var headerWriter = Mock.Of<IHeaderWriter<Subscriber>>();
            var t = new ExcelListWriter<Subscriber>(headerWriter, excelRowWriter);

            var excel = t.Write(datasoure);
            Mock.Get(excelRowWriter).Verify(x =>
                x.WriteRow(It.IsAny<IXLWorksheet>(), It.IsAny<Subscriber>(), It.IsAny<int>()), Times.Exactly(2));

            Assert.Pass();
        }
    }
}