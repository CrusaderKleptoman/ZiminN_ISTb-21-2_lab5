using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZiminN_ISTb_21_2_lab5.Objects;

namespace ZiminN_ISTb_21_2_lab5
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new List<BaseObject>();
        Player player;
        Marker marker;
        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            objects.Add(player);
            objects.Add(marker);

            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }

        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);

                dx /= length;
                dy /= length;

                player.vectorX = dx * 2f;
                player.vectorY = dy * 2f;

                player.Angle = 90 - (float)Math.Atan2(player.vectorX, player.vectorY) * 180 / (float)Math.PI;
            }

            player.vectorX += -player.vectorX * 0.1f;
            player.vectorY += -player.vectorY * 0.1f;

            player.X += player.vectorX;
            player.Y += player.vectorY;

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            updatePlayer();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                }               
            }

            foreach (var obj in objects.ToList())
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
