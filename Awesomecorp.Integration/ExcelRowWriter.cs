using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Awesomecorp.Integration
{

    public interface IExcelRowWriter<T>
    {
        void WriteRow(IXLWorksheet worksheet, T item, int row);
    }


    public class ExcelRowWriter<T> : IExcelRowWriter<T>
    {

        public ExcelRowWriter(PropertyLister<T> propertyLister)
        {
            PropertyLister = propertyLister;
        }

        public PropertyLister<T> PropertyLister { get; }

        public void WriteRow(IXLWorksheet worksheet, T item, int row)
        {
            var colIndex = 1;
            foreach(var property in PropertyLister.Properties)
            {
                WriteCell(worksheet.Row(row).Cell(colIndex), item, property);
                colIndex++;
            }
            
        }

        private void WriteCell(IXLCell cell, T item, PropertyInfo property)
        {
            cell.SetValue(property.GetValue(item, null)?.ToString() ?? "");
        }
    }
}
