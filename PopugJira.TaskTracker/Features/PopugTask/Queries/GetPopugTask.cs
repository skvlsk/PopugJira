using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopugJira.Framework;

namespace PopugJira.TaskTracker.Features.PopugTask.Queries
{
    public class GetPopugTask
    {
        public class Query : IRequest<PopugTaskDto>
        {
            public string Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, PopugTaskDto>
        {
            private IRepository<PopugTaskDocument, string> _popugTaskRepository;
            
            public QueryHandler(IRepository<PopugTaskDocument, string> popugTaskRepository) => _popugTaskRepository = popugTaskRepository;

            public async Task<PopugTaskDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var popugTask = await _popugTaskRepository.GetById(request.Id);

                return popugTask.ToDto();
            }
        }
    }
}