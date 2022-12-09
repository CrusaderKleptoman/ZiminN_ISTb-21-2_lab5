using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    internal class NegatePlayer : Player
    {
        public NegatePlayer(float X, float Y, float Angle) : base(X, Y, Angle) { }

        public override void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.White), -15, -15, 30, 30);
            graphics.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }
    }
}
