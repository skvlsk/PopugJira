using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PopugJira.TaskTracker.Features.PopugTask
{
    public class PopugTaskDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssigneeId { get; set; }
        public int Rate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PopugTaskState State { get; set; }
    }
}