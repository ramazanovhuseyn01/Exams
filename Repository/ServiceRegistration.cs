
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ServiceDescriptors(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
