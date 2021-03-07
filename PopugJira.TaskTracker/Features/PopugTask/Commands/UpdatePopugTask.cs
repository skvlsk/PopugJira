using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopugJira.Framework;

namespace PopugJira.TaskTracker.Features.PopugTask.Commands
{
    public class UpdatePopugTask
    {
        public class Command : IRequest<PopugTaskDto>
        {
            //public List<key value> UpdateDefinitions
            public string Id { get; set; }
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
                //TODO: add normal update in repo
                var popugTaskDocument = await _popugTaskRepository.GetById(request.Id);

                if (popugTaskDocument is null)
                {
                    throw new Exception($"Popug task with id={request.Id} is not found.");
                }

                popugTaskDocument.Title = request.Title;
                popugTaskDocument.Description = request.Description;
                popugTaskDocument.AssigneeId = request.AssigneeId;
                
                var updateResult = await _popugTaskRepository.Update(popugTaskDocument);

                return updateResult.ToDto();
            }
        }
    }
}