using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Bll.DTOs;
using ToDoList.Bll.Services;
using ToDoList.Dal.Entity;

namespace ToDoList.Server.Controller;

[Authorize]
[Route("api/toDoList")]
[ApiController]
public class ToDoListController : ControllerBase
{
    private readonly IToDoItemService _toDoItemService;
    private readonly ILogger<ToDoListController> _logger;

    public ToDoListController(IToDoItemService toDoItemService, ILogger<ToDoListController> logger)
    {
        _toDoItemService = toDoItemService;
        _logger = logger;
    }

    [HttpPost("add")]
    public async Task<long> AddToDoItem(ToDoItemCreateDto toDoItemCreateDto)
    {
        _logger.LogInformation("AddToDoItem method worked");

        var id = await _toDoItemService.AddToDoItemAsync(toDoItemCreateDto);
        return id;
    }
    
    [HttpDelete("delete")]
    public async Task DeleteToDoItemByIdAsync(long id)
    {
        _logger.LogInformation("DeleteToDoItemByIdAsync method worked");
        var userIdClaim = User.FindFirst("sub") ?? User.FindFirst("UserId") ?? User.FindFirst(ClaimTypes.NameIdentifier);
        long userId = long.Parse(userIdClaim.Value);
        
        



        await _toDoItemService.DeleteToDoItemByIdAsync(id, userId);
    }

    [HttpGet("getCompleted")]
    public Task<GetAllResponseModel> GetCompletedAsync(int skip, int take)
    {

        return _toDoItemService.GetCompletedAsync(skip, take);
    }

    
    [HttpGet("getAll")]
    public async Task<GetAllResponseModel> GetAllToDoItemsAsync(int skip, int take)
    {
        _logger.LogInformation($"GetAllToDoItemsAsync method worked");

        var userIdClaim =  User.FindFirst("UserId") ?? User.FindFirst(ClaimTypes.NameIdentifier);
        long userId = long.Parse(userIdClaim.Value);
        return await _toDoItemService.GetAllToDoItemsAsync(userId, skip, take);
    }

    [HttpGet("getById")]
    public async Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id)
    {
        var userIdClaim = User.FindFirst("UserId") ?? User.FindFirst(ClaimTypes.NameIdentifier);
        long userId = long.Parse(userIdClaim.Value);
        return await _toDoItemService.GetToDoItemByIdAsync(id, userId);
    }

    [HttpGet("getByDueDate")]
    public Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dueDate)
    {
        return _toDoItemService.GetByDueDateAsync(dueDate);
    }

    [HttpGet("getIncompleted")]
    public Task<GetAllResponseModel> GetIncompleteAsync(int skip, int take)
    {
        return _toDoItemService.GetIncompleteAsync(skip, take);
    }

    [HttpPut("update")]
    public async Task UpdateToDoItemAsync(ToDoItemUpdateDto toDoItemUpdateDto)
    {
        _logger.LogInformation("UpdateToDoItemAsync method worked");
        var userIdClaim = User.FindFirst("sub") ?? User.FindFirst("UserId") ?? User.FindFirst(ClaimTypes.NameIdentifier);
        long userId = long.Parse(userIdClaim.Value);

        await _toDoItemService.UpdateToDoItemAsync(toDoItemUpdateDto, userId);
    }
}
