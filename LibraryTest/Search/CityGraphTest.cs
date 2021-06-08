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
    public class CityGraphTest
    {
        [TestMethod]
        public void CityGraph_QuickestPathWithSameRandom_ShouldWork()
        {
            // Arrange
            var city1 = 1;
            var city2 = 19;
            var cityGraph = new CityGraph(100, true);
            // Act
            var path = cityGraph.QuickestPath(city1, city2);
            // Assert
            string result = new StringBuilder(string.Join(", ", path)).ToString();
            Assert.AreEqual("1, 0, 17, 19", result);
        }

        [TestMethod]
        public void CityGraph_AddNode_ShouldWork()
        {
            // Arrange
            var cityGraph = new CityGraph();
            // Act
            cityGraph.AddNode(0);
            // Assert
            Assert.AreEqual(1, cityGraph.AdjacencyList.Count);
        }


        [TestMethod]
        public void CityGraph_PopulateCities_ShouldWork()
        {
            // Arrange
            var cityGraph = new CityGraph(4, true);
            // Act
            cityGraph.PopulateCities();
            // Assert
            Assert.AreEqual(4, cityGraph.AdjacencyList.Count);
        }
    }
}
