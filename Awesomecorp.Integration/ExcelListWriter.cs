using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Awesomecorp.Integration
{
    public class ExcelListWriter<T>
    {
        public ExcelListWriter(
            IHeaderWriter<T> headerWriter, 
            IExcelRowWriter<T> excelRowWriter)
        {
            HeaderWriter = headerWriter;
            ExcelRowWriter = excelRowWriter;

        }

        private IHeaderWriter<T> HeaderWriter { get; }
        private IExcelRowWriter<T> ExcelRowWriter { get; }
        


        public XLWorkbook Write(IEnumerable<T> datasoure)
        {
            using(var workbook = new XLWorkbook())
            {
                
                var workSheet = workbook.AddWorksheet();
                HeaderWriter.WriteHeader(workbook);
                WriteAllRows(workSheet, datasoure);
                
                return workbook;
            }
            
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
