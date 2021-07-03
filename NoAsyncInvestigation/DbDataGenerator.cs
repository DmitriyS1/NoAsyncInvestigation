using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoAsyncInvestigation
{
    public static class DbDataGenerator
    {
        private const int Count = 15000;

        public static async Task SetData(ApplicationDbContext _dbContext)
        {
            var data = new List<Model>(Count);
            var random = new Random();

            for(var i = 0; i < Count; i++)
            {
                data.Add(new Model
                {
                    Price = random.Next()
                });
            }

            await _dbContext.Models.AddRangeAsync(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
