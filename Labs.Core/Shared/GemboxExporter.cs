using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GemBox.Document;
using GemBox.Document.MailMerging;

namespace Labs.Core.Shared
{
    public class GemboxExporter : IReportExporter
    {
        public GemboxExporter(string path, string context, IEnumerable<string> extensions)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            var folder = new DirectoryInfo(path);
            if (!folder.Exists)
                throw new DirectoryNotFoundException(path);

            Template = new FileInfo(Path.Combine(folder.FullName, context, $"{context}Template.docx"));
            if (!Template.Exists)
                throw new FileLoadException(Template.FullName);

            Outputs = from extension in extensions
                      let name = $"{context}Output.{extension}"
                      let output = new FileInfo(Path.Combine(folder.FullName, context, name))
                      select output;
        }

        public FileInfo Template { get; set; }

        public IEnumerable<FileInfo> Outputs { get; set; }

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