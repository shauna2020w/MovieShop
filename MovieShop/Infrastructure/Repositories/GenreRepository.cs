using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>, IAsyncRepository<Genre>
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public override Task<Genre> GetByIdAsync(int id)
        {
            return _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }

        public Task<Genre> GetByNameAsync(string genreName)
        {
            return _dbContext.Genres.FirstOrDefaultAsync(g => g.Name == genreName);
        }
    }
}
