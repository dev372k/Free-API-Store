using Application.Abstractions.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;
using Presentation.Models;

namespace Presentation.Controllers.APIs;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductRepo _productRepo;

    public ProductController(IProductRepo productRepo
        )
    {
        _productRepo = productRepo;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int pageNo = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            _productRepo.Test();
            var res = _productRepo.Get(pageNo == 0 ? 1 : pageNo, pageSize);
            return Ok(new ResponseModel { Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var res = _productRepo.Get(id);
            return Ok(new ResponseModel { Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }
    
    [HttpGet("{categoryId}/category")]
    public IActionResult GetbyCatogoryId(int categoryId)
    {
        try
        {
            var res = _productRepo.GetbyCatogoryId(categoryId);
            return Ok(new ResponseModel { Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddProductDTO req)
    {
        try
        {
            var res = await _productRepo.Add(req);
            return Ok(new ResponseModel { Message = "Product added successfully.", Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateProductDTO req)
    {
        try
        {
            var res = await _productRepo.Update(id, req);
            return Ok(new ResponseModel { Message = "Product updated successfully.", Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var res = await _productRepo.Delete(id);
            return Ok(new ResponseModel { Message = "Product deleted successfully.", Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }
}
