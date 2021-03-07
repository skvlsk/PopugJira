using Microsoft.Extensions.DependencyInjection;

namespace PopugJira.Framework
{
    public class PersistenceModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<,>), typeof(InMemoryRepository<,>));
        }
    }
}