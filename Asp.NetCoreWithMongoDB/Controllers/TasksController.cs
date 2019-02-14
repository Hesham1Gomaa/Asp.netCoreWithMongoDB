using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.NetCoreWithMongoDB.Service;
using Asp.NetCoreWithMongoDB.Models;

namespace Asp.NetCoreWithMongoDB.Controllers
{
    [Produces("application/json")]
    [Route("api/Tasks")]
    public class TasksController : Controller
    {

        private readonly TaskService _taskService;
        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }
        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Tasks> Get()
        {
            return _taskService.Get();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public Tasks Get(string id)
        {
            return _taskService.Get(id);
        }

        // POST: api/Tasks
        [HttpPost]
        public Tasks Post([FromBody]Tasks task)
        {
            _taskService.Create(task);

            return Get(task._id);

        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Tasks task)
        {
            var _task = _taskService.Get(id);

            if (_task == null)
            {
                return NotFound();
            }

            _taskService.Update(id, task);

            return NoContent();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var task = _taskService.Get(id);

            if (task == null)
            {
                return NotFound();
            }

            _taskService.Remove(task._id);

            return NoContent();
        }
    }
}
