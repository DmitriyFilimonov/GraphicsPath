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
        private Bitmap _mainBitmap;
        private Graphics _graphics;


        //загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            _mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(_mainBitmap);//указываем нашему графиксу, где рисовать
        }

        //вместо Canvas.DrawIt - метод вызываемый событием пикчербокса Paint
        //само событие вызывается методом pictureBox1.Invalidate();
        //в свою очередь pictureBox1.Invalidate(); вызывается в MouseMove при MouseDown
        //e.Graphics - это "системный" графикс, который хранится в объекте события Paint
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//включаем сглаживание на временной прорисовке
            e.Graphics.DrawPolygon(new Pen(Color.Blue, 5),  new PointF[] { _rect.Location, new PointF(_rect.Location.X + _rect.Width, _rect.Location.Y + _rect.Height) });
            e.Graphics.DrawImage(_mainBitmap, new Point(0,0));
        }

        //NouseMove, где вызывается Invalidate
        //
        //pictureBox1.Invalidate(_rect) с аргументом передаёт область которую нужно перерисовать, в объект события Paint
        //
        //
        //без аругмента pictureBox1.Invalidate()без аргумента мы говорим, что нужно снести всё что нарисовано
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (_mouseDown == true)
            {
                //уничтожение прорисовки от предыдущего движения мышью
                pictureBox1.Invalidate();
                
                //получение точек для новой прорисовки
                _rect.Width = e.Location.X - _rect.Location.X;
                _rect.Height = e.Location.Y - _rect.Location.Y;
                
                //прорисовка текущего движения мыши
                pictureBox1.Invalidate(_rect);//прорисовка 
            }
        }

        //"сброс" фигуры, отслеживание MoouseDown
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _rect.Width = 0;
            _rect.Height = 0;
            _mouseDown = true;
            _rect.Location = e.Location;//установка начала построения
            
        }

        //_graphics рисует последнюю фигуру на связанном с ним (стр. 32) битмапе,
        //который уже хранит все предыдущие растрированные фигуры
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _graphics.DrawPolygon(new Pen(Color.Blue, 5), new PointF[] { _rect.Location, new PointF(_rect.Location.X + _rect.Width, _rect.Location.Y + _rect.Height) });
            _mouseDown = false;
        }

        
    }
}
