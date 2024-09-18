using System;
using System.Collections.Generic;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.Utils;

namespace GraphLibrary;

public class Graph
{
    private IGraphRepresentation _graphRepresentation = new AdjacencyList();

    /// <summary>
    ///     Sets the graph representation. Erases the previous one.
    /// </summary>
    /// <param name="graphRepresentation">Type of graph representation in memory</param>
    public void GraphRepresentation(IGraphRepresentation graphRepresentation)
    {
        _graphRepresentation = graphRepresentation;
    }


    /// <inheritdoc cref="IGraphRepresentation.AddVertex" />
    public Vertex AddVertex()
    {
        return _graphRepresentation.AddVertex();
    }

    /// <inheritdoc cref="IGraphRepresentation.AddEdge" />
    public void AddEdge(int startVertex, int endVertex, int weight = 1, bool directed = false)
    {
        _graphRepresentation.AddEdge(startVertex, endVertex, weight, directed);
    }

    /// <inheritdoc cref="IGraphRepresentation.RemoveEdge" />
    public void RemoveEdge(int startVertex, int endVertex, bool directed = false)
    {
        _graphRepresentation.RemoveEdge(startVertex, endVertex, directed);
    }

    /// <inheritdoc cref="IGraphRepresentation.HasEdge" />
    public bool HasEdge(int startVertex, int endVertex)
    {
        return _graphRepresentation.HasEdge(startVertex, endVertex);
    }

    /// <inheritdoc cref="IGraphRepresentation.GetVerticesEdges" />
    public List<Edge> GetVerticesEdges(int startVertex, int endVertex)
    {
        return _graphRepresentation.GetVerticesEdges(startVertex, endVertex);
    }

    /// <inheritdoc cref="IGraphRepresentation.GetVertices" />
    public List<Vertex> GetVertices()
    {
        return _graphRepresentation.GetVertices();
    }

    /// <summary>
    ///     Path finding in a graph.
    /// </summary>
    /// <param name="startVertex">ID of vertex to start from</param>
    /// <param name="endVertex">ID of destination vertex</param>
    /// <param name="algorithm">Path finding algorithm from <see cref="GraphLibrary.PathFinding.PathFinding" /></param>
    /// <returns>The path as a list of edges</returns>
    /// <example>
    ///     <code>
    /// using GraphLibrary.PathFinding;
    /// Graph.athFinding(0, 5, PathFinding.DijkstraPathFinding);
    /// </code>
    /// </example>
    public List<Edge> PathFinding(int startVertex, int endVertex,
        Func<IGraphRepresentation, int, int, List<Edge>> algorithm)
    {
        return algorithm.Invoke(_graphRepresentation, startVertex, endVertex);
    }

    /// <summary>
    ///     Spanning tree in a graph.
    /// </summary>
    /// <param name="root">ID of root vertex</param>
    /// <param name="algorithm">SpanningTree algorithm from <see cref="GraphLibrary.SpanningTree.SpanningTree" /></param>
    /// <returns>Spanning tree as list of edges</returns>
    /// <example>
    ///     <code>
    /// using GraphLibrary.SpanningTree;
    /// Graph.SpanningTree(0, SpanningTree.JarnikSpanningTree);
    /// </code>
    /// </example>
    public List<Edge> SpanningTree(int root, Func<IGraphRepresentation, int, List<Edge>> algorithm)
    {
        return algorithm.Invoke(_graphRepresentation, root);
    }
}