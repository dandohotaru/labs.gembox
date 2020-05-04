using System;
using System.IO;
using System.Reflection;
using Labs.Core.Exporters;
using Labs.Core.Providers;

namespace Labs.Core
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var provider = new MemoryProvider();
            var data = provider.Build();

            var location = Assembly.GetExecutingAssembly().Location;
            var folder = Path.GetDirectoryName(location);
            var exporter = new GemboxExporter(folder);
            exporter.Export(data);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}