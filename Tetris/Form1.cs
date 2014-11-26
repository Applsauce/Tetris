using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// An attempt to copy/clone the classic Tetris
// begun 2014-11-24 by Fredrik Österberg at Polhemskolan Lund
namespace Tetris
{
    public partial class Form1 : Form
    {
        bool newfigure = true;
        Random generator = new Random();
        private List<Rektangel> blocks = new List<Rektangel>();
        Figure I;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            I = new Figure(0, 0, 20);
            //Invalidate();
        }

        private void NewFigure() // Creates a new figure
        {
            for (int i = 0; i < 4; i++)
            {
                Rektangel part = new Rektangel(20 * i, 0, 20, 20, Color.Red);
                blocks.Add(part);
            }
            newfigure = false;
        }

        private void PauseGame(){ timer.Stop(); } // Pauses the game

        private void pbxSpel_Click(object sender, EventArgs e) 
        {
            timer.Start();            
            //if (!GameOn) StartGame();
            //else PauseGame();
            //GameOn = true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e) // Draws the parts
        {
            Graphics g = e.Graphics;
            //if (newfigure) { NewFigure(); }
            //for (int i = 0; i < blocks.Count; i++)
            //{
            //    blocks[i].Rita(g);
            //}
            I.DrawI(g);

        }

        private void timer_Tick(object sender, EventArgs e)
        {
        //    for (int i = 0; i < blocks.Count; i++)
        //    {
        //        if (blocks[i].Y == 380) goto Inalid;
        //        blocks[i].Y += 20;
        //    }
        //Inalid:
            I.Y += 2;
            panel1.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // Detects when a key is pressed
        {
            if      (e.KeyCode == Keys.Right && I.X != 120)// Moves figure right
            { I.X += 20; Invalidate(); } 
            else if (e.KeyCode == Keys.Left  && I.X != 0)  // Moves figure left
            { I.X -= 20; Invalidate(); }
        }
    }
}
