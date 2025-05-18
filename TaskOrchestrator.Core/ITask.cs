namespace TaskOrchestrator.Core;

public interface ITask
{
    string Name { get; }

    /// <summary>
    /// Executes the task and returns a TaskResult.  
    /// </summary>
    /// <param name="input">Optional input from previous tasks.</param>
    /// <param name="cancellationToken">Token for cancellation.</param>
    /// <returns>A TaskResult representing the outcome.</returns>

    Task<TaskResult> ExecuteAsync(object? input = null, CancellationToken cancellationToken = default);

}

