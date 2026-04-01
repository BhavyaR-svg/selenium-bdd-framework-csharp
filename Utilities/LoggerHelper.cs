using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Utilities
{
    public static class LoggerHelper
    {
        public static void InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File($"C:\\ExtentReport\\logs_{DateTime.Now:yyyyMMdd_HHmmss}.txt")
                .CreateLogger();
        }
    }
}
