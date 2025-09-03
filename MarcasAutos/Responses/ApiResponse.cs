namespace MarcasAutos.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ApiResponse<T> SuccessResponse(T data, string? message = null)
        => new() { Success = true, Data = data, Message = message };

    public static ApiResponse<T> ErrorResponse(List<string> errors, string? message = null)
        => new() { Success = false, Errors = errors, Message = message };

    public static ApiResponse<T> ErrorResponse(string error, string? message = null)
        => new() { Success = false, Errors = [error], Message = message };
}