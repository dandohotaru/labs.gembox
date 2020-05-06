using System;
using System.IO;
using System.Reflection;
using Labs.Core.Demo2;
using Labs.Core.Shared;

namespace Labs.Core
{
    public class Program
    {
        private static void Main(string[] args)
        {
            RunDemo2();

            Console.WriteLine("Press any key to continue");
        }

        private static void RunDemo2()
        {
            const string context = "Demo2";

            var provider = new Demo2Provider();
            var data = provider.Build(context);

            var assembly = Assembly.GetExecutingAssembly();
            var folder = Path.GetDirectoryName(assembly.Location);
            var exporter = new DataExporter<IDataSource>(folder, context, new[] {"pdf", "docx"});
            exporter.Export(data);
        }
    }
}