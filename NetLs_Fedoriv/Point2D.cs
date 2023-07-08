namespace NetLs_Fedoriv
{
    /// <summary>
    /// Represents a 2D point with X and Y coordinates.
    /// </summary>
    public class Point2D
    {
        /// <summary>
        /// Gets or sets the X coordinate of the point.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the point.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The X coordinate of the point.</param>
        /// <param name="y">The Y coordinate of the point.</param>
        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Implements the less than operator for comparing two points.
        /// </summary>
        /// <param name="p1">The first point.</param>
        /// <param name="p2">The second point.</param>
        /// <returns>True if p1 is less than p2 in both X and Y coordinates, false otherwise.</returns>
        public static bool operator <(Point2D p1, Point2D p2)
        {
            return (p1.X < p2.X) && (p1.Y < p2.Y);
        }

        /// <summary>
        /// Implements the greater than operator for comparing two points.
        /// </summary>
        /// <param name="p1">The first point.</param>
        /// <param name="p2">The second point.</param>
        /// <returns>True if p1 is greater than p2 in both X and Y coordinates, false otherwise.</returns>
        public static bool operator >(Point2D p1, Point2D p2)
        {
            return (p1.X > p2.X) && (p1.Y > p2.Y);
        }

        /// <summary>
        /// Validates the input string and creates a <see cref="Point2D"/> object with the provided coordinates.
        /// </summary>
        /// <param name="input">The input string containing the coordinates.</param>
        /// <returns>A <see cref="Point2D"/> object with the validated coordinates.</returns>
        public static Point2D ValidateAndCreatePoint(string input)
        {
            string[] points = input.Split(' '); // Split the input into individual coordinates

            if (points.Length != 2)
            {
                throw new WrongInputException("Invalid input, try again"); // Throw an exception for invalid input
            }

            if (!float.TryParse(points[0], out float x) || !float.TryParse(points[1], out float y) || float.IsInfinity(x) || float.IsInfinity(y))
            {
                throw new WrongInputException("Invalid input, try again"); // Throw an exception for invalid input
            }

            return new Point2D(x, y);
        }
    }
}
