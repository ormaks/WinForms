using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms.Shapes
{
    [Serializable]
    public class Circle
    {
        public Point Centre { get; set; }
        public int Radius { get; set; }
        public string Name { get; set; }

        
        public Color CircleColor { get; set; }

       
        public int ColorArgb
        {
            get => CircleColor.ToArgb();
            set => CircleColor = Color.FromArgb(value);
        }


        public Circle(Point c, int e)
        {
            Centre = c;
            Radius = e;
            Name = "";
            CircleColor = Color.White;
        }

        public Circle(Circle c)
        {
            Centre = c.Centre;
            Radius = c.Radius;
            Name = c.Name;
            CircleColor = c.CircleColor;
        }

        public Circle()
        {
            Centre = new Point();
            Radius =0;
            Name = "";
            CircleColor = new Color();
        }
        public void Move(MouseEventArgs mouseEvent)
        {
            int newCentreX = mouseEvent.X;
            int newCentreY = mouseEvent.Y;

            Centre = new Point(newCentreX, newCentreY);
        }
    }
}
