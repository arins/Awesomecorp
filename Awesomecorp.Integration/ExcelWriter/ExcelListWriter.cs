using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Awesomecorp.Integration.ExcelWriter
{
    public interface IExcelListWriter<T>
    {
        public IXLWorkbook Write(IEnumerable<T> datasoure);
    }

    public class ExcelListWriter<T> : IExcelListWriter<T>
    {
        public ExcelListWriter(
            IExcelHeaderWriter<T> headerWriter,
            IExcelRowWriter<T> excelRowWriter)
        {
            HeaderWriter = headerWriter;
            ExcelRowWriter = excelRowWriter;

        }

        private IExcelHeaderWriter<T> HeaderWriter { get; }
        private IExcelRowWriter<T> ExcelRowWriter { get; }



        public IXLWorkbook Write(IEnumerable<T> datasoure)
        {
            var workbook = new XLWorkbook();


            var workSheet = workbook.AddWorksheet("test");

            HeaderWriter.WriteHeader(workSheet);
            WriteAllRows(workSheet, datasoure);
            return workbook;


        }

        private void WriteAllRows(IXLWorksheet worksheet, IEnumerable<T> datasoure)
        {
            var row = 2;
            foreach (var item in datasoure)
            {
                ExcelRowWriter.WriteRow(worksheet, item, row);
                row++;
            }

        }
    }
}
