# about
- merge with simple object like {records[]}
- map inner string collection to bulleted lists
- rely on implicit operator to ease the setup

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
				Children = new ChildData[]
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
	public class ChildData
	{
		public string Value { get; set; }

		public static implicit operator ChildData(string value)
		{
			return new ChildData { Value = value };
		}
	}
```

## template
```
	«#Children»
	• «Value»
	«/Children»
```