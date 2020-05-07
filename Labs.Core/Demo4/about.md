# about
- merge with simple object like {records: {tags: {value:string}[]}}[]
- map inner string collection to bulleted lists
- rely on implicit operator to ease the data mapping

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
				Tags = new TagData[]
				{
					"digital",
					"media",
					"press",
				}
			},
		}
	}
```
```    
	public class TagData
	{
		public string Value { get; set; }

		public static implicit operator TagData(string value)
		{
			return new TagData { Value = value };
		}
	}
```

## template
```
	«#Tags»
	• «Value»
	«/Tags»
```