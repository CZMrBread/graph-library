using GraphLibrary;
using GraphLibrary.GraphRepresentation;
using GraphLibrary.PathFinding;
using GraphLibrary.SpanningTree;
using GraphLibrary.Utils;

namespace GraphTDD;

public class SpanningTreeTests
{
    [Fact]
    public void Jarnik()
    {
        var graph = new Graph();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddEdge(0, 1, 1, true);
        graph.AddEdge(0, 2, 1, true);
        graph.AddEdge(0, 3, 3, true);
        graph.AddEdge(1, 3, 3, true);
        graph.AddEdge(1, 4, 10, true);
        graph.AddEdge(2, 3, 3, true);
        graph.AddEdge(3, 4, 2, true);
        var path = graph.SpanningTree(0, SpanningTree.JarnikSpanningTree);
        int length = 0;
        foreach (var edge in path)
        {
            length += edge.Weight;
        }
        Assert.Equal(7, length);
    }   
}