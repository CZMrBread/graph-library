using GraphLibrary;
using GraphLibrary.PathFinding;

namespace GraphTDD;

public class PathFindingTests
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
        var path = graph.PathFinding(0, 4, PathFinding.DijkstraPathFinding);
        int length = 0;
        foreach (var edge in path)
        {
            length += edge.Weight;
        }
        Assert.Equal(5, length);
    }   
    
    [Fact]
    public void DijkstraNegativeEdge()
    {
        var graph = new Graph();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddEdge(0, 1, -1, true);
        Assert.Throws<ArgumentException>(() => graph.PathFinding(0, 1, PathFinding.DijkstraPathFinding));
    }
    
    [Fact]
    public void BellmanFord()
    {
        var graph = new Graph();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddEdge(0, 1, 1, true);
        graph.AddEdge(0, 2, 1, true);
        graph.AddEdge(0, 3, -1, true);
        graph.AddEdge(1, 3, 3, true);
        graph.AddEdge(1, 4, 10, true);
        graph.AddEdge(2, 3, 3, true);
        graph.AddEdge(3, 4, 2, true);
        var path = graph.PathFinding(0, 4, PathFinding.BellmanFordPathFinding);
        int length = 0;
        foreach (var edge in path)
        {
            length += edge.Weight;
        }
        Assert.Equal(1, length);
    }  
    [Fact]
    public void BellmanFordNegativeCycle()
    {
        var graph = new Graph();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddEdge(0, 1, -1);
        graph.AddEdge(1, 2, 1);
        graph.AddEdge(2, 0, 1);
        var path = graph.PathFinding(0, 2, PathFinding.BellmanFordPathFinding);
        
    }   
}