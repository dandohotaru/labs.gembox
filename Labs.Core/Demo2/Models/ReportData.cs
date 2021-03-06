using System;
using Labs.Core.Shared;

namespace Labs.Core.Demo2.Models
{
    public class ReportData : IReportData
    {
        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime Stamp { get; set; }

        public RecordTable Records { get; set; }
    }
}