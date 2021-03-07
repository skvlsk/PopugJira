using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopugJira.Framework;

namespace PopugJira.TaskTracker.Features.PopugTask.Queries
{
    public class GetAllPopugTasks
    {
        public class Query : IRequest<List<PopugTaskDto>>
        {
            
        }

        public class QueryHandler : IRequestHandler<Query, List<PopugTaskDto>>
        {
            private readonly IRepository<PopugTaskDocument, string> _popugTaskRepository;

            public QueryHandler(IRepository<PopugTaskDocument, string> popugTaskRepository)
            {
                _popugTaskRepository = popugTaskRepository;
            }

            public async Task<List<PopugTaskDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var popugTaskDocuments = await _popugTaskRepository.GetList(_ => true);

                return popugTaskDocuments.Select(x => x.ToDto()).ToList();
            }
        }
    }
}