using System;
using Labs.Core.Models;

namespace Labs.Core.Providers
{
    public class MemoryProvider
    {
        public DataSource Build()
        {
            var random = new Random();

            return new DataSource
            {
                Title = "This is the title",
                Stamp = DateTime.Now,
                Records = new[]
                {
                    new RecordRow
                    {
                        Id = 1, Title = "Sample 1", Description = "Sample 1",
                        Children = new[]
                        {
                            new ChildRow {Id = random.Next(100), Type = "one"},
                            new ChildRow {Id = random.Next(100), Type = "two"},
                            new ChildRow {Id = random.Next(100), Type = "three"},
                            new ChildRow {Id = random.Next(100), Type = "four"},
                        },
                    },
                    new RecordRow
                    {
                        Id = 2, Title = "Sample 2", Description = "Sample 2"
                    },
                    new RecordRow
                    {
                        Id = 3, Title = "Sample 3", Description = "Sample 3"
                    },
                    new RecordRow
                    {
                        Id = 4, Title = "Sample 4", Description = "Sample 4",
                        Children = new []
                        {
                            new ChildRow {Id = random.Next(100), Type = "stuff"},
                            new ChildRow {Id = random.Next(100), Type = "abcd"},
                        }
                    },
                    new RecordRow
                    {
                        Id = 5, Title = "Sample 5", Description = "Sample 5"
                    },
                }
            };
        }
    }
}