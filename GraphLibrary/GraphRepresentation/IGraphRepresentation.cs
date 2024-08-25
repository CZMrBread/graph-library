using System.Collections.Generic;
using GraphLibrary.Utils;

namespace GraphLibrary.GraphRepresentation;

public interface IGraphRepresentation
{
    public void AddVertex();
    public void RemoveVertex(int vertex);
    public void AddEdge(int startVertex, int endVertex, int weight = 1, bool directed = false);
    public void RemoveEdge(int startVertex, int endVertex, bool directed = false);
    public bool HasEdge(int startVertex, int endVertex);
    public List<int> GetVertices();
    public List<Edge> GetVertexEdges(int vertex);
    public List<Edge> GetEdges();
    public List<Edge> GetVerticesEdges(int startVertex, int endVertex);
    public void PrintGraph();
}