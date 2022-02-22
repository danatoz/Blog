using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.DbModels;

namespace Blog.Areas.Admin.VIewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; set; }  
    }
}
