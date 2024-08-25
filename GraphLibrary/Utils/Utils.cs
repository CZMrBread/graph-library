using GraphLibrary.GraphRepresentation;

namespace GraphLibrary.Utils;

public static class Utils
{
    public static bool HasGraphNegativeEdge(IGraphRepresentation graph)
    {
        foreach (var vertex in graph.GetVertices())
        {
            var vertexEdges = graph.GetVertexEdges(vertex);
            foreach (var edge in vertexEdges)
            {
                if (edge.Weight < 0)
                    return true;
            }
        }

        return false;
    }
}