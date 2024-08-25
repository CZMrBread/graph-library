using System.Collections.Generic;
using GraphLibrary.Utils;

namespace GraphLibrary.GraphRepresentation;

public class AdjacencyMatrix
{
    private static int _numberOfVertices = 0;
    private KeyValuePair<int,KeyValuePair<int, Edge?>> _matrix = new KeyValuePair<int, KeyValuePair<int, Edge?>>();
    
    public void AddVertex(string name, int count=1)
    {
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
    }
}

