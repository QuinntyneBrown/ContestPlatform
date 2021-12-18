using System;

namespace ContestPlatform.Api.Models
{
    public class Contest
    {
        public Guid ContestId { get; private set; }
        public string Name { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    }
}
