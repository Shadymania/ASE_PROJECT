using System;


/// <summary>
///  Nabin Atreya Sunar
///  ID: C7202333
///  College: The British College
/// </summary>
namespace DrawGeometryShape
{
    /// <summary>
    /// Factory pattern is applied here.
    /// This is an independent class, a common interface that creates/produces objects. 
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Method that creates Shapes according to the shape type
        /// Fetch the new object of the certain shape types.
        /// and returns the r as parameter
        /// </summary>
        /// <param name="shapetype">the name of shape provided by user</param>
        /// <returns>An object of a specific shape type </returns>
        public Shape createShape(String shapetype)
        {
            if (shapetype == "rectangle")
            {
                Rectangle r = new Rectangle();
                return r;
            }
            else if (shapetype == "square")
            {
                Square r = new Square();
                return r;
            }
            else if (shapetype == "triangle")
            {
                Triangle t = new Triangle();
                return t;
            }
            else if (shapetype == "circle")
            {
                Circle c = new Circle();
                return c;
            }
            return null;
        }
    }
}
