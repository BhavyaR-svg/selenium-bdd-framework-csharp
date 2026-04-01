using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpecFlowDemo.Utilities
{
    public class JsonHelper
    {
        public static T ReadJson<T>(string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", fileName);

            return JsonSerializer.Deserialize<T>(
                File.ReadAllText(path),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }
    }
}
