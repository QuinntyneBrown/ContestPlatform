using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using ContestPlatform.Api.Core;
using ContestPlatform.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContestPlatform.Api.Features
{
    public class GetContests
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<ContestDto> Contests { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IContestPlatformDbContext _context;
        
            public Handler(IContestPlatformDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Contests = await _context.Contests.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
