using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesomecorp.Integration
{

    public interface IHeaderWriter<T>
    {
        void WriteHeader(XLWorkbook workbook);
        PropertyLister<T> PropertyLister { get; }
    }
    public class HeaderWriter<T> : IHeaderWriter<T>
    {


        public HeaderWriter(PropertyLister<T> propertyLister)
        {
            PropertyLister = propertyLister;
        }

        public PropertyLister<T> PropertyLister { get; }

        public void WriteHeader(XLWorkbook workbook)
        {

            IEnumerable<string> toWrite = PropertyLister.Properties.Select(p => p.Name);
            WriteHeader(toWrite, workbook);
        }
        public void WriteHeader(IEnumerable<string> enumerable, XLWorkbook workbook)
        {

        }
    }
}
