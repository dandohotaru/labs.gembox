using System.Collections.Generic;

namespace Labs.Core.Demo2.Models
{
    public class RecordTable
    {
        public RecordTable()
        {
            Header = new RecordHeader
            {
                X = "."
            };
        }

        public RecordHeader Header { get; protected set; }

        public IEnumerable<RecordData> Rows { get; protected set; }

        public static implicit operator RecordTable(RecordData[] rows)
        {
            return new RecordTable { Rows = rows };
        }
    }

    public class RecordHeader
    {
        public string X { get; set; }
    }

    public class RecordData
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ChildTable Children { get; set; }
    }
}