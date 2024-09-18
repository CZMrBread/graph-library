using GraphLibrary.GraphRepresentation;

namespace GraphTDD;

public class AdjacencyListTest
{
    [Fact]
    public void ListHasEdge()
    {
        var adjacencyList = new AdjacencyList();
        adjacencyList.AddVertex();
        adjacencyList.AddVertex();
        adjacencyList.AddEdge(0, 1);
        Assert.True(adjacencyList.HasEdge(0, 1));
    }

    [Fact]
    public void ListHasNotEdge()
    {
        var adjacencyList = new AdjacencyList();
        adjacencyList.AddVertex();
        adjacencyList.AddVertex();
        Assert.False(adjacencyList.HasEdge(0, 1));
    }

    [Fact]
    public void ListRemoveVertex()
    {
        var adjacencyList1 = new AdjacencyList();
        adjacencyList1.AddVertex();
        adjacencyList1.AddVertex();
        adjacencyList1.AddEdge(0, 1);
        adjacencyList1.RemoveVertex(1);
        var adjacencyList2 = new AdjacencyList();
        adjacencyList2.AddVertex();
        Assert.Equal(adjacencyList1.GetVertices().Count, adjacencyList2.GetVertices().Count);
    }

    [Fact]
    public void VertexDoesNotExist()
    {
        var adjacencyList = new AdjacencyList();
        Assert.Throws<ArgumentOutOfRangeException>(() => adjacencyList.RemoveVertex(0));
    }
}