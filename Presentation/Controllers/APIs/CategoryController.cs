using Application.Abstractions.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers.APIs;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    private ICategoryRepo _categoryRepo;

    public CategoryController(ICategoryRepo categoryRepo
        )
    {
        _categoryRepo = categoryRepo;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int pageNo = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var res = _categoryRepo.Get(pageNo == 0 ? 1 : pageNo, pageSize);
            return Ok(new ResponseModel { Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddCategoryDTO req)
    {
        try
        {
            var res = await _categoryRepo.Add(req);
            return Ok(new ResponseModel { Message = "Category added successfully.", Data = new { CategoryId = res } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateCategoryDTO req)
    {
        try
        {
            var res = await _categoryRepo.Update(id, req);
            return Ok(new ResponseModel { Message = "Category updated successfully.", Data = new { CategoryId = res } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var res = await _categoryRepo.Delete(id);
            return Ok(new ResponseModel { Message = "Category deleted successfully.", Data = new { CategoryId = res } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }
}
