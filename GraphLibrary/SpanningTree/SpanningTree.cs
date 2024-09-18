using System.Collections.Generic;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.Utils;

namespace GraphLibrary.SpanningTree;

/// <summary>
///     Provides methods for finding the spanning tree in a graph.
/// </summary>
public static class SpanningTree
{
    /// <summary>
    ///     Implementation of Jarnik's algorithm also known as Prim's for finding the minimal spanning tree in a graph.
    /// </summary>
    /// <param name="graph">Graph representation</param>
    /// <param name="root">ID of root <see cref="Vertex" /> of the spanning tree </param>
    /// <returns>Minimal spanning tree as list of <see cref="Edge" />s</returns>
    public static List<Edge> JarnikSpanningTree(IGraphRepresentation graph, int root)
    {
        var queue = new PriorityQueue<Edge, int>();
        var vertexList = new List<Vertex>();
        foreach (var vertex in graph.GetVertices())
        {
            if (vertex.Id == root) vertex.Distance = 0;

            vertexList.Insert(vertex.Id, vertex);
        }

        foreach (var edge in graph.GetVertexEdges(root)) queue.Enqueue(edge, edge.Weight);

        var spanningTree = new List<Edge>();
        while (queue.Count > 0)
        {
            var edge = queue.Dequeue();
            if (vertexList[edge.EndVertex].Visited)
                continue;
            vertexList[edge.EndVertex].Visited = true;
            spanningTree.Add(edge);
            foreach (var nextEdge in graph.GetVertexEdges(edge.EndVertex))
                if (!vertexList[nextEdge.EndVertex].Visited)
                    queue.Enqueue(nextEdge, nextEdge.Weight);
        }

        return spanningTree;
    }
}