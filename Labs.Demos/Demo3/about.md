# about
- merge with simple object like {records[]}
- wrap children in a container object to avoid empty table headers rendering.
- seems like the most viable solution for nested tables for the time being.

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
	public class RecordData
	{
		public int? Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public ChildData[] Children { get; set; }

		public dynamic Container => new { Children };
	}
```

## template
```
«#Records»«ID» | «Title» | «Description»
	«#Container»
		«#Children»
			«Id» | «Type»
		«/Children»
	«/Container»
«/Records»
```
