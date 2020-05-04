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
            // Build
            var provider = new MemoryProvider();
            var data = provider.Build();

            // Export
            var assembly = Assembly.GetExecutingAssembly();
            var folder = Path.GetDirectoryName(assembly.Location);
            var exporter = new GemboxExporter(folder);
            exporter.Export(data);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}