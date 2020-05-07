using Labs.Core.Demo1;
using Labs.Core.Demo2;
using Labs.Core.Demo3;
using Labs.Core.Demo4;
using Labs.Core.Shared;

namespace Labs.Core
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Run(new Demo1Provider(), "Demo1");
            Run(new Demo2Provider(), "Demo2");
            Run(new Demo3Provider(), "Demo3");
            Run(new Demo4Provider(), "Demo4");
        }

        public static void Run<T>(IReportProvider<T> provider, string feature)
            where T : IReportData
        {
            var data = provider.Build(title: feature);
            var extensions = new[] {"pdf", "docx"};
            var exporter = new GemboxExporter(context: feature, extensions);
            exporter.Export(data);
        }
    }
}