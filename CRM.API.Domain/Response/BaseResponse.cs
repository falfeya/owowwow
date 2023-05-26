

namespace CRM.API.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        string Description { get; }
        T Data { get; }

        StatusCode StatusCode { get; }
    }

    public enum StatusCode
    {
        //User
        UserNotFound = 0,
        ContactNotFound = 10,
        UserAlreadyExist = 20,
        OK = 200,
        //NotFound = 404,
        InternalServerError = 500,
    }
}
