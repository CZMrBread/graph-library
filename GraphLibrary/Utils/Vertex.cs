namespace GraphLibrary.Utils;

/// <summary>
///     Represents a vertex in a graph.
/// </summary>
/// <param name="id">Unique identifier of vertex</param>
public class Vertex(int id)
{
    /// <summary>
    ///     Unique identifier of vertex
    /// </summary>
    public readonly int Id = id;

    /// <summary>
    ///     Distance from the start vertex in the graph after path finding or spanning tree algorithm.
    /// </summary>
    public int Distance = int.MaxValue;

    /// <summary>
    ///     Previous vertex in the graph after path finding or spanning tree algorithm.
    /// </summary>
    public Vertex? Previous = null;

    /// <summary>
    ///     Flag for visited vertex in the graph after path finding or spanning tree algorithm.
    /// </summary>
    public bool Visited = false;
}