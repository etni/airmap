using System;
using System.Collections.Generic;

namespace AirPort
{
    public class TrafficController
    {
        private readonly Dictionary<string,List<string>> routes = new Dictionary<string, List<string>>();

        /// <summary>
        /// add a direct connection between two Airports
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        public void AddRoute(string start, string destination)
        {
            if (routes.ContainsKey(start))
            {
                if (routes[start].Contains(destination))
                    Console.WriteLine("Route Already Configured");
                else
                    routes[start].Add(destination);
            }
            else
                routes.Add(start, new List<string>() { destination });
        }

        /// <summary>
        /// Prints all the routes found between two Airports
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        public void PrintRoutes(string start, string destination)
        {
            Console.WriteLine($"From {start} to {destination}");
            var result = FindRoutes(start, destination);
            if (result.Count == 0)
                Console.WriteLine("No Routes found");

            foreach(var route in result)
                Console.WriteLine(string.Join(',', route));
        }


        /// <summary>
        /// Find all the possible routes between two Airports
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <param name="visited">used internally by the function to keep track of where we have visited</param>
        /// <returns></returns>
        private List<LinkedList<string>> FindRoutes(string start, string destination, HashSet<string> visited = null)
        {
            var found = new List<LinkedList<string>>();

            if (!routes.ContainsKey(start)) return found;

            foreach (var item in routes[start])
            {

                var currVisited  =  visited ?? new HashSet<string> {start};

                if (item == destination)
                {
                    found.Add(new LinkedList<string>(new[] {item}));
                }
                else
                {
                    if (currVisited.Contains(item)) continue;

                    currVisited.Add(item);

                    var results = FindRoutes(item, destination,currVisited);

                    if (results.Count > 0)
                        found.AddRange(results);
                }
            }

            foreach (var solution in found)
                solution.AddFirst(start);

            return found;
        }

        /// <summary>
        /// Prints a list of the airports with their direct destinations
        /// </summary>
        public void PrintDirectDestinations()
        {
            Console.WriteLine("\nDirect Destinations");
            foreach (var route in routes)
            {
                Console.WriteLine($"{route.Key} [{string.Join(',', route.Value)}]");
            }
        }
    }
}