using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ContestPlatform.Api.Models;
using ContestPlatform.Api.Core;
using ContestPlatform.Api.Interfaces;

namespace ContestPlatform.Api.Features
{
    public class CreateContest
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
                var contest = new Contest();
                
                _context.Contests.Add(contest);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Contest = contest.ToDto()
                };
            }
            
        }
    }
}
