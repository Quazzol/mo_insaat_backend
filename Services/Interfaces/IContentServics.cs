using Backend.DTOs;
using Backend.DTOs.Request;
using Backend.DTOs.Response;

namespace Backend.Services.Interfaces;

public interface IContentService
{
    public Task<ContentDTO?> Get(Guid id);
    public Task<IEnumerable<ContentDTO?>> GetAll(Guid? contentTypeId);
    public Task<IEnumerable<MenuItem?>> GetAllTitle(string languageCode);
    public Task<IEnumerable<ContentDTO>> GetVisibleOnMainPage(string languageCode);
    public Task<ContentDTO?> Insert(ContentInsertDTO content);
    public Task<ContentTitleDTO?> InsertContentTitle(ContentTitleInsertDTO title);
    public Task<ContentDTO?> Update(ContentUpdateDTO content);
    public Task<ContentTitleDTO?> UpdateContentTitle(ContentTitleUpdateDTO title);
    public Task Delete(Guid id);
}