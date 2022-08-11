using Microsoft.AspNetCore.Mvc;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("id")]
        public async Task<ActionResult<UploadResult>> Get(int id)
        {
            var file = await _fileService.GetFile(id);
            return Ok(file);
        }
        [HttpGet]
        public async Task<ActionResult<List<UploadResult>>> Get()
        {
            var files = await _fileService.GetFiles();
            return Ok(files);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            await _fileService.Delete(id);
            return Ok();
        }

    }
}
