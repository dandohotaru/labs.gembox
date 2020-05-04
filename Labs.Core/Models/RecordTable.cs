using System.Collections.Generic;

namespace Labs.Core.Models
{
    public class RecordTable
    {
        public RecordTable()
        {
            Header = new RecordHeader
            {
                Id = nameof(RecordHeader.Id),
                Title = nameof(RecordHeader.Title),
                Description = nameof(RecordHeader.Description),
            };
        }

        public RecordHeader Header { get; protected set; }

        public IEnumerable<RecordRow> Rows { get; protected set; }

        public static implicit operator RecordTable(RecordRow[] rows)
        {
            return new RecordTable { Rows = rows };
        }
    }

    public class RecordHeader
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class RecordRow
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ChildTable Children { get; set; }
    }
}