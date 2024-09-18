using System;
using System.Collections.Generic;
using GraphLibrary.Utils;

namespace GraphLibrary.GraphRepresentation;

public class AdjacencyMatrix : IGraphRepresentation
{
    private readonly List<List<List<Edge>>> _matrix = [];
    private int _verticesCount;

    /// <inheritdoc />
    public Vertex AddVertex()
    {
        _verticesCount += 1;
        foreach (var row in _matrix) row.Add(new List<Edge>(_verticesCount));

        var newVertex = new List<List<Edge>>(_verticesCount);
        for (var i = 0; i < _verticesCount; i += 1) newVertex.Add(new List<Edge>(_verticesCount));

        _matrix.Add(newVertex);
        return new Vertex(_verticesCount - 1);
    }

    /// <inheritdoc />
    public void RemoveVertex(int vertex)
    {
        _vertexExists(vertex);
        _matrix.RemoveAt(vertex);
        foreach (var row in _matrix) row.RemoveAt(vertex);

        foreach (var row in _matrix)
        foreach (var col in row.ToArray())
        foreach (var edge in col.ToArray())
            if (edge.StartVertex == vertex || edge.EndVertex == vertex)
                col.Remove(edge);

        _verticesCount -= 1;
    }

    /// <inheritdoc />
    public void AddEdge(int startVertex, int endVertex, int weight = 1, bool directed = false)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);
        _matrix[startVertex][endVertex].Add(new Edge(startVertex, endVertex, weight));
        if (!directed) _matrix[endVertex][startVertex].Add(new Edge(endVertex, startVertex, weight));
    }

    /// <inheritdoc />
    public void RemoveEdge(int startVertex, int endVertex, bool directed = false)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);
        var matrix = new List<Edge>(_matrix[startVertex][endVertex]) ;
        foreach (var edge in matrix)
            if (edge.EndVertex == endVertex && edge.StartVertex == startVertex)
                _matrix[startVertex][endVertex].Remove(edge);

        if (directed) return;
        RemoveEdge(endVertex, startVertex, true);
    }

    /// <inheritdoc />
    public bool HasEdge(int startVertex, int endVertex)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);
        return _matrix[startVertex][endVertex].Count > 0;
    }

    /// <inheritdoc />
    public List<Vertex> GetVertices()
    {
        var vertices = new List<Vertex>();
        for (var i = 0; i < _verticesCount; i += 1) vertices.Add(new Vertex(i));

        return vertices;
    }

    /// <inheritdoc />
    public List<Edge> GetVertexEdges(int vertex)
    {
        _vertexExists(vertex);
        return _matrix[vertex][vertex];
    }

    /// <inheritdoc />
    public List<Edge> GetEdges()
    {
        var edges = new List<Edge>();
        foreach (var row in _matrix)
        foreach (var col in row)
        foreach (var edge in col)
            edges.Add(edge);

        return edges;
    }

    /// <inheritdoc />
    public List<Edge> GetVerticesEdges(int startVertex, int endVertex)
    {
        _vertexExists(startVertex);
        _vertexExists(endVertex);
        return _matrix[startVertex][endVertex];
    }

    private bool _vertexExists(int vertex)
    {
        if (vertex < 0 || vertex > _verticesCount)
            throw new ArgumentOutOfRangeException(nameof(vertex), $"Vertex is out of range ({_verticesCount})");
        return true;
    }
}