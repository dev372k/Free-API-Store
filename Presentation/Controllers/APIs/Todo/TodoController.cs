using Application.Abstractions.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers.APIs.Todo
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private IStateHelper _stateHelper;
        private ITodoRepo _todoRepo;

        public TodoController(IStateHelper stateHelper,
            ITodoRepo todoRepo)
        {
            _stateHelper = stateHelper;
            _todoRepo = todoRepo;
        }

        [HttpGet, Authorize]
        public IActionResult Get([FromQuery] int pageNo = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var res = _todoRepo.Get(_stateHelper.User().Id, pageNo == 0 ? 1 : pageNo, pageSize);
                return Ok(new ResponseModel { Data = res });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
            }
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _todoRepo.Get(id);
                return Ok(new ResponseModel { Data = res });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Add(UpsertTodoDTO req)
        {
            try
            {
                var res = await _todoRepo.Add(_stateHelper.User().Id, req);
                return Ok(new ResponseModel { Data = new { TodoId = res } });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Update(int id, UpsertTodoDTO req)
        {
            try
            {
                var res = await _todoRepo.Update(id, req);
                return Ok(new ResponseModel { Data = new { TodoId = res } });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
            }
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _todoRepo.Delete(id);
                return Ok(new ResponseModel { Data = new { TodoId = res } });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
            }
        }
    }
}
