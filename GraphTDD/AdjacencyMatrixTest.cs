using GraphLibrary.GraphRepresentation;

namespace GraphTDD;

public class AdjacencyMatrixTest
{
    [Fact]
    public void MatrixHasEdge()
    {
        var adjacencyMatrix = new AdjacencyMatrix();
        adjacencyMatrix.AddVertex();
        adjacencyMatrix.AddVertex();
        adjacencyMatrix.AddEdge(0, 1);
        Assert.True(adjacencyMatrix.HasEdge(0, 1));
    }

    [Fact]
    public void MatrixHasNotEdge()
    {
        var adjacencyMatrix = new AdjacencyMatrix();
        adjacencyMatrix.AddVertex();
        adjacencyMatrix.AddVertex();
        Assert.False(adjacencyMatrix.HasEdge(0, 1));
    }

    [Fact]
    public void MatrixRemoveVertex()
    {
        var adjacencyMatrix1 = new AdjacencyMatrix();
        adjacencyMatrix1.AddVertex();
        adjacencyMatrix1.AddVertex();
        adjacencyMatrix1.AddEdge(0, 1);
        adjacencyMatrix1.RemoveVertex(1);
        var adjacencyMatrix2 = new AdjacencyMatrix();
        adjacencyMatrix2.AddVertex();
        Assert.Equal(adjacencyMatrix1.GetVertices().Count, adjacencyMatrix2.GetVertices().Count);
    }

    [Fact]
    public void MatrixRemoveEdge()
    {
        var adjacencyMatrix1 = new AdjacencyMatrix();
        var matrix1Vertex1 = adjacencyMatrix1.AddVertex();
        var matrix1Vertex2 = adjacencyMatrix1.AddVertex();
        var matrix1Vertex3 = adjacencyMatrix1.AddVertex();
        adjacencyMatrix1.AddEdge(matrix1Vertex1.Id, matrix1Vertex2.Id);
        adjacencyMatrix1.AddEdge(matrix1Vertex2.Id, matrix1Vertex3.Id);
        adjacencyMatrix1.RemoveEdge(matrix1Vertex1.Id, matrix1Vertex2.Id);

        var adjacencyMatrix2 = new AdjacencyMatrix();
        var matrix2Vertex1 = adjacencyMatrix2.AddVertex();
        var matrix2Vertex2 = adjacencyMatrix2.AddVertex();
        var matrix2Vertex3 = adjacencyMatrix2.AddVertex();
        adjacencyMatrix2.AddEdge(matrix2Vertex2.Id, matrix2Vertex3.Id);

        Assert.Equal(adjacencyMatrix1.GetEdges().Count, adjacencyMatrix2.GetEdges().Count);
    }

    [Fact]
    public void VertexDoesNotExist()
    {
        var adjacencyMatrix = new AdjacencyMatrix();
        Assert.Throws<ArgumentOutOfRangeException>(() => adjacencyMatrix.RemoveVertex(0));
    }
}