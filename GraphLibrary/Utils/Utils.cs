using System.Collections.Generic;
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
    public static List<Vertex> CreateVertices(IGraphRepresentation graph, int startVertex)
    {
        var vertexList = new List<Vertex>();
        foreach (var vertexId in graph.GetVertices())
        {
            var vertex = new Vertex(vertexId);
            if (startVertex == vertexId)
            {
                vertex.Visited = true;
                vertex.Distance = 0;
            }
            vertexList.Insert(vertexId, vertex);
        }

        return vertexList;
    }
}