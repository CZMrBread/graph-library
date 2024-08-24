using System;

namespace GraphLibrary;

public class Node(int id, string name, int weight=1): IComparable
{
    public string Name = name;
    public int Weight = weight;
    public readonly int Id = id;
    
    public int CompareTo(object? obj)
    {
        if (obj == null) 
            return 1;
        if (obj is not Node otherNode)
            throw new ArgumentException("Object is not a Temperature");
        if (this.Weight > otherNode.Weight)
            return 1;
        if (this.Weight > otherNode.Weight)
            return -1;
        if (this.Id > otherNode.Id)
            return 1;
        if (this.Id < otherNode.Id)
            return -1;
        return 0;
    }
}