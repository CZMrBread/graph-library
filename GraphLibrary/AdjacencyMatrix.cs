using System;
namespace GraphLibrary;

public class AdjacencyMatrix: IGraphRepresentation
{
    private Node?[,] matrix;
    
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
        foreach (var row  in matrix)
        {
            Console.WriteLine(row);
        }
    }
}

