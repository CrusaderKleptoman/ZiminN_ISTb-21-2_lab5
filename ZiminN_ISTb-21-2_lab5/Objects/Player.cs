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
        public Action<BaseObject> OnMarkerOverlap;
        public float vectorX, vectorY;
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

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);

            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
        }
    }
}
