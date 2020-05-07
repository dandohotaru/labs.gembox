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
            //RunDemo1();
            //RunDemo2();
            //RunDemo3();
            RunDemo4();
        }

        private static void RunDemo1()
        {
            const string feature = "Demo1";

            var provider = new Demo1Provider();
            var data = provider.Build(feature);

            var exporter = new GemboxExporter(feature, new[] {"pdf", "docx"});
            exporter.Export(data);
        }

        private static void RunDemo2()
        {
            const string feature = "Demo2";

            var provider = new Demo2Provider();
            var data = provider.Build(feature);

            var exporter = new GemboxExporter(feature, new[] {"pdf", "docx"});
            exporter.Export(data);
        }

        private static void RunDemo3()
        {
            const string feature = "Demo3";

            var provider = new Demo3Provider();
            var data = provider.Build(feature);

            var exporter = new GemboxExporter(feature, new[] {"pdf", "docx"});
            exporter.Export(data);
        }

        private static void RunDemo4()
        {
            const string feature = "Demo4";

            var provider = new Demo4Provider();
            var data = provider.Build(feature);

            var exporter = new GemboxExporter(feature, new[] {"pdf", "docx"});
            exporter.Export(data);
        }
    }
}