using System;

namespace GraphLibrary.Utils;

public class Edge(int startVertex,int endVertex, int weight=1)
{
    public int Weight = weight;
    public readonly int StartVertex = startVertex;
    public readonly int EndVertex = endVertex;
}