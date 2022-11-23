using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    class Player : BaseObject
    {
        public Player(float X, float Y, float Angle) : base(X, Y, Angle)
        { }

        public override void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.SteelBlue), -15, -15, 30, 30);
            graphics.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);
            graphics.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
    }
}
