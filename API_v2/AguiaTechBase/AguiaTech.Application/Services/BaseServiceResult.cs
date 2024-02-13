using MediatR;

namespace AguiaTech.Application.Services;
public class BaseServiceResult(string message, bool success, object? data, IReadOnlyCollection<INotification>? notifications)
{
    public string Message { get; set; } = message;
    public IReadOnlyCollection<INotification>? Notifications { get; set; } = notifications;
    public bool Success { get; set; } = success;
    public object? Data { get; set; } = data;
}
