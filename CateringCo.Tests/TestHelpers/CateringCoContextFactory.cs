using CateringCo.Models;
using Microsoft.EntityFrameworkCore;

namespace CateringCo.Tests.TestHelpers
{
        public static class CateringCoContextFactory
        {
            public static CateringCoContext Create(string dbName)
            {
                var options = new DbContextOptionsBuilder<CateringCoContext>()
                    .UseInMemoryDatabase(databaseName: dbName)
                    .Options;
                return new CateringCoContext(options);
            }
        }
    }

