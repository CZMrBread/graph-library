using System.Collections;
using System.Collections.Generic;
using System.Resources;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.Utils;

namespace GraphLibrary.PathFinding;

public class PathFinding
{
    
    public static List<Edge> DijkstraPathFinding(IGraphRepresentation graph,int startVertex, int endVertex)
    {
        if(Utils.Utils.HasGraphNegativeEdge(graph))
            throw new System.ArgumentException("Graph has negative edge");
        var vertexQueue = new PriorityQueue<Vertex, int>();
        var vertexList = new List<Vertex>();
        foreach (var vertexId in graph.GetVertices())
        {
            var vertex = new Vertex(vertexId);
            if (vertex.Id == startVertex)
            {
                vertex.Distance = 0;
            }
            vertexList.Insert(vertexId, vertex);
            vertexQueue.Enqueue(vertex, vertex.Distance);
        }
        while (vertexQueue.Count > 0)
        {
            var vertex = vertexQueue.Dequeue();
            foreach (var edges in graph.GetVertexEdges(vertex.Id))
            {
                var distance = vertex.Distance + edges.Weight;
                if (distance < vertexList[edges.EndVertex].Distance)
                {
                    vertexList[edges.EndVertex].Distance = distance;
                    vertexList[edges.EndVertex].Previous = vertex;
                    vertexQueue.Enqueue(vertexList[edges.EndVertex], distance);
                }
            }
        }
        var path = new List<Edge>();
        var currentVertex = vertexList[endVertex];
        while (currentVertex.Previous != null)
        {
            path.Insert(0, new Edge(currentVertex.Previous.Id, currentVertex.Id, currentVertex.Distance - currentVertex.Previous.Distance));
            currentVertex = currentVertex.Previous;
        }
        return path;
    }
}