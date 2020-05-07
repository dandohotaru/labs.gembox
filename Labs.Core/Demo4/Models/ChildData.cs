namespace Labs.Core.Demo4.Models
{
    public class ChildData
    {
        public string Value { get; set; }

        public static implicit operator ChildData(string value)
        {
            return new ChildData { Value = value };
        }
    }
}