using System;

namespace ContestPlatform.Api.Features
{
    public class ContestDto
    {
        public Guid? ContestId { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
