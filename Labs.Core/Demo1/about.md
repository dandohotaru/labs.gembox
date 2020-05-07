# about
- merge with simple object like {records[]}
- empty child tables show up as their headers are rendered for each parent row
- when this demo was assembled there was no RemoveEmptyTables clear option but the gembox was planning to add one

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
	}
```

## template
```
	«#Records»«ID» | «Title» | «Description»
		«#Children»
			«Id» | «Type»
		«/Children»
	«/Records»
```