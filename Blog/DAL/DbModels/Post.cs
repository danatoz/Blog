using System;

namespace Blog.DAL.DbModels
{
    public class Post
    {
        public int Id { get; set; }  
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Publicated { get; set; }
        public DateTime? PublicateDate { get; set; }
    }
}
