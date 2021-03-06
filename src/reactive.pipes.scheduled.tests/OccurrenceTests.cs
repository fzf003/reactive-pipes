using System;
using reactive.pipes.scheduled;
using Xunit;

namespace reactive.tests.Scheduled
{
    public class OccurrenceTests
    {
        [Fact]
        public void Occurrence_is_in_UTC()
        {
            var task = new ScheduledTask();
            task.RunAt = DateTimeOffset.UtcNow;
            
            task.Expression = CronTemplates.Daily(1, 3, 30);
            DateTimeOffset? next = task.NextOccurrence;
            Assert.NotNull(next);
            Assert.True(next.Value.Hour == 3);
            Assert.Equal(next.Value.Hour, next.Value.UtcDateTime.Hour);
        }
    }
}