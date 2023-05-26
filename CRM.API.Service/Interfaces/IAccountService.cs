using CRM.API.Models;
using CRM.API.Response;
using CRM.Domain.ViewModel;
using System.Security.Claims;

namespace CRM.API.Interfaces
{
    public interface IAccountService
    {

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
    public interface IAuthorService
    {
        Task<IBaseResponse<Author>> Create(AuthorViewModel model);

        BaseResponse<Dictionary<int, string>> GetRoles();

        Task<BaseResponse<IEnumerable<AuthorViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(long id);
    }

    public interface INotesService
    {
        BaseResponse<IEnumerable<Application>> GetContacts();

        Task<IBaseResponse<Application>> GetContactById(int id);

        Task<IBaseResponse<Application>> GetContactByName(string name);

        Task<IBaseResponse<bool>> DeleteContact(int id);

        Task<IBaseResponse<Application>> CreateContact(ApplicationViewModel cvm);

        Task<IBaseResponse<Application>> Edit(int id, ApplicationViewModel model);
        Task<IBaseResponse<Application>> Edit(ApplicationViewModel model);
    }
}
