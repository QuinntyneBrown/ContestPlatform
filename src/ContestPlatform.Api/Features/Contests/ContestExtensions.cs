using System;
using ContestPlatform.Api.Models;

namespace ContestPlatform.Api.Features
{
    public static class ContestExtensions
    {
        public static ContestDto ToDto(this Contest contest)
        {
            return new ()
            {
                ContestId = contest.ContestId
            };
        }
        
    }
}
