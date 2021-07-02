using System;
using System.Collections.Generic;

namespace NoAsyncInvestigation
{
    public static class DbDataGenerator
    {
        private const int Count = 15000;

        public static void SetData(ApplicationDbContext _dbContext)
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

            _dbContext.Models.AddRange(data);
            _dbContext.SaveChanges();
        }
    }
}
