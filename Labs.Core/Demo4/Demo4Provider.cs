using System;
using Labs.Core.Demo4.Models;
using Labs.Core.Shared;

namespace Labs.Core.Demo4
{
    public class Demo4Provider : IReportProvider<ReportData>
    {
        public ReportData Build(string title)
        {
            var random = new Random();

            return new ReportData
            {
                Title = title,
                Notes = random.Text(75),
                Stamp = DateTime.Now,
                Records = new[]
                {
                    new RecordData
                    {
                        Id = random.Next(10, 19),
                        Title = "Sample 1",
                        Description = random.Text(20),
                        Tags = new TagData[]
                        {
                            "social",
                            "networks",
                        },
                        Types = new TagData[]
                        {
                            "typea",
                            "typeb",
                            "typec",
                        }
                    },
                    new RecordData
                    {
                        Id = random.Next(20, 29),
                        Title = "Sample 2",
                        Description = random.Text(20),
                        Tags = new TagData[]
                        {
                            "digital",
                            "media",
                            "press",
                        }
                    },
                    new RecordData
                    {
                        Id = random.Next(30, 39),
                        Title = "Sample 3",
                        Description = random.Text(20)
                    },
                    new RecordData
                    {
                        Id = random.Next(40, 49),
                        Title = "Sample 4",
                        Description = random.Text(20),
                        Tags = new TagData[]
                        {
                            random.Text(10),
                            random.Text(7),
                            random.Text(5),
                        }
                    },
                    new RecordData
                    {
                        Id = random.Next(50, 59),
                        Title = "Sample 5",
                        Description = random.Text(20),
                        Types = new TagData[]
                        {
                            "typeb",
                            "typec",
                        }
                    }
                }
            };
        }
    }
}