using System;
using System.Collections.Generic;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.Utils;

namespace GraphLibrary.PathFinding;

public static class PathFinding
{
    public static List<Edge> DijkstraPathFinding(IGraphRepresentation graph, int startVertex, int endVertex)
    {
        if (Utils.Utils.HasGraphNegativeEdge(graph))
            throw new ArgumentException("Graph has negative edge, try different algorithm");
        
        var vertexQueue = new PriorityQueue<Vertex, int>();
        var vertexList = Utils.Utils.CreateVertecies(graph, startVertex);
        foreach (var vertex in vertexList)
        {
            vertexQueue.Enqueue(vertex, vertex.Distance);
        }
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
            path.Insert(0,
                new Edge(currentVertex.Previous.Id, currentVertex.Id,
                    currentVertex.Distance - currentVertex.Previous.Distance));
            currentVertex = currentVertex.Previous;
        }

        return path;
    }

    public static List<Edge> BellmanFordPathFinding(IGraphRepresentation graph, int startVertex, int endVertex)
    {
        var vertexList = Utils.Utils.CreateVertecies(graph, startVertex);
        
        for (var i = 0; i < graph.GetVertices().Count - 1; i += 1)
        {
            foreach (var edges in graph.GetEdges())
            {
                var distance = vertexList[edges.StartVertex].Distance + edges.Weight;
                if (distance < vertexList[edges.EndVertex].Distance)
                {
                    vertexList[edges.EndVertex].Distance = distance;
                    vertexList[edges.EndVertex].Previous = vertexList[edges.StartVertex];
                }
            }
        }

        foreach (var edges in graph.GetEdges())
        {
            if (vertexList[edges.StartVertex].Distance + edges.Weight < vertexList[edges.EndVertex].Distance)
            {
                throw new ArgumentException("Graph has negative cycle");
            }
        }

        var path = new List<Edge>();
        var currentVertex = vertexList[endVertex];
        while (currentVertex.Previous != null)
        {
            path.Insert(0,
                new Edge(currentVertex.Previous.Id, currentVertex.Id,
                    currentVertex.Distance - currentVertex.Previous.Distance));
            currentVertex = currentVertex.Previous;
        }
        return path;
    }
}