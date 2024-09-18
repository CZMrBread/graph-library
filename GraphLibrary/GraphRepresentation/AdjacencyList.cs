using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Utils;

namespace GraphLibrary.GraphRepresentation;

/// <summary>
///     Represents a graph as an adjacency list.
/// </summary>
public class AdjacencyList : IGraphRepresentation
{
    private readonly List<LinkedList<Edge>> _verteciesList = [];

    /// <inheritdoc />
    public Vertex AddVertex()
    {
        _verteciesList.Add(new LinkedList<Edge>());
        return new Vertex(_verteciesList.Count - 1);
    }

    /// <inheritdoc />
    public void RemoveVertex(int vertex)
    {
        _vertexExists(vertex);
        _verteciesList.RemoveAt(vertex);
        foreach (var list in _verteciesList)
        foreach (var edge in list.ToArray())
            if (edge.StartVertex == vertex || edge.EndVertex == vertex)
                list.Remove(edge);
    }

    /// <inheritdoc />
    public void AddEdge(int startVertex, int endVertex, int weight = 1, bool directed = false)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);

        _vertexEdges(startVertex).AddLast(new Edge(startVertex, endVertex, weight));
        if (!directed)
            _vertexEdges(endVertex).AddLast(new Edge(endVertex, startVertex, weight));
    }

    /// <inheritdoc />
    public void RemoveEdge(int startVertex, int endVertex, bool directed = false)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);

        foreach (var edge in _vertexEdges(startVertex))
        {
            if (edge.EndVertex != endVertex)
                continue;
            _verteciesList[startVertex].Remove(edge);
        }

        if (directed) return;
        RemoveEdge(endVertex, startVertex, true);
    }

    /// <inheritdoc />
    public bool HasEdge(int startVertex, int endVertex)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);
        foreach (var edge in _vertexEdges(startVertex))
            if (edge.EndVertex == endVertex)
                return true;

        return false;
    }

    /// <inheritdoc />
    public List<Edge> GetVertexEdges(int vertex)
    {
        _vertexExists(vertex);
        return _verteciesList[vertex].ToList();
    }

    /// <inheritdoc />
    public List<Vertex> GetVertices()
    {
        var vertices = new List<Vertex>();
        for (var i = 0; i < _verteciesList.Count; i++) vertices.Add(new Vertex(i));

        return vertices;
    }

    /// <inheritdoc />
    public List<Edge> GetEdges()
    {
        var edges = new List<Edge>();
        foreach (var list in _verteciesList)
        foreach (var edge in list)
            edges.Add(edge);

        return edges;
    }

    /// <inheritdoc />
    public List<Edge> GetVerticesEdges(int startVertex, int endVertex)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);
        var edges = new List<Edge>();
        foreach (var edge in _vertexEdges(startVertex))
            if (edge.EndVertex == endVertex)
                edges.Add(edge);

        return edges;
    }


    private bool _vertexExists(int vertex)
    {
        if (vertex < 0 || vertex > _verteciesList.Count)
            throw new ArgumentOutOfRangeException(nameof(vertex), $"Vertex is out of range ({_verteciesList.Count})");
        return true;
    }

    private LinkedList<Edge> _vertexEdges(int vertex)
    {
        _vertexExists(vertex);
        return _verteciesList[vertex];
    }
}