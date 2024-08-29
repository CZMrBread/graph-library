using GraphLibrary;
using GraphLibrary.GraphRepresentation;

namespace GraphTDD;

public class AdjacencyMatrixTest{
    [Fact]
    public void MatrixHasEdge()
    {
        var adjacencyMatrix = new AdjacencyMatrix();
        adjacencyMatrix.AddVertex();
        adjacencyMatrix.AddVertex();
        adjacencyMatrix.AddEdge(0,1);
        Assert.True(adjacencyMatrix.HasEdge(0,1));
    }

    [Fact]
    public void MatrixHasNotEdge()
    {
        var adjacencyMatrix = new AdjacencyMatrix();
        adjacencyMatrix.AddVertex();
        adjacencyMatrix.AddVertex();
        Assert.False(adjacencyMatrix.HasEdge(0,1));
    }

    [Fact]
    public void MatrixRemoveVertex()
    {
        var adjacencyMatrix1 = new AdjacencyMatrix();
        adjacencyMatrix1.AddVertex();
        adjacencyMatrix1.AddVertex();
        adjacencyMatrix1.AddEdge(0,1);
        adjacencyMatrix1.RemoveVertex(1);
        var adjacencyMatrix2 = new AdjacencyMatrix();
        adjacencyMatrix2.AddVertex();
        Assert.Equal(adjacencyMatrix1.GetVertices(), adjacencyMatrix2.GetVertices());
    }
    [Fact]
    public void VertexDoesNotExist()
    {
        var adjacencyMatrix = new AdjacencyMatrix();
        Assert.Throws<ArgumentOutOfRangeException>(() => adjacencyMatrix.RemoveVertex(0));
    }
}