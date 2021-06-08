using Library.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Search
{
    [TestClass]
    public class GraphTest
    {
        private readonly int[] nodes = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private readonly Tuple<int, int>[] edges = new[]{Tuple.Create(1,0),
                Tuple.Create(2,1), Tuple.Create(2,0),
                Tuple.Create(3,2), Tuple.Create(3,1),
                Tuple.Create(4,3), Tuple.Create(4,1),
                Tuple.Create(5,4), Tuple.Create(5,0),
                Tuple.Create(6,5), Tuple.Create(6,0),
                Tuple.Create(7,6), Tuple.Create(7,5),
                Tuple.Create(8,7), Tuple.Create(8,4)};

        [TestMethod]
        public void Graph_QuickestPath_ShouldWork()
        {
            // Arrange
            var node1 = 1;
            var node2 = 6;
            var graph = new Graph<int>(nodes, edges);
            // Act
            var path = graph.QuickestPath(node1, node2);
            // Assert
            string result = new StringBuilder(string.Join(", ", path)).ToString();
            Assert.AreEqual("1, 0, 6", result);
        }

        [TestMethod]
        public void Graph_QuickestPathWithFourNodes_ShouldWork()
        {
            int[] nodes = new[] { 0, 1, 2, 3 };
            Tuple<int, int>[] edges = new[]{Tuple.Create(1,0),
                Tuple.Create(2,1), Tuple.Create(2,0),
                Tuple.Create(3,2), Tuple.Create(3,0)};

            // Arrange
            var node1 = 3;
            var node2 = 1;
            var graph = new Graph<int>(nodes, edges);
            // Act
            var path = graph.QuickestPath(node1, node2);
            // Assert
            string result = new StringBuilder(string.Join(", ", path)).ToString();
            Assert.AreEqual("3, 2, 1", result);
        }

        [TestMethod]
        public void Graph_AddNode_ShouldWork()
        {
            // Arrange
            var node0 = 0;
            var node1 = 1;
            var graph = new Graph<int>();
            // Act
            graph.AddNode(node0);
            graph.AddNode(node1);
            // Assert
            Assert.AreEqual(2, graph.AdjacencyList.Count);
        }

        [TestMethod]
        public void Graph_AddEdge_ShouldWork()
        {
            // Arrange
            var graph = new Graph<int>();
            int[] nodes = new[] { 0, 1, 2 };
            Tuple<int, int>[] edges = new[] { Tuple.Create(1, 0), Tuple.Create(2, 1)};            
            foreach (var node in nodes) graph.AddNode(node);
            // Act            
            foreach (var edge in edges) graph.AddEdge(edge);
            // Assert
            Assert.AreEqual(1, graph.AdjacencyList[0].First());
            Assert.AreEqual(0, graph.AdjacencyList[1].First());
            Assert.AreEqual(2, graph.AdjacencyList[1].ElementAt(1));
            Assert.AreEqual(1, graph.AdjacencyList[2].First());
        }
    }
}
