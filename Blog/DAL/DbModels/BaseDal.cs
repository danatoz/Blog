using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.DbModels
{
    public class BaseDal<TDbContext>
        where TDbContext : DbContext, new()
    {
        protected TDbContext _context;

        public BaseDal()
        {
            
        }
        public BaseDal(TDbContext context)
        {
            _context = context;
        }
    }
}
