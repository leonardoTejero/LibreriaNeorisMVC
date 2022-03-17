using Common.Utils.RestServices;
using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.DependencyInjection;
using libreriaNeoris.Domain.Services;
using libreriaNeoris.Domain.Services.Interface;
using LibreriaDomain.Services.Interface;
using LibreriaDomain.Services;
using LibreriaNeoris.Domain.Services.Interface;
using LibreriaNeoris.Domain.Services;

namespace libreriaNeoris.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            //servicios
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IDatesServices, DatesServices>();
            services.AddTransient<IAuthorServices, AuthorServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();
            services.AddTransient<IBookServices, BookServices>();

            //rest services - consumer
            services.AddTransient<IRestService, RestService>();
        }
    }
}
