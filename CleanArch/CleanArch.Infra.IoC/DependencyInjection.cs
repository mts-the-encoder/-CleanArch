using CleanArch.Application.Interfaces;
using CleanArch.Application.Mapper;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArch.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<ICategoryService,CategoryService>();
        services.AddScoped<IProductService,ProductService>();
        services.AddAutoMapper(typeof(DomainToDTO));

        var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));


        return services;
    }
}