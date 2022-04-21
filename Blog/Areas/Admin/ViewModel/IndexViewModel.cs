using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.DbModels;

namespace Blog.Areas.Admin.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
