using System;
namespace GeneralPractPartSec.Models
{
    public class Status
    {
        public int Id { get;  }
        private int _id;
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SharedDate { get; set; }
       
        public Status(string title, string content)
        {
            _id++;
            Id = _id;
            Title = title;
            Content = content;
            SharedDate = DateTime.Now;
        }
        
    }
}
