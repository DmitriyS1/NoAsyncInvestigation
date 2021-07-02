using System;
using System.Collections.Generic;

namespace NoAsyncInvestigation
{
    public class DbDataGenerator
    {
        private readonly ApplicationDbContext _dbContext;
        private const int Count = 15000;

        public DbDataGenerator(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public void SetData()
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
