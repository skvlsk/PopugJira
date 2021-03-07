using PopugJira.Framework;

namespace PopugJira.TaskTracker.Features.PopugTask
{
    public class PopugTaskDocument : IDocument<string>
    {
        public string Id { get; set; }
        public AuditInfo AuditInfo { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Assigned User Id
        /// </summary>
        public string AssigneeId { get; set; }

        /// <summary>
        /// Task price in $
        /// </summary>
        public int Rate { get; set; }

        public PopugTaskState State { get; set; }
    }

    public static class PopugTaskDocumentExtensions
    {
        public static PopugTaskDto ToDto(this PopugTaskDocument document)
        {
            return new PopugTaskDto
            {
                Id = document.Id,
                Title = document.Title,
                Description = document.Description,
                AssigneeId = document.AssigneeId,
                State = document.State,
                Rate = document.Rate
            };
        }
    }
}