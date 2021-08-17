using Microsoft.Extensions.DependencyInjection;
using System;
using MB.Application;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastracture.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            services.AddDbContext<MasterBloggerContext>(option =>
                option.UseSqlServer(connectionString));
        }
    }
}