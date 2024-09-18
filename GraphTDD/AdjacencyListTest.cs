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
    public void ListRemoveEdge()
    {
        var adjacencyList1 = new AdjacencyList();
        var list1Vertex1 = adjacencyList1.AddVertex();
        var list1Vertex2 = adjacencyList1.AddVertex();
        var list1Vertex3 = adjacencyList1.AddVertex();
        adjacencyList1.AddEdge(list1Vertex1.Id, list1Vertex2.Id);
        adjacencyList1.AddEdge(list1Vertex2.Id, list1Vertex3.Id);
        adjacencyList1.RemoveEdge(list1Vertex1.Id, list1Vertex2.Id);

        var adjacencyList2 = new AdjacencyList();
        var list2Vertex1 = adjacencyList2.AddVertex();
        var list2Vertex2 = adjacencyList2.AddVertex();
        var list2Vertex3 = adjacencyList2.AddVertex();
        adjacencyList2.AddEdge(list2Vertex2.Id, list2Vertex3.Id);

        Assert.Equal(adjacencyList1.GetEdges().Count, adjacencyList2.GetEdges().Count);
    }
    [Fact]
    public void VertexDoesNotExist()
    {
        var adjacencyList = new AdjacencyList();
        Assert.Throws<ArgumentOutOfRangeException>(() => adjacencyList.RemoveVertex(0));
    }
}