using MyNewApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewApp.DataAccess.IRepository
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        void Update(Expense obj);
        void Save();
    }
}
