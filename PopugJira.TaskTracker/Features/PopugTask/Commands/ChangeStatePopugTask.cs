using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopugJira.Framework;

namespace PopugJira.TaskTracker.Features.PopugTask.Commands
{
    public class ChangeStatePopugTask
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public PopugTaskState State { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly IRepository<PopugTaskDocument, string> _popugTaskRepository;

            public CommandHandler(IRepository<PopugTaskDocument, string> popugTaskRepository)
            {
                _popugTaskRepository = popugTaskRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //TODO: add normal update in repo
                var popugTaskDocument = await _popugTaskRepository.GetById(request.Id);

                if (popugTaskDocument is null)
                {
                    throw new Exception($"Popug task with id={request.Id} is not found.");
                }

                popugTaskDocument.State = request.State;

                await _popugTaskRepository.Update(popugTaskDocument);
                
                return Unit.Value;
            }
        }
    }
}