using System;
using System.Reflection.Emit;

namespace GraphLibrary.Utils;

public class Vertex(int id)
{
    public int Id = id;
    public int Distance = int.MaxValue;
    public bool Visited = false;
    public Vertex? Previous = null;
    
}