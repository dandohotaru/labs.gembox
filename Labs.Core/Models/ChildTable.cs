using System.Collections.Generic;

namespace Labs.Core.Models
{
    public class ChildTable
    {
        public ChildTable()
        {
            Header = new ChildHeader
            {
                Id = nameof(ChildHeader.Id),
                Type = nameof(ChildHeader.Type)
            };
        }

        public ChildHeader Header { get; protected set; }

        public IEnumerable<ChildRow> Rows { get; protected set; }

        public static implicit operator ChildTable(ChildRow[] rows)
        {
            return new ChildTable {Rows = rows};
        }
    }

    public class ChildHeader
    {
        public string Id { get; set; }

        public string Type { get; set; }
    }

    public class ChildRow
    {
        public int? Id { get; set; }

        public string Type { get; set; }
    }
}