using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoService.Models;
using ToDoService.Service;

namespace ToDoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private IToDoService _data;

        public TodoController(IToDoService data){
            _data = data;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ToDoTask> Get()
        {
            
            return  _data.GetAllTask();
           
        }


        // POST api/values
        [HttpPost]
        public int Post([FromBody] ToDoTask task)
        {
            
            int count=_data.SaveTask(task);
            return count;
            
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
        
            return _data.DeleteTask(id);

        }
    }
}
