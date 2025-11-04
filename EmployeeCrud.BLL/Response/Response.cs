namespace EmployeeCrud.BLL.Response
{
public record Response<T>(T Result, string? ErrorMessage,bool HasError);
}
