using System.Collections.Generic;
using System.Security;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.Utils;

namespace GraphLibrary.SpanningTree;

public class SpanningTree
{
    public static List<Edge> JarnikSpanningTree(IGraphRepresentation graph, int root)
    {
        var queue = new PriorityQueue<Edge, int>();
        var vertexList = Utils.Utils.CreateVertecies(graph, root);
        foreach (var edge in graph.GetVertexEdges(root))
        {
            queue.Enqueue(edge, edge.Weight);
        }
        var spanningTree = new List<Edge>();
        while(queue.Count < graph.GetVertices().Count)
        {
            var edge = queue.Dequeue();
            if (vertexList[edge.EndVertex].Visited)
                continue;
            vertexList[edge.EndVertex].Visited = true;
            spanningTree.Add(edge);
            foreach (var nextEdge in graph.GetVertexEdges(edge.EndVertex))
            {
                if (!vertexList[nextEdge.EndVertex].Visited)
                {
                    queue.Enqueue(nextEdge, nextEdge.Weight);
                }
            }
        }

        return spanningTree;
    }
}