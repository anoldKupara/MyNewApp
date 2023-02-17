using MyNewApp.DataAccess.DbContexts;
using MyNewApp.DataAccess.IRepository;
using MyNewApp.Models;
using MyNewApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewApp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category obj)
        {
            _dbContext.Update(obj);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
