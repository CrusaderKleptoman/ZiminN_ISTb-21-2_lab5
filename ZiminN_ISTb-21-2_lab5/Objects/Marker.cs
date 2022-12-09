using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    class Marker : BaseObject
    {
        public Marker(float X, float Y, float Angle) : base(X, Y, Angle) { }

        public override void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.Red), -3, -3, 6, 6);
            graphics.DrawEllipse(new Pen(Color.Red, 2), -6, -6, 12, 12);
            graphics.DrawEllipse(new Pen(Color.Red, 2), -10, -10, 20, 20);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);
            return path;
        }
    }
}
