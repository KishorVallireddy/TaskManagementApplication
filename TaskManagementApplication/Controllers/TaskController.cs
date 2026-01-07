using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Repository;
using System.Security.Claims;

namespace TaskManagementApplication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        private int UserId =>
            int.Parse(User.FindFirst("UserId")!.Value);

        // READ - List
        [HttpGet]
        public IActionResult GetTasks([FromQuery] TaskQuery query)
            {
            string role = "";
            return Ok(_service.GetTasks(UserId, query,role));
                }

        // READ - Single
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
            => Ok(_service.GetById(id, UserId));

        // CREATE
        [HttpPost]
        public IActionResult Create(CreateTaskDto dto)
        {
            var id = _service.Create(UserId, dto);
            return CreatedAtAction(nameof(GetTask), new { id }, null);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTaskDto dto)
        {
            _service.Update(id, UserId, dto);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id, UserId);
            return NoContent();
        }
    }

}
