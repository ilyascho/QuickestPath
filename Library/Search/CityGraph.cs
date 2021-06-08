using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Search
{
    public class CityGraph : Graph<int>
    {
        readonly int _numCities;
        readonly Random _random;

        public override void AddNode(int city)
        {
            base.AddNode(city);

            // connect with most recent city
            if (city > 0) AddEdge(new(city, city - 1));

            // connect with other random already built city
            if (city > 1) AddEdge(new(city, _random.Next(0, city - 1)));
        }

        public CityGraph() { }

        public CityGraph(int numCities, bool sameRandom)
        {
            _numCities = numCities;
            _random = sameRandom ? new Random(0) : new Random();
            
            PopulateCities();
        }

        public void PopulateCities()
        {
            for (int i = 0; i < _numCities; i++)
                AddNode(i);
        }
    }
}
