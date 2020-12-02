using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsPath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Rectangle _rect;
        private bool _mouseDown;
        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawPolygon(new Pen(Color.Blue, 5),  new PointF[] { _rect.Location, new PointF(_rect.Location.X + _rect.Width, _rect.Location.Y + _rect.Height) });
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _rect.Width = 0;
            _rect.Height = 0;
            _mouseDown = true;
            _rect.Location = e.Location;
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (_mouseDown == true)
            {
                pictureBox1.Invalidate();
                pictureBox1.Invalidate(_rect);
                _rect.Width = e.Location.X - _rect.Location.X;
                _rect.Height = e.Location.Y - _rect.Location.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _rect.Width = e.Location.X - _rect.Location.X;
            _rect.Height = e.Location.Y - _rect.Location.Y;
            pictureBox1.Invalidate(_rect);
            _mouseDown = false;
        }
    }
}
