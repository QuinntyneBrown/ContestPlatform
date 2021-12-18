using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ContestPlatform.Api.Core;
using ContestPlatform.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContestPlatform.Api.Features
{
    public class UpdateContest
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Contest).NotNull();
                RuleFor(request => request.Contest).SetValidator(new ContestValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ContestDto Contest { get; set; }
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
                var contest = await _context.Contests.SingleAsync(x => x.ContestId == request.Contest.ContestId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Contest = contest.ToDto()
                };
            }
            
        }
    }
}
