using System;
using System.Collections.Generic;
using System.Linq;

/* 
 * Everything seems to work correctly. Option 2 in OpsMenu()
 * is not yet implemented but is handled so will not crash the 
 * program if selected.
 */



namespace ReadNPoints
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("C-Vac's epic cartesian coordinate calculate vector euclidean distance ... application or something v4.20.69");
            Console.ReadKey(true);
            
            // Make master point list from inputs
            List<Point> pointList = new List<Point>();
            pointList = InputPoints(pointList, false);

            // Decide to add more items, start over, or continue to operations menu
            ListOptions(pointList);
        }

        static void FancyErrorMessage(SystemException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
        
        static char[] CharInputExceptionHandler()
        {
            char[] inputNames = new char[2];
            bool inputValid = false;
            
            try
            {
                inputNames = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                inputValid = true;
            }
            catch (SystemException e)
            {
                FancyErrorMessage(e);
            }

            while (!inputValid)
            {
                try
                {
                    inputNames = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                    inputValid = true;
                }
                catch (SystemException e)
                {
                    FancyErrorMessage(e);
                }
            }
            
            return inputNames;
        }

        static void Operations(List<Point> pointList)
        {
            List<Point> points = pointList;
            
            OpsMenu(points);
            
            static void OpsMenu(List<Point> points)
            {
                Console.Clear(); DisplayList(points);

                // Menu options
                Console.WriteLine( "\n{0}\n{1}\n{2}\n{3}",
                    "1: Calculate distance between two points",
                    "2: Calculate longest possible line between points",
                    "3: Calculate shortest possible line between points",
                    "4: Back to list menu" );
                switch (Console.ReadLine())
                {
                    case "1":
                        double[] distance = GetDistanceFromInput(points);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The distance between points {1} and {2} is: {0}",
                            distance[0], Convert.ToChar((int)distance[1]), Convert.ToChar((int)distance[2]) );
                        Console.ResetColor();
                        break;
                    case "2":

                        break;
                    case "3":
                        double[] shortest = GetShortestLine(points);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The shortest line segment is line {1}{2} and is {0} units long.",
                            shortest[0], Convert.ToChar((int)shortest[1]), Convert.ToChar((int)shortest[2]));
                        Console.ResetColor();
                        break;
                    case "4":
                        InputPoints(points, false);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nPress enter to continue"); Console.ReadKey(true);
                OpsMenu(points);
            }

            static double[] GetDistanceFromInput(List<Point> pointList)
            {
                Console.Clear(); DisplayList(pointList);
                Console.WriteLine("Enter line (A B) to calculate the distance of:");
                List<Point> points = pointList;
                Point left = new Point();
                Point right = new Point();
                char[] inputNames = CharInputExceptionHandler();
                bool inputValid = false;

                while (!inputValid) 
                {
                    try
                    {
                        foreach (Point point in points)
                        {
                            if (point.Name == inputNames[0])
                            {
                                left = point;
                            }
                            else if (point.Name == inputNames[1])
                            {
                                right = point;
                            }
                            if (left.Name != 'Z' && right.Name != 'Z')
                            {
                                break;
                            }
                        }
                        inputValid = true;
                        break;
                    }
                    catch (SystemException e)
                    {
                        FancyErrorMessage(e);
                    }
                    inputNames = CharInputExceptionHandler();
                }

                double[] results = { GetDistance(left, right), inputNames[0], inputNames[1] };
                return results;
            }

            static double GetDistance(Point leftP, Point rightP)
            {
                Point left = leftP;
                Point right = rightP;

                double results = Math.Sqrt(Math.Pow(left.X - right.X, 2) +
                    Math.Pow(left.Y - right.Y, 2));

                return results;
            }

            static double[] GetShortestLine(List<Point> pointList)
            {
                double[] shortestLine = { double.MaxValue, 0, 0 };
                List<Point> allPoints = pointList;

                for (int i = 0; i < allPoints.Count; i++)
                {
                    for (int j = 0; j < allPoints.Count; j++)
                    {
                        if (j == i) {} else
                        {
                            double distance = GetDistance(allPoints[i], allPoints[j]);

                            if (distance < shortestLine[0])
                            {
                                shortestLine[0] = distance;
                                shortestLine[1] = allPoints[i].Name;
                                shortestLine[2] = allPoints[j].Name;
                            }
                        }
                    }
                }

                return shortestLine;
            }

            static double[] GetLongestLine(List<Point> pointList)
            {
                return null;
            }
        }

        static void DisplayList(List<Point> pointList)
        {
            // Display master list of points
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Points in the list: {0}. \n", pointList.Count);
            Console.ResetColor();
            foreach (Point point in pointList)
            {
                Console.WriteLine("Point {0}: ({1}, {2})", point.Name, point.X, point.Y);
            }
        }

        static void ListOptions(List<Point> pointList)
        {
            Console.Clear(); DisplayList(pointList);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n1: Save list | 2: Add more points | 3: Remove a point | 4: Clear list | 5: Exit");
            Console.ResetColor();

            switch (Console.ReadLine())
            {
                case "1":
                    Operations(pointList);
                    break;
                case "2":
                    ListOptions(InputPoints(pointList, false));
                    break;
                case "3":
                    ListOptions(RemovePoint(pointList));
                    break;
                case "4":
                    ListOptions(InputPoints(pointList, true));
                    break;
                default:
                    Main();
                    break;
            }
        }
        static List<Point> InputPoints(List<Point> pointListMaster, bool clearList)
        {
            List<Point> pointList = pointListMaster; 
            Console.Clear(); DisplayList(pointList);
            Console.Write("\n{0}", "Enter a coordinate (X Y) or press enter to save current list: ");
            
            string input = "";
            // Clear list if bool arg true
            if (clearList)
            {
                pointList.Clear();
            }

            // Manage the naming of new points
            char nameChar = 'A';
            if (pointList.Count() > 1)
            {
                if (pointList.Last().Name != 'Z')
                {
                    nameChar = Convert.ToChar(pointList.Last().Name + 1);
                }
            }

            // If coord is entered, add it to the list. Otherwise return the list.
            while (input == "")
            {
                input = Console.ReadLine();

                if (input == "")
                {
                    Console.Clear(); DisplayList(pointList);
                    return pointList;
                }
                else
                {
                     // Read and store the point.
                    pointList.Add(ReadPoint(input));
                    pointList.Last().Name = nameChar;

                    Console.Clear(); DisplayList(pointList);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Successfully added point {0} = ({1}, {2}).",
                        pointList.Last().Name, pointList.Last().X, pointList.Last().Y );
                    Console.ResetColor();
                    Console.Write("\n{0}", "Enter a coordinate (X Y) or press enter to save current list: ");

                    nameChar++;
                    input = "";
                }
            }
            return null;
        }

        static List<Point> RemovePoint(List<Point> oldList)
        {
            char deleteName = 'Z';
            while (deleteName == 'Z')
            {
                Console.Clear(); DisplayList(oldList);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nEnter point to delete: ");
                Console.ResetColor();
                try
                {
                    deleteName = Convert.ToChar(Console.ReadLine());
                }
                catch (SystemException e)
                {
                    FancyErrorMessage(e);
                    Console.ReadKey(true);
                }
            }

            for (int i = 0; i < oldList.Count(); i++)
            {
                if (oldList[i].Name == deleteName)
                {
                    oldList.Remove(oldList[i]);
                }
            }

            List<Point> newList = new List<Point>();
            char counter = 'A';
            foreach (Point point in oldList)
            {
                newList.Add(point);
                point.Name = counter; counter++;
            }

            return newList;
        }

        static Point ReadPoint(string input)
        {
            // Reads input and attempts to create a new point
            int[] coordinates = { 0, 0 };
            bool inputValid = false;
            Point newPoint = new Point();

            // Replace input if exception is thrown
            while (!inputValid)
            {
                try
                {
                    coordinates = input.Split(' ').Select(int.Parse).ToArray();
                    newPoint.X = coordinates[0];
                    newPoint.Y = coordinates[1];
                    inputValid = true;
                }
                catch (SystemException e)
                {
                    FancyErrorMessage(e);
                    Console.Write("\n{0}", "Enter data: ");
                    input = Console.ReadLine();
                }
            }

            return newPoint;
        }
    }
}