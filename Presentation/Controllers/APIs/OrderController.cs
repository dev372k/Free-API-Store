using Application.Abstractions.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers.APIs;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IOrderRepo _orderRepo;

    public OrderController(IOrderRepo orderRepo
        )
    {
        _orderRepo = orderRepo;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int pageNo = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var res = _orderRepo.Get(pageNo == 0 ? 1 : pageNo, pageSize);
            return Ok(new ResponseModel { Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() }); ;
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var res = _orderRepo.Get(id);
            return Ok(new ResponseModel { Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() }); ;
        }
    }
    
    [HttpGet("{userId}/user")]
    public IActionResult GetbyUserId(int userId)
    {
        try
        {
            var res = _orderRepo.GetbyUserId(userId);
            return Ok(new ResponseModel { Data = res });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() }); ;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddOrderDTO req)
    {
        try
        {
            var res = await _orderRepo.Add(req);
            return Ok(new ResponseModel { Message = "Order added successfully.", Data = new { OrderId = res } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() }); ;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateOrderDTO req)
    {
        try
        {
            var res = await _orderRepo.Update(id, req);
            return Ok(new ResponseModel { Message = "Order updated successfully.", Data = new { OrderId = res } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() }); ;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var res = await _orderRepo.Delete(id);
            return Ok(new ResponseModel { Message = "Order deleted successfully.", Data = new { OrderId = res } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() }); ;
        }
    }
}
