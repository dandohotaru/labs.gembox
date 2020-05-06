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

        public IEnumerable<ChildData> Rows { get; protected set; }

        public static implicit operator ChildTable(ChildData[] rows)
        {
            return new ChildTable {Rows = rows};
        }
    }

    public class ChildHeader
    {
        public string X { get; set; }
    }

    public class ChildData
    {
        public int? Id { get; set; }

        public string Type { get; set; }
    }
}