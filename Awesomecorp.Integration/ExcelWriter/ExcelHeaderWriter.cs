using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesomecorp.Integration.ExcelWriter
{

    public interface IExcelHeaderWriter<T>
    {
        void WriteHeader(IXLWorksheet worksheet);
        IPropertyLister<T> PropertyLister { get; }
    }

    /// <summary>
    /// Write headers for type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExcelHeaderWriter<T> : IExcelHeaderWriter<T>
    {


        public ExcelHeaderWriter(IPropertyLister<T> propertyLister)
        {
            PropertyLister = propertyLister;
        }

        public IPropertyLister<T> PropertyLister { get; }

        public void WriteHeader(IXLWorksheet workSheet)
        {

            IEnumerable<string> toWrite = PropertyLister.Properties.Select(p => p.Name);
            WriteHeader(toWrite, workSheet);
        }
        public void WriteHeader(IEnumerable<string> headers, IXLWorksheet worksheet)
        {
            var row = worksheet.Row(1);
            var counter = 1;
            foreach (var header in headers)
            {
                var cell = row.Cell(counter);
                cell.SetValue(char.ToLowerInvariant(header[0]) + header.Substring(1));

                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.Black;
                
                counter++;
            }
        }
    }
}
