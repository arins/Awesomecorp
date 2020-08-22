using Awesomecorp.Integration.Datasource;
using Awesomecorp.Integration.Datasource.Models;
using Awesomecorp.Integration.ExcelWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesomecorp.Integration
{
    public class WriteDatasourceToExcel
    {

        public WriteDatasourceToExcel(
            IAwesomeCorpDatasource awesomeCorpDatasource,
            IExcelListWriter<Subscriber> excelListWriter,
            IPropertyLister<Subscriber> propertyLister,
            ILogger<WriteDatasourceToExcel> logger)
        {
            AwesomeCorpDatasource = awesomeCorpDatasource;
            ExcelListWriter = excelListWriter;
            Logger = logger;
            PropertyLister = propertyLister;
        }

        public IAwesomeCorpDatasource AwesomeCorpDatasource { get; }
        public IExcelListWriter<Subscriber> ExcelListWriter { get; }
        public ILogger Logger { get; }
        public IPropertyLister<Subscriber> PropertyLister { get; }

        public async Task WriteFileTo(DirectoryInfo directoryInfo, string filename)
        {
            PropertyLister.Load();
            
            var datasource = await AwesomeCorpDatasource.GetSubscribers();
            using (var excel = ExcelListWriter.Write(datasource.List))
            {
                var path = Path.Combine(directoryInfo.FullName, filename);
                Logger.LogDebug("Saving excel document in " + path);
                excel.SaveAs(path);
            }
        }
    }
}
