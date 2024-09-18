using System;
using System.Collections.Generic;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.Utils;

namespace GraphLibrary.PathFinding;

/// <summary>
///     Provides methods for finding the shortest path in a graph.
/// </summary>
public static class PathFinding
{
    /// <summary>
    ///     Implementation of Dijkstra's algorithm for finding the shortest path in a graph.
    /// </summary>
    /// <param name="graph">Graph representation</param>
    /// <param name="startVertex">ID of start <see cref="Vertex" /></param>
    /// <param name="endVertex">ID of destination <see cref="Vertex" /></param>
    /// <returns>Shortest path as list of <see cref="Edge" />s</returns>
    /// <exception cref="ArgumentException">Throws when graph contains negative edge</exception>
    public static List<Edge> DijkstraPathFinding(IGraphRepresentation graph, int startVertex, int endVertex)
    {
        if (Utils.Utils.HasGraphNegativeEdge(graph))
            throw new ArgumentException("Graph has negative edge, try different algorithm");

        var vertexQueue = new PriorityQueue<Vertex, int>();
        var vertexList = new List<Vertex>();
        foreach (var vertex in graph.GetVertices())
        {
            if (vertex.Id == startVertex) vertex.Distance = 0;

            vertexList.Insert(vertex.Id, vertex);
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

    /// <summary>
    ///     Implementation of Bellman-Ford algorithm for finding the shortest path in a graph.
    /// </summary>
    /// <param name="graph">Graph representation</param>
    /// <param name="startVertex">ID of start <see cref="Vertex" /></param>
    /// <param name="endVertex">ID of destination <see cref="Vertex" /></param>
    /// <returns>Shortest path as list of <see cref="Edge" />s</returns>
    /// <exception cref="ArgumentException">Throws when graph contains negative cycle</exception>
    public static List<Edge> BellmanFordPathFinding(IGraphRepresentation graph, int startVertex, int endVertex)
    {
        var vertexList = new List<Vertex>();
        foreach (var vertex in graph.GetVertices())
        {
            if (vertex.Id == startVertex)
            {
                vertex.Visited = true;
                vertex.Distance = 0;
            }

            vertexList.Insert(vertex.Id, vertex);
        }

        for (var i = 0; i < graph.GetVertices().Count - 1; i += 1)
            foreach (var edges in graph.GetEdges())
            {
                var distance = vertexList[edges.StartVertex].Distance + edges.Weight;
                if (distance < vertexList[edges.EndVertex].Distance)
                {
                    vertexList[edges.EndVertex].Distance = distance;
                    vertexList[edges.EndVertex].Previous = vertexList[edges.StartVertex];
                }
            }

        foreach (var edges in graph.GetEdges())
            if (vertexList[edges.StartVertex].Distance + edges.Weight < vertexList[edges.EndVertex].Distance)
                throw new ArgumentException("Graph has negative cycle");

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