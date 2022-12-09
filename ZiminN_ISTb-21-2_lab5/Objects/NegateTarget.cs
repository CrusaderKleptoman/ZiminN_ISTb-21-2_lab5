using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    internal class NegateTarget : Target
    {
        public NegateTarget(float X, float Y, float Angle) : base(X, Y, Angle) { }

        public override void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.White), -15, -15, 30, 30);
            graphics.DrawString(
                timerToMove.ToString(),
                new Font("Verdana", 8), // шрифт и размер
                new SolidBrush(Color.White), // цвет шрифта
                10, 10 // точка в которой нарисовать текст
                       );
        }
    }
}
