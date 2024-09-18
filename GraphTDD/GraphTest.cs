using GraphLibrary;

namespace GraphTDD;

public class GraphTest
{
    [Fact]
    public void AddVertex()
    {
        var graph = new Graph();
        graph.AddVertex();
        Assert.Single(graph.GetVertices());
    }

    [Fact]
    public void AddEdge()
    {
        var graph = new Graph();
        graph.AddVertex();
        graph.AddVertex();
        graph.AddEdge(0, 1, 1, true);
        Assert.True(graph.HasEdge(0, 1));
    }

    [Fact]
    public void RemoveVertex()
    {
        var graph1 = new Graph();
        graph1.AddVertex();
        graph1.AddVertex();
        graph1.AddEdge(0, 1, 1, true);
        graph1.RemoveVertex(1);
        var graph2 = new Graph();
        graph2.AddVertex();
        Assert.Equal(graph1.GetVertices().Count, graph2.GetVertices().Count);
    }

    [Fact]
    public void VertexDoesNotExist()
    {
        var graph = new Graph();
        Assert.Throws<ArgumentOutOfRangeException>(() => graph.RemoveVertex(0));
    }  
}