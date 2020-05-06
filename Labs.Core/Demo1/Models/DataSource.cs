using System;
using Labs.Core.Shared;

namespace Labs.Core.Demo1.Models
{
    public class DataSource : IDataSource
    {
        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime Stamp { get; set; }

        public RecordData[] Records { get; set; }
    }
}