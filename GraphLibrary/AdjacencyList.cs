using System.Collections.Generic;
using System.Security.Cryptography;
namespace GraphLibrary;

public class AdjacencyList: IGraphRepresentation
{
    public LinkedList<Node> ListNodes = new LinkedList<Node>();
    
    public void AddVertex(int v)
    {
        throw new System.NotImplementedException();
    }

    public void AddEdge(int v1, int v2)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveEdge(int v1, int v2)
    {
        throw new System.NotImplementedException();
    }

    public bool HasEdge(int v1, int v2)
    {
        throw new System.NotImplementedException();
    }

    public void PrintGraph()
    {
        throw new System.NotImplementedException();
    }
}