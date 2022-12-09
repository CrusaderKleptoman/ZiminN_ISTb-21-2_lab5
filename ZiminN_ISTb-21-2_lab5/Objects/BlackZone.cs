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
        public Action<BaseObject> OnPlayerOverlap;
        public Action<BaseObject> OnMarkerOverlap;
        public Action<BaseObject> OnTargetOverlap;
        public BlackZone(float X, float Y, float Angle) : base(X, Y, Angle) { }

        public override void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Black), -150, 0, 150, 446);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-150, 0, 150, 446);
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);

            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }

            if (obj is Target)
            {
                OnTargetOverlap(obj as Target);
            }

            if (obj is Player)
            {
                OnPlayerOverlap(obj as Player);
            }
        }
    }
}
