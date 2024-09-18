using GraphLibrary.GraphRepresentation;

namespace GraphLibrary.Utils;

/// <summary>
/// Set of helper functions for graph operations.
/// </summary>
public static class Utils
{
    /// <summary>
    /// Check if the graph has a negative edge.
    /// </summary>
    /// <param name="graph">Graph representation</param>
    /// <returns>True if there is negative edge in graph</returns>
    public static bool HasGraphNegativeEdge(IGraphRepresentation graph)
    {
        foreach (var vertex in graph.GetVertices())
        {
            var vertexEdges = graph.GetVertexEdges(vertex.Id);
            foreach (var edge in vertexEdges)
                if (edge.Weight < 0)
                    return true;
        }

        return false;
    }
}