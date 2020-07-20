using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VLS_APIProject.Data
{
    public class VLSDbContextFactory : IDesignTimeDbContextFactory<VLSDbContext>
    {
        public VLSDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new VLSDbContext(new DbContextOptionsBuilder<VLSDbContext>().Options, config);
        }
    }
}
