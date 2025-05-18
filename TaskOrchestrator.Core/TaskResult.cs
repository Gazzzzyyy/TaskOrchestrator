namespace TaskOrchestrator.Core;


/// <summary>
/// Represents the result of a task execution.
/// </summary>
public sealed record TaskResult
{
    public required TaskStatus Status { get; init; }
    public object? Output { get; init; }
    public string? ErrorMessage { get; init; }

    public static TaskResult Success(object? output = null) => new() { Status = TaskStatus.Success, Output = output };
    public static TaskResult Failure(string error) => new() { Status = TaskStatus.Failed, ErrorMessage = error };

}