using System;
using System.Drawing;

/// <summary>
///  Nabin Atreya Sunar
///  ID: C7202333
///  College: The British College
/// </summary>

namespace DrawGeometryShape
{
    public class Canvas
    {
        //constants for color strings
        const String RED = "red";
        const String GREEN = "green";
        const String BLUE = "blue";
        const String WHITE = "white";
        const String BLACK = "black";
        const String YELLOW = "yellow";


        public Graphics g;     
        //graphics to draw on

        public int x, y;        
        //x and y position

        public bool fill;       
        //fill status for shapes

        public Color color;     
        //pen and fill color

        public Canvas()
        {
            Bitmap b = new Bitmap(700,400);         
            //deafult bitmap
            g = Graphics.FromImage(b);
            x = y = 0;
            color = Color.Black;
            fill = false;
        }

        //Parameterized constructor
        public Canvas(Graphics g)
        {
            this.g = g;                 
            x = y = 0;
            color = Color.Black;
            fill = false;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">moves the cursor pointer to defined positions</param>
        /// <returns>moves the cursor pointer to defined positions</returns>
        public bool moveTo(int[] param)
        {
            if (param.Length != 4)              
                //if invalid param length
                return false;
            x = param[2];
            y = param[3];
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">draws line to defined positions, returns false if error found</param>
        /// <returns>draws line to defined positions, returns false if error found</returns>
        public bool drawTo(int[] param)
        {
            if (param.Length != 4)            
                //if invalid param length
                return false;
            g.DrawLine(new Pen(color, 2), x, y, param[2], param[3]);
            x = param[2];
            y = param[3];
            return true;
        }

 
        /// </summary>
        /// <param name="param">set color for fill and pen, returns false if error found</param>
        /// <returns></returns>
        public bool setColor(String[] param)
        {
            param[0] = param[0].Trim().ToLower();       
            //trim and lowercase parameter
            if (param.Length != 1)                      
                //if invalid param length
                return false;
            //set color as defined
            if (param[0].Equals(RED))                   
                color = Color.Red;
            if (param[0].Equals(BLUE))
                color = Color.Blue;
            if (param[0].Equals(GREEN))
                color = Color.Green;
            if (param[0].Equals(BLACK))
                color = Color.Black;
            if (param[0].Equals(WHITE))
                color = Color.White;
            if (param[0].Equals(YELLOW))
                color = Color.Yellow;
            return true;                    
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">sets fill status for shapes,  returns false if error found</param>
        /// <returns>sets fill status for shapes,  returns false if error found</returns>
        public bool setFill(String[] param)
        {
            if (param.Length != 1)
                return false;
            param[0] = param[0].Trim().ToLower();
            if (param[0].Equals("on"))
                fill = true;
            else if (param[0].Equals("off"))
                fill = false;
            else
                return false;

            return true;
        }

        //clears the graphics to white color
        public void clear()
        {
            g.Clear(Color.White);
        }
        //clears the graphics to white color
        public void reset()
        {
            g.Clear(Color.White);
            x = y = 0;
            fill = false;
            color = Color.Black;
        }
    }
}
