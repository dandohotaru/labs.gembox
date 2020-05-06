using System;
using Labs.Core.Demo2.Models;
using Labs.Core.Shared;

namespace Labs.Core.Demo2
{
    public class Demo2Provider : IReportProvider<ReportData>
    {
        public ReportData Build(string context)
        {
            var random = new Random();

            return new ReportData
            {
                Title = context,
                Notes = random.Text(75),
                Stamp = DateTime.Now,
                Records = new[]
                {
                    new RecordData
                    {
                        Id = random.Next(10, 19),
                        Title = "Sample 1",
                        Description = random.Text(20),
                        Children = new[]
                        {
                            new ChildData {Id = random.Next(100, 199), Type = "one"},
                            new ChildData {Id = random.Next(100, 199), Type = "two"},
                            new ChildData {Id = random.Next(100, 199), Type = "three"},
                            new ChildData {Id = random.Next(100, 199), Type = "four"}
                        }
                    },
                    new RecordData
                    {
                        Id = random.Next(20, 29),
                        Title = "Sample 2",
                        Description = random.Text(20)
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
                        Children = new[]
                        {
                            new ChildData {Id = random.Next(400, 499), Type = "stuff"},
                            new ChildData {Id = random.Next(400, 499), Type = "abcd"}
                        }
                    },
                    new RecordData
                    {
                        Id = random.Next(50, 59),
                        Title = "Sample 5",
                        Description = random.Text(20)
                    }
                }
            };
        }
    }
}