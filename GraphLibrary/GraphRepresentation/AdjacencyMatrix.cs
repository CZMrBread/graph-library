using System.Collections.Generic;
using GraphLibrary.Utils;

namespace GraphLibrary.GraphRepresentation;

public class AdjacencyMatrix: IGraphRepresentation
{
    private List<List<List<Edge?>>> _matrix = [];

    public void AddVertex()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveVertex(int vertex)
    {
        throw new System.NotImplementedException();
    }

    public void AddEdge(int startVertex, int endVertex, int weight = 1, bool directed = false)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveEdge(int startVertex, int endVertex, bool directed = false)
    {
        throw new System.NotImplementedException();
    }

    public bool HasEdge(int startVertex, int endVertex)
    {
        throw new System.NotImplementedException();
    }

    public List<int> GetVertices()
    {
        throw new System.NotImplementedException();
    }

    public List<Edge> GetVertexEdges(int vertex)
    {
        throw new System.NotImplementedException();
    }

    public List<Edge> GetEdges()
    {
        throw new System.NotImplementedException();
    }

    public List<Edge> GetVerticesEdges(int startVertex, int endVertex)
    {
        throw new System.NotImplementedException();
    }

    public void PrintGraph()
    {
        throw new System.NotImplementedException();
    }
}

