# NetLs_Fedoriv

This repository contains a C# class called Square that represents a square with coordinates and a point for checking if it lies inside the square. The Square class is designed to interact with the user, receive input, and perform calculations to determine if the point lies inside the square.

## Functionality

The Square class provides the following functionality:
* Initializes a new instance of the Square class by interacting with the user to input the square's coordinates and a point for checking.
* Fills the coordinates of the square and validates if it forms a valid square.
* Fills the coordinates of the point and validates the input.
* Checks if the point lies inside the rectangle formed by the square's vertices and displays the appropriate message.
* Displays a loading message with a specified text and a simulated loading animation.
* Displays the coordinates of the square's vertices.
* Prompts the user to input the coordinates of a point and returns a Point2D object representing the coordinates.
* Prompts the user to input the coordinates of the square's vertices and returns an array of Point2D objects representing the coordinates.
* Checks if the point lies inside the rectangle formed by the square's vertices.
* Finds the opposite diagonal points of the rectangle formed by the square's vertices.
* Checks if the provided coordinates form a valid square.
* Calculates the square of the distance between two Point2D objects.

## Usage

To use the Square class, simply create an instance of the class. The class will interact with the user to input the square's coordinates and a point for checking. Once the input is provided, the class will perform the necessary calculations and display the result.
```cs
Square square = new Square();
  ```
