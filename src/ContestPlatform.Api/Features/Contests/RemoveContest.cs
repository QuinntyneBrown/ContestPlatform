using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using ContestPlatform.Api.Models;
using ContestPlatform.Api.Core;
using ContestPlatform.Api.Interfaces;

namespace ContestPlatform.Api.Features
{
    public class RemoveContest
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
                var contest = await _context.Contests.SingleAsync(x => x.ContestId == request.ContestId);
                
                _context.Contests.Remove(contest);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Contest = contest.ToDto()
                };
            }
            
        }
    }
}
