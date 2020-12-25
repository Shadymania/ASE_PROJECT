using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawGeometryShape;
using drawing = System.Drawing;


namespace UnitTestProject2
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        /// <summary>
        /// Tests if a Circle class validate value
        /// </summary>
  
        public void TestCircle()
        {
            Circle circle = new Circle();
            circle.set(drawing.Color.Blue, true, 0, 0, 10);

            int[] expectedValues = { 10 };
            int[] obtainedValues = {circle.radius };

            // validate results
            Assert.IsTrue(expectedValues[0] == 10, "Circle did not correctly set its radius!");
        }



        /// <summary>
        /// Tests if a Rectangle class validly forms
        /// </summary>
        [TestMethod]
        public void TestRectangle()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.set(drawing.Color.Blue, true, 0, 0, 10, 15);

            int[] expectedValues = { 10, 15 };
            int[] obtainedValues = { rectangle.width, rectangle.height };

            // validate results
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Opps....Sorry ! Rectangle did not correctly set its width!");
            Assert.IsTrue(expectedValues[1] == obtainedValues[1], "Opps....Sorry !Rectangle did not correclty set its height!");
        }




        /// <summary>
        /// Tests if a Square class validly forms
        /// </summary>
        [TestMethod]
        public void TestSquare()
        {
            Square square = new Square();
            square.set(drawing.Color.Blue, true, 0, 0, 10);

            int[] expectedValues = { 10 };
            int[] obtainedValues = { square.width };

            // validate results
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Opps....Sorry !Square did not correctly set its width!");
        }


        /// <summary>
        /// Tests if a Triangle class validly forms
        /// </summary>
        [TestMethod]
        public void TestTriangle()
        {
            Triangle triangle = new Triangle();
            triangle.set(drawing.Color.Blue, true, 0, 0, 10, 15, 20);

            int[] expectedValues = { 10, 15, 20 };
            int[] obtainedValues = { triangle.hypotenuse, triangle.breadth, triangle.perpendicular };

            // validate results
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Opps....Sorry ! Triangle did not correclty set its hypotenuse!");
            Assert.IsTrue(expectedValues[1] == obtainedValues[1], "Opps....Sorry ! Triangle did not correclty set its breadth!");
            Assert.IsTrue(expectedValues[2] == obtainedValues[2], "Opps....Sorry !Triangle did not correclty set its perpendicular!");
        }




        // <summary>
        /// Tests if a Rectangle class validly forms
        /// </summary>
        [TestMethod]
        public void TestShapeFactory()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape rectangleShape = shapeFactory.createShape("rectangle");
            Shape circleShape = shapeFactory.createShape("circle");
            Shape squareShape = shapeFactory.createShape("square");
            Shape triangleShape = shapeFactory.createShape("triangle");

            // validate results
            Assert.IsTrue(rectangleShape is Rectangle, "Opps....Sorry ! ShapeFactory did not return Rectangle correctly.");
            Assert.IsTrue(circleShape is Circle, "Opps....Sorry !ShapeFactory did not return Circle correctly.");
            Assert.IsTrue(squareShape is Square, "Opps....Sorry !ShapeFactory did not return Square correctly.");
            Assert.IsTrue(triangleShape is Triangle, "Opps....Sorry !ShapeFactory did not return Triangle correctly.");
        }


    }

}
