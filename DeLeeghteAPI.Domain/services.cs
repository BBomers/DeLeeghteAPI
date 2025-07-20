using DeLeeghteAPI.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Domain
{
    public class services
    {
        public static void RegisterServices(IServiceCollection services, string ConnectionSting)
        {
            services.AddMySql<DeLeeghteContext>(ConnectionSting, ServerVersion.AutoDetect(ConnectionSting), options => options.MigrationsAssembly("DeLeeghteAPI.Domain"));
        }
    }
}
