using Library.Common;
using Library.Search;
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of cities:");
            var numCities = Convert.ToInt32(Console.ReadLine());
            var cityGraph = new CityGraph(numCities, false);

            // Print connections
            cityGraph.AdjacencyList.ShowKeyValuePairs("City","Connections");

            // Random two cities
            var city1 = new Random().Next(0, numCities);
            var city2 = new Random().Next(0, numCities);

            // Find quickest path between two cities
            var quickestPath = cityGraph.QuickestPath(city1, city2);

            // Print quickest path
            Console.WriteLine($"Shortest Path from City {city1} to City {city2}: " +
                $"[{String.Join(", ", quickestPath.ToArray())}]");
        }
    }
}