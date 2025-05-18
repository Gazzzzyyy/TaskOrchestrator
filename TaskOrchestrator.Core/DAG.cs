namespace TaskOrchestrator.Core;



/// <summary>
/// Represents a directed acyclic graph (DAG) of tasks.
/// </summary>
public sealed class DAG
{
    private readonly Dictionary<string, DAGNode> _nodes = new();
    public IReadOnlyCollection<DAGNode> Nodes => _nodes.Values;

    public void AddNode(DAGNode node)
    {
        if (_nodes.ContainsKey(node.Id)) 
            throw new InvalidOperationException($"Node with ID {node.Id} has already been added");
        
        _nodes.Add(node.Id, node);
    }

    public void AddDependencies(string fromId, string toId)
    {
        if (!_nodes.TryGetValue(fromId, out var from) || !_nodes.TryGetValue(toId, out var to))
            throw new KeyNotFoundException("Dependency IDs must reference existing nodes.");

        from.Dependents.Add(to);
        to.Dependencies.Add(from);
    }

    public List<DAGNode> GetTaskExecutionOrder()
    {
        var visted = new HashSet<DAGNode>();
        var result = new List<DAGNode>();

        void Visit(DAGNode node)
        {
            if (visted.Contains(node))
                return;
            
            foreach (var dep in node.Dependencies)
                Visit(dep);
            
            visted.Add(node);
            result.Add(node);

        }
        
        foreach (var node in _nodes.Values)
            Visit(node);
        
        return result;
        
    }


}