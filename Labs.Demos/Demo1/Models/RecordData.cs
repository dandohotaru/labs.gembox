namespace Labs.Core.Demo1.Models
{
    public class RecordData
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ChildData[] Children { get; set; }
    }
}