using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tetris;
// Class meant to handle the 4 blocks that make up one figure in tetris.
namespace Tetris
{
    class Figure
    {
        // CompanionVariables
        private int x;
        private int y;
        private int s; // side

        //// Constructor
        public Figure(int x, int y, int s )
        {
            this.x    = x;
            this.y    = y;
            this.s    = s;
        }

        // Properties:
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value > 0) x = value;
                else x = -value;
            }
        } // For x-koordinate
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value > 0) y = value;
                else y = -value;
            }
        } // For y-koordinate

        // Methods:
        // Draw:
        public void DrawI(Graphics g) // Draws the I block
        {
            for (int i = 0; i < 4; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Teal), x + i*s, y, s, s);
                g.DrawRectangle(new Pen(Color.Black), x + i*s, y, s, s);
            }
        }
        // Draw:
        public void DrawJ(Graphics g) // Draws the J block
        {
            for (int i = 0; i < 3; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), x + i * s, y, s, s);
                g.DrawRectangle(new Pen(Color.Black), x + i * s, y, s, s);
            }
            g.FillRectangle(new SolidBrush(Color.Blue), x, y - s, s, s);
            g.DrawRectangle(new Pen(Color.Black), x, y - s , s, s);
        }

    }
}
