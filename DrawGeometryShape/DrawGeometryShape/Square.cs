using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Nabin Atreya Sunar
///  ID: C7202333
///  College: The British College
/// </summary>


namespace DrawGeometryShape
{
    /// <summary>
    /// Square, a more specific version of Shape, class inherited from it.
    /// Has some unique properties.
    /// </summary>
    public class Square : Shape
    {

        /// <summary>
        /// width, some unique properties of square class declared as integers 
        /// </summary>
        public int width;

        /// <summary>
        /// Method overrides the set method from Shapes class.
        /// All the properties required for creating/drawing rectangle 
        /// all come in the order:color,fill status , width and height
        /// </summary>
        /// <param name="color"> Color components in the shape</param>
        /// <param name="fill">fill color in the shape</param>
        /// <param name="list">stores in the list</param>
        public override void set(Color color, bool fill, params int[] list)
        {   /*
             * The three values are already set from the Shape abstract class
             */
            base.set(color, fill, list[0], list[1]);
            this.width = list[2];
        }

        /// <summary>
        /// Overriding the draw method from Shape class.
        /// Specifically draws a rectangle with the help of Graphics.DrawRectangle method
        /// uses the paramteres set from the set method
        /// </summary>
        /// <param name="g">Object of the graphics</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(this.color, 2);
            g.DrawRectangle(p, xaxis - width / 2, yaxis - width / 2, width, width);

            if (this.fill)
            {
                SolidBrush sb = new SolidBrush(this.color);
                g.FillRectangle(sb, xaxis- width/2, yaxis- width/2, width, width);
            }

        }
    }
}
