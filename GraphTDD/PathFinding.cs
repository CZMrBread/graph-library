using GraphLibrary;
using GraphLibrary.PathFinding;

namespace GraphTDD;

public class PathFinding
{
    [Fact]
    public void Dijkstra()
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
        var path = graph.PathFinding(0, 4, GraphLibrary.PathFinding.PathFinding.DijkstraPathFinding);
        int length = 0;
        foreach (var edge in path)
        {
            length += edge.Weight;
        }
        Assert.Equal(5, length);
    }
}