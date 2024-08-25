using System;
using System.Collections.Generic;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.Utils;

namespace GraphLibrary;

public class Graph()
{
    private IGraphRepresentation _graphRepresentation = new AdjacencyList();
    public Graph(IGraphRepresentation graphRepresentation) : this()
    {
        _graphRepresentation = graphRepresentation;
    }
    public void AddVertex()
    {
        _graphRepresentation.AddVertex();
    }
    public void AddEdge(int startVertex, int endVertex, int weight = 1, bool directed = false)
    {
        _graphRepresentation.AddEdge(startVertex, endVertex, weight, directed);
    }
    public void RemoveEdge(int startVertex, int endVertex, bool directed = false)
    {
        _graphRepresentation.RemoveEdge(startVertex, endVertex, directed);
    }
    public bool HasEdge(int startVertex, int endVertex)
    {
        return _graphRepresentation.HasEdge(startVertex, endVertex);
    }
    public List<Edge> GetVerticesEdges(int startVertex, int endVertex)
    {
        return _graphRepresentation.GetVerticesEdges(startVertex, endVertex);
    }
    
    public List<Edge> PathFinding(int startVertex, int endVertex, Func<IGraphRepresentation, int, int , List<Edge>> algorithm)
    {
        return algorithm.Invoke(_graphRepresentation, startVertex, endVertex);
    }
    
    
    
    
    
}