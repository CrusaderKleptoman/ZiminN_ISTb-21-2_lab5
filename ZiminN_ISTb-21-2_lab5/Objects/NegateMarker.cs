using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    internal class NegateMarker : Marker
    {
        public NegateMarker(float X, float Y, float Angle) : base(X, Y, Angle) { }

        public override void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.White), -3, -3, 6, 6);
            graphics.DrawEllipse(new Pen(Color.White, 2), -6, -6, 12, 12);
            graphics.DrawEllipse(new Pen(Color.White, 2), -10, -10, 20, 20);
        }
    }
}
