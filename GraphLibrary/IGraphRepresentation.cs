namespace GraphLibrary;

public interface IGraphRepresentation
{
    public void AddVertex(int v);
    public void AddEdge(int v1, int v2);
    public void RemoveEdge(int v1, int v2);
    public bool HasEdge(int v1, int v2);
    public void PrintGraph();
}