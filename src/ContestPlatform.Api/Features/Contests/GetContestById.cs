using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ContestPlatform.Api.Core;
using ContestPlatform.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContestPlatform.Api.Features
{
    public class GetContestById
    {
        public class Request: IRequest<Response>
        {
            public Guid ContestId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ContestDto Contest { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IContestPlatformDbContext _context;
        
            public Handler(IContestPlatformDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Contest = (await _context.Contests.SingleOrDefaultAsync(x => x.ContestId == request.ContestId)).ToDto()
                };
            }
            
        }
    }
}
