# about
- merge with dedicated object like {table: {header, rows[]}}
- rely on the <<x>> header property mapping as otherwise first row replaces header
- if no header mapping is defined the header is not rendered at all
- seems like a viable solution but the templates ends up being complex and error prone

## data
```
	return new ReportData
	{
		Title = title,
		Records = new[]
		{
			new RecordData
			{
				Id = ...,
				Title = ...,
				Children = new[]
				{
					new ChildData {Id = random.Next(100, 199), Type = "one"},
					new ChildData {Id = random.Next(100, 199), Type = "two"},
					new ChildData {Id = random.Next(100, 199), Type = "three"},
					new ChildData {Id = random.Next(100, 199), Type = "four"}
				}
			},
		}
	}
```
```
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
```

## template
```
	«#Records»
		«#Header»Id«X»  | Title     | Description«/Header»
		«#Rows»«Id»     | «Title»   | «Description»
			«#Children»
				«#Header»Id«X»  | Type«/Header»
				«#Rows»«Id»     | «Type»«/Rows»
			«/Children»
		«/Rows»
	«/Records»
```