using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Search
{
    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public Graph() { }

        public Graph(IEnumerable<T> nodes, IEnumerable<Tuple<T, T>> edges) : this()
        {
            foreach (var node in nodes)
            {
                AddNode(node);
            }

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public virtual void AddNode(T node)
        {
            AdjacencyList[node] = new HashSet<T>();
        }

        public virtual void AddEdge(Tuple<T, T> edge)
        {
            AdjacencyList[edge.Item1].Add(edge.Item2);
            AdjacencyList[edge.Item2].Add(edge.Item1);
        }

        public Stack<T> QuickestPath(T start, T end)
        {
            // breadth first search
            var path = new Dictionary<T, T>();
            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (!AdjacencyList.ContainsKey(node)) return null;

                foreach (var adjacent in AdjacencyList[node].Where(a => !path.ContainsKey(a)))
                {
                    path[adjacent] = node;
                    queue.Enqueue(adjacent);
                }
            }

            if (path.Count == 0) return null;

            //find quickest path
            var quickestPath = new Stack<T>();
            var temp = end;

            while (!temp.Equals(start))
            {
                quickestPath.Push(temp);
                if (!path.ContainsKey(temp))
                    return null;
                temp = path[temp];
            }

            quickestPath.Push(start);
            return quickestPath;
        }
    }
}
