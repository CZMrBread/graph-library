namespace GraphLibrary.Utils;

/// <summary>
///     Represents an edge in a graph with weight
/// </summary>
/// <param name="startVertex">ID of edge start <see cref="Vertex" /></param>
/// <param name="endVertex">ID of edge end <see cref="Vertex" /></param>
/// <param name="weight">Weight of the edge</param>
public class Edge(int startVertex, int endVertex, int weight = 1)
{
    public readonly int EndVertex = endVertex;
    public readonly int StartVertex = startVertex;
    public int Weight = weight;
}