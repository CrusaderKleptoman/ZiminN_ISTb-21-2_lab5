using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    class MyRectangle : BaseObject 
    {
        public MyRectangle(float X, float Y, float Angle, bool NegateRender) : base(X, Y, Angle, NegateRender)
        {
        }

        public override void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Yellow), -25, -15, 50, 30);
            graphics.DrawRectangle(new Pen(Color.Red, 2), -25, -10, 50, 30);
        }
    }
}
