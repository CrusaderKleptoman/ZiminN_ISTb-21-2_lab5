﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ZiminN_ISTb_21_2_lab5.Objects
{
    class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;
        public bool NegateRender;

        public Action<BaseObject, BaseObject> OnOverlap;

        public BaseObject(float x, float y, float angle, bool negateRender)
        {
            X = x;
            Y = y;
            Angle = angle;
            NegateRender = negateRender;
        }

        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);

            return matrix;
        }

        public virtual void Render(Graphics graphics)
        {

        }

        public virtual GraphicsPath GetGraphicsPath()
        {
            return new GraphicsPath();
        }

        public virtual bool Overlaps(BaseObject obj, Graphics graphics)
        {
            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();

            path1.Transform(this.GetTransform());
            path2.Transform(obj.GetTransform());

            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(graphics);
        }

        public virtual void Overlap(BaseObject obj)
        {
            if(this.OnOverlap != null)
            {
                this.OnOverlap(this, obj);
            }
        }

    }
}
