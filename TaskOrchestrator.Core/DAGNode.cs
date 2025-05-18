namespace TaskOrchestrator.Core;

/// <summary>
/// A node in a task DAG that wraps a task and tracks dependencies.
/// </summary>
public sealed class DAGNode
{
    public required string Id { get; init; }
    public required ITask Task { get; init; }

    public List<DAGNode> Dependencies { get; } = new();
    public List<DAGNode> Dependents { get; } = new();
    
    public override string ToString() => $"{Id} - {Task.Name}";
}