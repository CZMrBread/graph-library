using System;
using System.Collections.Generic;
using GraphLibrary.Utils;

namespace GraphLibrary.GraphRepresentation;

public interface IGraphRepresentation
{
    /// <summary>
    ///     Add a vertex to the graph
    /// </summary>
    /// <returns>Added <see cref="Vertex" /></returns>
    public Vertex AddVertex();

    /// <summary>
    ///     Remove a vertex from the graph with all its edges
    /// </summary>
    /// <param name="vertex">ID of vertex to remove</param>
    /// <exception cref="ArgumentOutOfRangeException">Throws when <paramref name="vertex" /> does not exists in graph</exception>
    public void RemoveVertex(int vertex);

    /// <summary>
    ///     Create an <see cref="Edge" /> between <paramref name="startVertex" /> and <paramref name="endVertex" />.
    ///     <para>Optional parameters <paramref name="weight" /> and <paramref name="directed" /></para>
    /// </summary>
    /// <param name="startVertex">Edge start vertex</param>
    /// <param name="endVertex">Edge end vertex</param>
    /// <param name="weight">Weight of an edge default=1</param>
    /// <param name="directed">Directed edge default=False</param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Throws when <paramref name="startVertex" /> or
    ///     <paramref name="endVertex" /> does not exists in graph
    /// </exception>
    public void AddEdge(int startVertex, int endVertex, int weight = 1, bool directed = false);

    /// <summary>
    ///     Removes all edges between <paramref name="startVertex" /> and <paramref name="endVertex" />.
    ///     <para>
    ///         Optional <paramref name="directed" /> if True removes only in direction <paramref name="startVertex" /> to
    ///         <paramref name="endVertex" />
    ///     </para>
    /// </summary>
    /// <param name="startVertex">Edge start vertex</param>
    /// <param name="endVertex">Edge end vertex</param>
    /// <param name="directed">Directed edge default=False</param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Throws when <paramref name="startVertex" /> or
    ///     <paramref name="endVertex" /> does not exists in graph
    /// </exception>
    public void RemoveEdge(int startVertex, int endVertex, bool directed = false);

    /// <summary>
    ///     Returns True if there is an edge between <paramref name="startVertex" /> and <paramref name="endVertex" />
    /// </summary>
    /// <param name="startVertex">Edge start vertex</param>
    /// <param name="endVertex">Edge end vertex</param>
    /// <returns>True if edge exists</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Throws when <paramref name="startVertex" /> or
    ///     <paramref name="endVertex" /> does not exists in graph
    /// </exception>
    public bool HasEdge(int startVertex, int endVertex);

    /// <summary>
    ///     Returns ID's of all vertices in the graph in a List
    /// </summary>
    /// <returns>
    ///     List of <see cref="Vertex" />
    /// </returns>
    public List<Vertex> GetVertices();

    /// <summary>
    ///     Return all edges of a vertex
    /// </summary>
    /// <param name="vertex">ID of vertex</param>
    /// <returns>List of <see cref="Vertex" /> edges</returns>
    /// <exception cref="ArgumentOutOfRangeException">Throws when <paramref name="vertex" /> does not exists in graph</exception>
    public List<Edge> GetVertexEdges(int vertex);

    /// <summary>
    ///     Return all edges of the graph
    /// </summary>
    /// <returns>List of all <see cref="Edge" />s</returns>
    public List<Edge> GetEdges();

    /// <summary>
    ///     Return <see cref="Edge" />s that starts from <paramref name="startVertex" /> and ends at
    ///     <paramref name="endVertex" />
    /// </summary>
    /// <param name="startVertex">Edge start vertex</param>
    /// <param name="endVertex">Edge end vertex</param>
    /// <returns>List of <see cref="Edge" />s</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Throws when <paramref name="startVertex" /> or
    ///     <paramref name="endVertex" /> does not exists in graph
    /// </exception>
    public List<Edge> GetVerticesEdges(int startVertex, int endVertex);
}