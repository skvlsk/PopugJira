using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopugJira.Framework;

namespace PopugJira.TaskTracker.Features.PopugTask.Commands
{
    public class CreatePopugTask
    {
        public class Command : IRequest<PopugTaskDto>
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string AssigneeId { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, PopugTaskDto>
        {
            private readonly IRepository<PopugTaskDocument, string> _popugTaskRepository;
            
            public CommandHandler(IRepository<PopugTaskDocument, string> popugTaskRepository)
            {
                _popugTaskRepository = popugTaskRepository;
            }

            public async Task<PopugTaskDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var popugTask = new PopugTaskDocument
                {
                    Id = IdGenerator.GetNewId(),
                    Title = request.Title,
                    Description = request.Description,
                    AssigneeId = request.AssigneeId
                };
                
                //popugTask.Rate = calculate rate service call
                popugTask.Rate = StaticRandom.Next(20, 40);

                
                var document = await _popugTaskRepository.Insert(popugTask);

                return document.ToDto();
            }
        }
    }
}