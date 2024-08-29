# Graph library

## [1. Uživatelská část](#1-uživatelská-část)

### Použití knihovny
 **1.** Vytvoření grafu \
```csharp var graph = new Graph();``` \
výchozí reprezentace grafu je zvolena AdjacencyList \
toto lze změnit pokud inicializujeme graf takto \
```csharp var graph = new Graph(new AdjacencyMatrix());``` \
 **2.** Přidání vrcholů \
```csharp graph.AddVertex();``` \
metoda `AddVertex` automaticky čísluje vrcholy od 0 do N \
přidané hrany si můžeme zobrazit pomocí metody `GetVertices` \
 **3.** Přidání hran \
```csharp graph.AddEdge(start, end, weight=1, directed=false);``` \
ve východním stavu jsou hrany neorientované a bez vah resp. váha je nastavena na 1 \

## [2. Programátorská část](#2-programátorská-část)

### Struktura programu
- `Graph.cs`: hlavní soubor knihovny, interakce s grafem
- Utils
  - `Vertex.cs`: vrchol grafu
  - `Edge.cs`: hrana grafu
  - `Utils.cs`: pomocné metody
- SpanningTree
  - `SpanningTree.cs`: algoritmy pro nalezení kostry grafu
- ShortestPath
  - `ShortestPath.cs`: algoritmy pro nalezení nejkratší cesty v grafu
- GraphRepresentation
    - `IGraphRepresentation.cs`: Jednotné rozhraní pro reprezentaci grafu
    - `AdjacencyList.cs`: reprezentace grafu pomocí seznamu sousedů
    - `AdjacencyMatrix.cs`: reprezentace grafu pomocí matice sousednosti

## [3. Ukázky použití](#3-ukázky-použití)
- `AdjacencyListTest.cs`
- `AdjacencyMatrixTest.cs`
- `PathFindingTest.cs`
- `SpanningTreeTest.cs`