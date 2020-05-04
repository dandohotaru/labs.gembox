using System;
using System.IO;
using GemBox.Document;
using GemBox.Document.MailMerging;
using Labs.Core.Models;

namespace Labs.Core.Exporters
{
    public class GemboxExporter : IExporter
    {
        public GemboxExporter(string folder)
        {
            if (folder == null)
                throw new ArgumentNullException(nameof(folder));
            Folder = new DirectoryInfo(folder);
            if (Folder == null || !Folder.Exists)
                throw new DirectoryNotFoundException(folder);
        }

        protected DirectoryInfo Folder { get; }

        public void Export(DataSource data)
        {
            // Setup
            var input = Path.Combine(Folder.FullName, "Exporters","MergeNestedTemplate.docx");
            var output = Path.Combine(Folder.FullName, "Exporters", "MergeNestedOutput.pdf");
            var random = new Random();

            // Init
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            ComponentInfo.FreeLimitReached += (sender, e) =>
            {
                e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;
            };

            var document = DocumentModel.Load(input);
            document.MailMerge.RangeStartPrefix = "#";
            document.MailMerge.RangeEndPrefix = "/";
            document.MailMerge.ClearOptions = MailMergeClearOptions.RemoveEmptyRanges | MailMergeClearOptions.RemoveEmptyTableRows;
            document.MailMerge.Execute(data);
            document.Save(output);
        }
    }
}