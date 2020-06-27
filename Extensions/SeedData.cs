using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QandA_lesson1.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QandA_lesson1.Extensions
{
    public static  class SeedData
    {
        public static void EnsureSeeded(this IApplicationBuilder app )
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                QandAContext dbContext = serviceScope.ServiceProvider.GetRequiredService<QandAContext>();

                dbContext.Database.Migrate();
                if (!dbContext.Users.Any())
                {
                    var us = new User
                    {
                        Username = "admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("admin")
                    };
                    dbContext.Users.Add(us);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
