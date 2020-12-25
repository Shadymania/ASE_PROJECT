using System.Drawing;

/// <summary>
///  Nabin Atreya Sunar
///  ID: C7202333
///  College: The British College
/// </summary>


namespace DrawGeometryShape { 
    /// <summary>
    /// Circle Class,The class inherited from the specific version of the shapes
    /// This class possess os some distinctive qualities
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// The radius is a distinctive property of Circle
        /// it has been declared an integer
        /// </summary>
        public int radius;

        /// <summary>
        ///Method overrides the set method from Shapes class.
        /// All the properties required for creating/drawing circle 
        /// all come in the order:color,fill status and radius
        /// </summary>
        /// <param name="color">Color of the object</param>
        /// <param name="fill"> filled with color in the shape</param>
        /// <param name="list">list in the object</param>
        public override void set(Color color, bool fill, params int[] list)
        {
            base.set(color, fill, list[0], list[1]);
            this.radius = list[2];
        }

        /// <summary>
        ///Overriding the draw method from Shape class.
        /// Specifically draws a circle with the help of Graphics.DrawEllipse method
        /// uses the paramteres set from the set method
        /// </summary>
        /// <param name="g">The object of the graphics</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(this.color, 2);
            g.DrawEllipse(p, xaxis- this.radius, yaxis- this.radius, this.radius * 2, this.radius * 2);
            if (this.fill)
            {
                SolidBrush sb = new SolidBrush(this.color);
                g.FillEllipse(sb, xaxis- this.radius, yaxis- this.radius, radius * 2, radius * 2);
            }
        }

    }
}
