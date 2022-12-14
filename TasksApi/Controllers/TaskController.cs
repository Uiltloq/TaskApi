using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Dto;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskSerivce;

        public TaskController(ITaskService taskSerivce)
        {
            _taskSerivce = taskSerivce;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Models.Task>>> Get()
        {
            var tasks = await _taskSerivce.GetTasks();
            if (tasks.Count == 0)
            {
                return NotFound("0 Задач");
            }
            return Ok(tasks);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Models.Task>> Get(int id)
        {
            var task = await _taskSerivce.GetTask(id);
            if (task == null)
            {
                return NotFound("Задача не найдена");
            }
            return Ok(task);
        }
        /// <summary>
        /// Метод для получения задач
        /// </summary>
        /// <param name="value">Количество записей</param>
        /// <returns></returns>
        [HttpGet("value")]
        public async Task<ActionResult<List<Models.Task>>> GetLimitTask(int value)
        {
            var tasks = await _taskSerivce.GetTasksLimit(value);
            return Ok(tasks);
        }
        
        [HttpPost]
        public async Task<ActionResult<Models.Task>> Create(CreateTaskDto request)
        {
            var task = new Models.Task
            {
                Name = request.Name,
                Date = request.Date,
                StatusId = request.StatusId
            };
            await _taskSerivce.Create(task);
            return Ok(task);
        }
        
        [HttpPut("id")]
        public async Task<ActionResult<Models.Task>> Update(int id, UpdateTaskDto request)
        {
            var dbTask = await _taskSerivce.GetTask(id);
            if(dbTask == null)
            {
                return NotFound("Такой задачи нет");
            }
            dbTask.StatusId = request.StatusId;
            dbTask.Name = request.Name;
            dbTask.Date = request.Date;
            await _taskSerivce.Update(dbTask);
            return await Get(id);
        }
        
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskSerivce.Delete(id);
            return Ok();
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [HttpPost]
        [Route("UploadFile")]
        public async Task<ActionResult> UploadFile(IFormFile file, int id)
        {
            if (file == null)
               throw new ArgumentNullException(nameof(file));
            if (id == 0)
                throw new ArgumentNullException(nameof(id));
            await _taskSerivce.UploadFile(file, id);
            return Ok();
        }
    }
}
