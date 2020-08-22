using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Awesomecorp.Integration.ExcelWriter
{

    public interface IExcelRowWriter<T>
    {
        void WriteRow(IXLWorksheet worksheet, T item, int row);
    }


    /// <summary>
    /// Write rows for type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExcelRowWriter<T> : IExcelRowWriter<T>
    {

        public ExcelRowWriter(IPropertyLister<T> propertyLister)
        {
            PropertyLister = propertyLister;
        }

        public IPropertyLister<T> PropertyLister { get; }

        public void WriteRow(IXLWorksheet worksheet, T item, int row)
        {
            var colIndex = 1;
            foreach(var property in PropertyLister.Properties)
            {
                WriteCell(worksheet.Row(row).Cell(colIndex), item, property);
                worksheet.Column(colIndex).AdjustToContents();
                colIndex++;
            }
            
        }

        private void WriteCell(IXLCell cell, T item, PropertyInfo property)
        {
            cell.SetValue(property.GetValue(item, null)?.ToString() ?? "");
        }
    }
}
