using System;

namespace Labs.Core.Models
{
    public class DataSource
    {
        public string Title { get; set; }

        public DateTime Stamp { get; set; }

        public RecordTable Records { get; set; }
    }
}