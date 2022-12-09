using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    class Target : BaseObject
    {
        public int timerToMove;
        public Target(float X, float Y, float Angle) : base(X, Y, Angle)
        {
            this.timerToMove = 80;
        }

        public override void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.LimeGreen), -15, -15, 30, 30);
            graphics.DrawString(
                timerToMove.ToString(),
                new Font("Verdana", 8), // шрифт и размер
                new SolidBrush(Color.Green), // цвет шрифта
                10, 10 // точка в которой нарисовать текст
                       );
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        public bool TimerTic()
        {
            timerToMove--;
            if (timerToMove == 0)
            {
                return true;
            }
            return false;
        }

    }
}
