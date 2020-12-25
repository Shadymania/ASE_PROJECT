using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
///  Nabin Atreya Sunar
///  ID: C7202333
///  College: The British College
/// </summary>

namespace DrawGeometryShape
{


    public partial class Form1 : Form
    {

        /// <summary>
        ///  output bitmap image
        ///  cursor pointer bitmap image
        ///  canvas for drawing on output bitmap image
        ///  Parses the command line
        ///  Stores the list of errors while parsing
        /// </summary>

        Bitmap drawBoard;                                         
        Bitmap cursorBoard;                                        
        Canvas displayCanvas;                                   
        Parse parser;                                           
        StringBuilder errorList;                                
        Pen p, penLine;
        SolidBrush sb;
        Graphics g;

        int xPosition = -1;
        int yPosition = -1;
        bool moving = false;

        public Form1()
        {
           
            InitializeComponent();
            drawBoard = new Bitmap(740, 400);
            cursorBoard = new Bitmap(740, 400);
            //initializes the canvas objects
            displayCanvas = new Canvas(Graphics.FromImage(drawBoard));
            //transparentCanvas = new Canvas(Graphics.FromImage(cursorBoard));

            errorList = new StringBuilder();
            drawCursor();


            g = outputDisplay.CreateGraphics();
            penLine = new Pen(Color.Black, 5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            penLine.StartCap = penLine.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        //draws the cursor pointer on the transparentcanvas
        public void drawCursor()
        {
            Graphics g = Graphics.FromImage(cursorBoard);
            g.Clear(Color.Transparent);
            g.FillEllipse(new SolidBrush(Color.BlueViolet), displayCanvas.x - 5, displayCanvas.y - 5, 10, 10);
        }


        private void outputDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(drawBoard, 0, 0);
            g.DrawImageUnscaled(cursorBoard, 0, 0);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mENUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Cursor = Cursors.Hand;
        }

        private void aBOUTUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Cursor = Cursors.Hand;
        }

        private void outputDisplay_Click(object sender, EventArgs e)
        {

        }

      
     

        //when enter is pressed on single command
        private void singleCommand_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                String cmd = singleCommand.Text.Trim().ToLower();
                if (cmd.Equals("run"))
                    run(true);
                else
                    run(false);
            }

        }

        public void run(bool cmdRun)
        {
            errorBox.Text = "";
            errorList = new StringBuilder();
            parser = new Parse();
            parser.parseCommand(singleCommand, displayCanvas, errorList);
            if (!label2.Text.Equals("") && cmdRun)                   //if multi command line has text
            {
                parser.parseCommand(multiCommnd, displayCanvas, errorList);

            }
            drawCursor();
            displayError();
            Refresh();
        }

        //refreshes the form and output screen
        public void refreshForm()
        {
            displayError();
            drawCursor();
        }


        //display errors caught while parsing
        public void displayError()
        {
            if (!errorList.ToString().Equals(""))
            {
                errorBox.Text = errorList.ToString();
            }
            errorList.Clear();
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            String line = "";
            openFileDialog.Filter = "Text files (.txt)| *.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader((openFileDialog.FileName));
                string pathing = Path.GetFileName(openFileDialog.FileName);
             //   label2.Text =Path.GetFileName(sr.ToString());
                label2.Text = pathing.ToString();

                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line == null) break;
                    multiCommnd.Text += line;

                    multiCommnd.AppendText(Environment.NewLine);
                }
            }
        }



        /// <summary>
        /// This private method saves a program written in the Program Box to D: drive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The event that is triggered when the menu item is clicked </param>
        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myStream = saveFileDialog1.OpenFile();


                using (StreamWriter writer = new StreamWriter(myStream))
                {
                    writer.Write(label2.Text);
                }
                myStream.Close();
            }
        }

        private void nEWWINDOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            MessageBox.Show("Thanks For Using This Draw Geometry Shape Program. See You Soon !!!");

        }

        private void syntaxbtn_Click(object sender, EventArgs e)
        {
            String cmd = singleCommand.Text.Trim().ToLower();
            errorList = new StringBuilder();
            bool cmdRun = cmd.Equals("run");
            errorBox.Text = "";
            errorList = new StringBuilder();
            parser = new Parse();
            parser.parseCommand(singleCommand, displayCanvas, errorList);
            if (!label2.Text.Equals("") && cmdRun)                   //if multi command line has text
            {
                parser.parseCommand(multiCommnd, new Canvas(), errorList);

            }
            drawCursor();
            displayError();
            Refresh();
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            menuStrip1.Cursor = Cursors.Hand;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                penLine.Color = c.Color;
                button1.BackColor = penLine.Color;

            }
        }

        private void outputDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && xPosition != -1 && yPosition != -1)
            {
                g.DrawLine(penLine, new Point(xPosition, yPosition), e.Location);
                xPosition = e.X;
                yPosition = e.Y;
            }
        }

        private void outputDisplay_MouseDown(object sender, MouseEventArgs e)
        {

            moving = true;
            xPosition = e.X;
            yPosition = e.Y;
            outputDisplay.Cursor = Cursors.Cross;
        }

        private void outputDisplay_MouseUp(object sender, MouseEventArgs e)
        {

            moving = false;
            xPosition = -1;
            yPosition = -1;
            outputDisplay.Cursor = Cursors.Default;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            penLine.Color = pb.BackColor;
            pb.Cursor = Cursors.Hand;
        }
    }
}
