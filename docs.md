# Graph library

## [1. Uživatelská část](#1-uživatelská-část)

### Obecné použití

**1.** Vytvoření grafu \
```var graph = new Graph();``` \
výchozí reprezentace grafu je zvolena AdjacencyList \
toto lze změnit pokud inicializujeme graf takto \
```var graph = new Graph(new AdjacencyMatrix());``` \
**2.** Přidání vrcholů \
```graph.AddVertex();``` \
metoda `AddVertex` automaticky čísluje vrcholy od 0 do N \
přidané hrany si můžeme zobrazit pomocí metody `GetVertices` \
**3.** Přidání hran \
```graph.AddEdge(start, end, weight=1, directed=false);``` \
ve výchozím stavu jsou hrany neorientované a bez vah resp. váha je nastavena na 1 \
**4.** Odstranění vrcholu \
```graph.RemoveVertex(vertex);``` \
**5.** Odstranění hrany \
```graph.RemoveEdge(start, end);``` \
**6.** Seznam vrcholů \
```graph.GetVertices();``` \
**7.** Seznam hran \
```graph.GetEdges();``` \
**8.** Seznam hran mezi vrcholy \
```graph.GetVerticesEdges(start, end);```
### Nejkraší cesta v grafu

metoda `PathFinding` obsahuje 3 argumenty \

- `startVertex` - počáteční vrchol
- `endVertex` - koncový vrchol
- `algorithm` - algoritmus z třídy `PathFinding` \
  Příklad volání \
  ```var path = graph.PathFinding(start, end, PathFinding.DijkstraPathFinding;```

### Minimální kostra grafu

metoda `SpanningTree` obsahuje 2 argumenty \

- `startVertex` - počáteční vrchol
- `algorithm` - algoritmus z třídy `SpanningTree` \
  Příklad volání \
  ```var path = graph.SpanningTree(start, SpanningTree.JarnikSpanningTree);```

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

### Obecné použití

```csharp
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
```
```csharp
graph.RemoveVertex(4);
```
```csharp
graph.RemoveEdge(0, 1);
```
### Nejkraší cesta v grafu

```csharp
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

// Output [Edge(0, 3, 3), Edge(3, 4, 2)]
```

### Minimální kostra grafu

```csharp
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
var path = graph.SpanningTree(0, SpanningTree.JarnikSpanningTree);

// Output [Edge(0, 1, 1), Edge(0, 2, 1), Edge(0, 3, 3), Edge(3, 4, 2)]
```