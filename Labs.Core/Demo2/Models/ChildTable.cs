using System.Collections.Generic;

namespace Labs.Core.Demo2.Models
{
    public class ChildTable
    {
        public ChildTable()
        {
            Header = new ChildHeader
            {
                X = "."
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
        public string X { get; set; }
    }

    public class ChildRow
    {
        public int? Id { get; set; }

        public string Type { get; set; }
    }
}