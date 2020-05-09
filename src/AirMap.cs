namespace Interview
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AirMap
    {
        private readonly Dictionary<string, List<string>> routes = new Dictionary<string, List<string>>();

        /// <summary>
        /// add a direct connection between two Airports
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        public void AddRoute(string start, string end)
        {
            if (routes.ContainsKey(start))
            {
                if (routes[start].Contains(end))
                    Console.WriteLine("Route Already Configured");
                else
                    routes[start].Add(end);
            }
            else
                routes.Add(start, new List<string>() { end });
        }

        /// <summary>
        /// Prints all the routes found between two Airports
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        public void PrintRoutes(string start, string end)
        {
            Console.WriteLine($"From {start} to {end}");

            var routes = FindRoutes(start, end);
            
            if (routes.Count == 0)
                Console.WriteLine("No Routes found");

            foreach (var route in routes.OrderBy(r => r.Count))
                Console.WriteLine(string.Join(',', route));
        }


        /// <summary>
        /// Find all the possible routes between two Airports
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="visited">used internally by the function to keep track of where we have visited</param>
        /// <returns></returns>
        private List<LinkedList<string>> FindRoutes(string start, string end, HashSet<string> visited = null)
        {
            var foundRoutes = new List<LinkedList<string>>();

            if (!routes.ContainsKey(start))
                return foundRoutes;

            foreach (var hop in routes[start])
            {
                var currVisited = visited ?? new HashSet<string> { start };

                if (hop == end)
                {
                    foundRoutes.Add(new LinkedList<string>(new[] { hop }));
                }
                else
                {
                    if (currVisited.Contains(hop))
                        continue;

                    currVisited.Add(hop);

                    var routes = FindRoutes(hop, end, currVisited);

                    if (routes.Count > 0)
                        foundRoutes.AddRange(routes);
                }
            }

            foreach (var solution in foundRoutes)
                solution.AddFirst(start);

            return foundRoutes;
        }

        /// <summary>
        /// Prints a list of the airports with their direct destinations
        /// </summary>
        public void PrintDirectDestinations()
        {
            Console.WriteLine("\nAirport: [Direct Destinations]");
            foreach (var route in routes)
            {
                Console.WriteLine($"{route.Key}: [{string.Join(',', route.Value)}]");
            }
        }
    }
}