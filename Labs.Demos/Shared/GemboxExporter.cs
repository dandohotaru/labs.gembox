using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GemBox.Document;
using GemBox.Document.MailMerging;

namespace Labs.Core.Shared
{
    public class GemboxExporter : IReportExporter
    {
        public GemboxExporter(string context, IEnumerable<string> extensions)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));

            var assembly = Assembly.GetExecutingAssembly();
            var folder = new DirectoryInfo(Path.GetDirectoryName(assembly.Location));
            if (!folder.Exists)
                throw new DirectoryNotFoundException(folder.FullName);

            Template = new FileInfo(Path.Combine(folder.FullName, context, $"{context}Template.docx"));
            if (!Template.Exists)
                throw new FileLoadException(Template.FullName);

            Outputs = from extension in extensions
                      let name = $"{context}Output.{extension}"
                      let output = new FileInfo(Path.Combine(folder.FullName, context, name))
                      select output;
        }

        protected string Context { get; }

        protected FileInfo Template { get; }

        protected IEnumerable<FileInfo> Outputs { get; }

        public void Export<T>(T data) where T : IReportData
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            ComponentInfo.FreeLimitReached += (sender, e) =>
            {
                e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;
            };

            var options = MailMergeClearOptions.RemoveEmptyRanges
                | MailMergeClearOptions.RemoveEmptyTableRows;

            var document = DocumentModel.Load(Template.FullName);
            document.MailMerge.RangeStartPrefix = "#";
            document.MailMerge.RangeEndPrefix = "/";
            document.MailMerge.ClearOptions = options;
            document.MailMerge.Execute(data);

            Console.WriteLine($"# {Context}");
            Console.WriteLine("Template");
            Console.WriteLine(Template.FullName);
            Console.WriteLine();

            Console.WriteLine("Outputs");
            foreach (var output in Outputs)
            {
                document.Save(output.FullName);
                Console.WriteLine(output.FullName);
                Console.WriteLine();
            }
        }
    }
}