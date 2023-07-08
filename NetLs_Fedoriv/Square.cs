using System;
using System.Linq;
using System.Threading;

namespace NetLs_Fedoriv
{
    /// <summary>
    /// Represents a square with coordinates and a point for checking if it lies inside the square.
    /// </summary>
    public sealed class Square
    {
        private static byte _sidesCount = 4;

        private Point2D[] _squareCoords = new Point2D[_sidesCount];

        private Point2D _point = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class by interacting with the user to input the square's coordinates and a point for checking.
        /// </summary>
        public Square()
        {
            InitializeSquare();
            ShowCoords();
            FillAndCheckPoint();
            CheckPointInsideRectangle();
        }

        /// <summary>
        /// Fills the coordinates of the square and validates if it forms a valid square.
        /// </summary>
        private void InitializeSquare()
        {
            while (true)
            {
                _squareCoords = FillCoords();
                ImitateLoading("Checking whether such a square can exist");
                if (IsSquare())
                {
                    break;
                }
                Console.WriteLine("Such a square cannot exist, repeat the input procedure");
            }
        }

        /// <summary>
        /// Fills the coordinates of the point and validates the input.
        /// </summary>
        private void FillAndCheckPoint()
        {
            while (_point is null)
            {
                _point = FillPoint();
            }
            ImitateLoading("Checking if a point lies inside a rectangle");
        }

        /// <summary>
        /// Checks if the point lies inside the rectangle formed by the square's vertices and displays the appropriate message.
        /// </summary>
        private void CheckPointInsideRectangle()
        {
            if (FindPoint())
            {
                Console.WriteLine("The point lies inside the rectangle");
            }
            else
            {
                Console.WriteLine("The point does not lie inside the rectangle");
            }
        }

        /// <summary>
        /// Displays a loading message with a specified text and a simulated loading animation.
        /// </summary>
        /// <param name="text">The text to display in the loading message.</param>
        private void ImitateLoading(string text)
        {
            Console.WriteLine($"{text}. Please wait\n"); // Display loading message

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(400); // Pause for a short period to simulate loading

                Console.Write(". "); // Display loading dots
            }

            Console.Write("\n");
        }

        /// <summary>
        /// Displays the coordinates of the square's vertices.
        /// </summary>
        private void ShowCoords()
        {
            if (_squareCoords.ToList().Count == 0)
            {
                Console.WriteLine("Input Coords"); // Display message if no coordinates are inputted
                return;
            }

            Console.WriteLine("Inputed value"); // Display message for inputted coordinates

            for (int i = 0; i < _squareCoords.Length; i++)
            {
                Console.WriteLine($"Coordinate #{i + 1}: ({_squareCoords[i].X},{_squareCoords[i].Y})"); // Display each coordinate
            }

            Console.WriteLine("");
        }

        /// <summary>
        /// Prompts the user to input the coordinates of a point and returns a <see cref="Point2D"/> object representing the coordinates.
        /// </summary>
        /// <returns>A <see cref="Point2D"/> object representing the coordinates of the point.</returns>
        private Point2D FillPoint()
        {
            Point2D coords = null;

            try
            {
                Console.WriteLine($"Input point (x, y) in format -> '1 2':"); // Prompt for inputting the point coordinates

                string input = Console.ReadLine().RemoveExtraSpaces(); // Read the input and remove extra spaces

                coords = Point2D.ValidateAndCreatePoint(input); // Create a new Point2D object with the provided coordinates
            }
            catch (WrongInputException ex)
            {
                Console.WriteLine(ex.Message); // Display the error message for wrong input
            }

            return coords;
        }

        /// <summary>
        /// Prompts the user to input the coordinates of the square's vertices and returns an array of <see cref="Point2D"/> objects representing the coordinates.
        /// </summary>
        /// <returns>An array of <see cref="Point2D"/> objects representing the coordinates of the square's vertices.</returns>
        private Point2D[] FillCoords()
        {
            Point2D[] coords = new Point2D[_sidesCount];


            for (int i = 0; i < _sidesCount; i++)
            {
                Console.WriteLine($"Input {i + 1} coordinates (x,y) in format -> '1 2':"); // Prompt for inputting the coordinates of each side
                string input = Console.ReadLine().RemoveExtraSpaces(); // Read the input and remove extra spaces

                try
                {
                    coords[i] = Point2D.ValidateAndCreatePoint(input); // Create a new Point2D object with the provided coordinates
                }
                catch (WrongInputException ex)
                {
                    Console.WriteLine(ex.Message);  // Display the error message for wrong input
                    i--;
                }
            }

            return coords;
        }

        /// <summary>
        /// Checks if the point lies inside the rectangle formed by the square's vertices.
        /// </summary>
        /// <returns><see langword="true"/> if the point lies inside the rectangle; otherwise, <see langword="false"/>.</returns>
        private bool FindPoint()
        {
            Point2D[] opposites = FindOppositeDiagonalPoints(); // Find the opposite diagonal points of the rectangle
            if (opposites.Length == 0)
            {
                return false;
            }

            if (CheckIfPointInside(opposites[0], opposites[1])) // Check if the point lies inside the rectangle
            {
                return true;
            }

            if (CheckIfPointInside(opposites[1], opposites[0])) // Check if the point lies inside the rectangle (reverse order of diagonals)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the point lies inside the rectangle formed by the specified bottom-left and top-right points.
        /// </summary>
        /// <param name="downCorner">The bottom-left point of the rectangle.</param>
        /// <param name="upCorner">The top-right point of the rectangle.</param>
        /// <returns><see langword="true"/> if the point lies inside the rectangle; otherwise, <see langword="false"/>.</returns>
        private bool CheckIfPointInside(Point2D downCornner, Point2D upCornner)
        {
            if (_point.X > downCornner.X && _point.X < upCornner.X &&
               _point.Y > downCornner.Y && _point.Y < upCornner.Y) // Check if the point is inside the rectangle
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Finds the opposite diagonal points of the rectangle formed by the square's vertices.
        /// </summary>
        /// <returns>An array of <see cref="Point2D"/> objects representing the opposite diagonal points of the rectangle.</returns>
        private Point2D[] FindOppositeDiagonalPoints()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            for (int i = 0; i < _squareCoords.Length; i++)
            {
                // Find the minimum and maximum values of X and Y coordinates
                minX = Math.Min(minX, _squareCoords[i].X);
                minY = Math.Min(minY, _squareCoords[i].Y);
                maxX = Math.Max(maxX, _squareCoords[i].X);
                maxY = Math.Max(maxY, _squareCoords[i].Y);
            }

            // Form the bottom-left and top-right points of the rectangle
            Point2D bottomLeft = new Point2D(minX, minY);
            Point2D topRight = new Point2D(maxX, maxY);

            return new Point2D[] { bottomLeft, topRight };
        }

        /// <summary>
        /// Checks if the provided coordinates form a valid square.
        /// </summary>
        /// <returns><see langword="true"/> if the coordinates form a square; otherwise, <see langword="false"/>.</returns>
        private bool IsSquare()
        {
            // Calculate the square of the distances between the first vertex and the other vertices
            float distance2 = SquareDistance(_squareCoords[0], _squareCoords[1]);
            float distance3 = SquareDistance(_squareCoords[0], _squareCoords[2]);
            float distance4 = SquareDistance(_squareCoords[0], _squareCoords[3]);

            // If any of the distances is zero, it's not a square
            if (distance2 == 0 || distance3 == 0 || distance4 == 0)
                return false;

            // Check the conditions for a square:
            // - distance2 equals distance3 and 2 times distance2 equals distance4
            //   and 2 times the square of the distance between the second and fourth vertices equals the square of the distance between the second and third vertices
            // - distance3 equals distance4 and 2 times distance3 equals distance2
            //   and 2 times the square of the distance between the third and second vertices equals the square of the distance between the third and fourth vertices
            // - distance2 equals distance4 and 2 times distance2 equals distance3
            //   and 2 times the square of the distance between the second and third vertices equals the square of the distance between the second and fourth vertices
            if ((distance2 == distance3 && 2 * distance2 == distance4
                    && 2 * SquareDistance(_squareCoords[1], _squareCoords[3]) == SquareDistance(_squareCoords[1], _squareCoords[2]))
                || (distance3 == distance4 && 2 * distance3 == distance2
                    && 2 * SquareDistance(_squareCoords[2], _squareCoords[1]) == SquareDistance(_squareCoords[2], _squareCoords[3]))
                || (distance2 == distance4 && 2 * distance2 == distance3
                    && 2 * SquareDistance(_squareCoords[1], _squareCoords[2]) == SquareDistance(_squareCoords[1], _squareCoords[3])))
            {
                return true; // The given coordinates form a square
            }

            return false; // The given coordinates do not form a square
        }

        /// <summary>
        /// Calculates the square of the distance between two <see cref="Point2D"/> objects.
        /// </summary>
        /// <param name="first">The first point.</param>
        /// <param name="second">The second point.</param>
        /// <returns>The square of the distance between the two points.</returns>
        private float SquareDistance(Point2D first, Point2D second)
        {
            float xDifference = first.X - second.X;
            float yDifference = first.Y - second.Y;

            float xSquared = xDifference * xDifference;
            float ySquared = yDifference * yDifference;

            float distance = xSquared + ySquared;

            return distance;
        }
    }
}
