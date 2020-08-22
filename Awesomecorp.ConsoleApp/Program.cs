using Awesomecorp.Integration;
using Awesomecorp.Integration.Datasource;
using Awesomecorp.Integration.Datasource.Models;
using Awesomecorp.Integration.ExcelWriter;
using ClosedXML.Excel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Awesomecorp.ConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder
                    .SetMinimumLevel(LogLevel.Debug)
                         .AddConsole();
                })
                
                .AddSingleton<IPropertyLister<Subscriber>, PropertyLister<Subscriber>>()
                .AddSingleton<IExcelRowWriter<Subscriber>, ExcelRowWriter<Subscriber>>()
                .AddSingleton<IExcelHeaderWriter<Subscriber>, ExcelHeaderWriter<Subscriber>>()
                .AddSingleton<IExcelListWriter<Subscriber>, ExcelListWriter<Subscriber>>()
                .AddSingleton<IAwesomeCorpDatasource, AwesomeCorpDatasource>()
                .AddSingleton<WriteDatasourceToExcel>()
                
                .BuildServiceProvider();

            ILogger logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            
            var datasourceToExcelWriter = serviceProvider.GetService<WriteDatasourceToExcel>();

            // Here the datasource gets written to the excel
            await datasourceToExcelWriter.WriteFileTo(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory), "test.xlsx");

            logger.LogDebug("All done!");
            Console.ReadLine();
        }


    }
}
