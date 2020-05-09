namespace Interview
{
    using System;

    public static class Program
    {

        static readonly AirMap controller = new AirMap();

        static void Main(string[] args)
        {

            var routes = new (string, string)[]
            {
                ("a", "b"),
                ("b", "a"),
                ("a", "c"),
                ("c", "a"),
                ("a", "d"),
                ("d", "a"),
                ("b", "c"),
                ("c", "b"),
                ("b", "d"),
                ("d", "b")
            };

            foreach (var (from, to) in routes)
                controller.AddRoute(from, to);

            ProcessCommands();

        }

        public static void ProcessCommands()
        {
            var done = false;
            do
            {
                Console.Write("\nAdd/Query/Print? [A,Q,P] (escape to exit) ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        done = true;
                        break;

                    case ConsoleKey.P:
                        controller.PrintDirectDestinations();
                        break;

                    case ConsoleKey.A:
                        AddRoute();
                        break;

                    case ConsoleKey.Q:
                        Query();
                        break;

                }
                Console.Write("\n");

            } while (!done);
        }

        public static void AddRoute()
        {
            Console.Write("\nOrigin     : ");
            var from = Console.ReadLine();

            Console.Write("Destination: ");
            var destination = Console.ReadLine();

            controller.AddRoute(from, destination);
        }

        public static void Query()
        {
            Console.Write("\nOrigin     : ");
            var from = Console.ReadLine();

            Console.Write("Destination: ");
            var destination = Console.ReadLine();

            controller.PrintRoutes(from, destination);
        }
    }
}