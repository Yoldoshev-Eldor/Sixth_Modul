using ToDoList.Bll.DTOs;

namespace ToDoList.Bll.Services
{
    public interface IToDoItemService
    {
        Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dueDate);
        Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id,long userId);
        Task<GetAllResponseModel> GetAllToDoItemsAsync(long userId , int skip, int take);
        Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItem);
        Task DeleteToDoItemByIdAsync(long id,long userId);
        Task UpdateToDoItemAsync(ToDoItemUpdateDto newItem,long userId);
        Task<GetAllResponseModel> GetCompletedAsync(int skip, int take);
        Task<GetAllResponseModel> GetIncompleteAsync(int skip, int take);
        Task<int> GetTotalCountAsync();

    }
}
