using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ContestPlatform.Api.Extensions;
using ContestPlatform.Api.Core;
using ContestPlatform.Api.Interfaces;
using ContestPlatform.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ContestPlatform.Api.Features
{
    public class GetContestsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<ContestDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IContestPlatformDbContext _context;
        
            public Handler(IContestPlatformDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from contest in _context.Contests
                    select contest;
                
                var length = await _context.Contests.CountAsync();
                
                var contests = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = contests
                };
            }
            
        }
    }
}
