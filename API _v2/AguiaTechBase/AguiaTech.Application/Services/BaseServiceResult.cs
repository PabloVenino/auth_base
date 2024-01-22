using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Application.Services;
public class BaseServiceResult(string message, bool success, object? data, IReadOnlyCollection<string>? errors)
{
    public string Message { get; set; } = message;
    public IReadOnlyCollection<string>? Errors { get; set; } = errors;
    public bool Success { get; set; } = success;
    public object? Data { get; set; } = data;
}
