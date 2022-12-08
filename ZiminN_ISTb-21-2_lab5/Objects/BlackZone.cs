using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    internal class BlackZone : BaseObject
    {
        public BlackZone(float X, float Y, float Angle, bool NegateRender) : base(X, Y, Angle, NegateRender) { }

        public override void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Black), -150, -223, 150, 223);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-70, -223, 70, 223);
            return path;
        }
    }
}
