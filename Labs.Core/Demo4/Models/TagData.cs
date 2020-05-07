namespace Labs.Core.Demo4.Models
{
    public class TagData
    {
        public string Value { get; set; }

        public static implicit operator TagData(string value)
        {
            return new TagData { Value = value };
        }
    }
}