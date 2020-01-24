using System;

namespace ToDoService.Models
{
    public class ToDoTask{

        public int id { get; set; }

        public DateTime timeStamp { get; set; }

        public string description { get; set; }

    }
}