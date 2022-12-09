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
        Random random = new Random();
        Player player; NegatePlayer negatePlayer;
        Marker marker; NegateMarker negateMarker;
        Target firstTarget, secondTarget; NegateTarget negateFirstTarget, negateSecondTarget;
        BlackZone blackZone;
        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            firstTarget = new Target(random.Next(pbMain.Width - 30) + 30, random.Next(pbMain.Height - 30) + 30, 0);
            secondTarget = new Target(random.Next(pbMain.Width - 30) + 30, random.Next(pbMain.Height - 30) + 30, 0);
            blackZone = new BlackZone(0, 0, 0);
            
            objects.Add(player);
            objects.Add(marker);
            objects.Add(firstTarget);
            objects.Add(secondTarget);
            objects.Add(blackZone);

            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
                if (negateMarker != null)
                {
                    objects.Remove(negateMarker);
                    negateMarker = null;
                }
            };

            player.OnTargetOverlap += (t) =>
            {
                objects.Remove(t);
                if (t == firstTarget)
                {
                    firstTarget = null;
                }
                if (t == secondTarget)
                {
                    secondTarget = null;
                }
                labelScore.Text = $"Очки: {player.score}";
            };

            blackZone.OnPlayerOverlap += (p) =>
            {
                if (negatePlayer == null)
                {
                    negatePlayer = new NegatePlayer(p.X, p.Y, p.Angle);
                    objects.Add(negatePlayer);     
                }
            };
            blackZone.OnMarkerOverlap += (m) =>
            {
                if (m != null && negateMarker == null)
                {
                    negateMarker = new NegateMarker(m.X, m.Y, m.Angle);
                    objects.Add(negateMarker);
                }
            };
            blackZone.OnTargetOverlap += (t) =>
            {
                if (t == firstTarget && negateFirstTarget == null)
                {
                    negateFirstTarget = new NegateTarget(t.X, t.Y, t.Angle);
                    negateFirstTarget.timerToMove = firstTarget.timerToMove;
                    objects.Add(negateFirstTarget);
                }
                if (t == secondTarget && negateSecondTarget == null)
                {
                    negateSecondTarget = new NegateTarget(t.X, t.Y, t.Angle);
                    negateSecondTarget.timerToMove = secondTarget.timerToMove;
                    objects.Add(negateSecondTarget);
                }
            };
        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }

        private void updateBlackZone()
        {
            blackZone.X = blackZone.X + 5;
            if (blackZone.X >= (pbMain.Width + 150))
            {
                blackZone.X = 0;
            }
        }
        private void updateTarget()
        {
            if (firstTarget != null && firstTarget.TimerTic())
            {
                objects.Remove(firstTarget);
                firstTarget = null;
            }
            if (negateFirstTarget != null && negateFirstTarget.TimerTic())
            {
                objects.Remove(negateFirstTarget);
                negateFirstTarget = null;
            }

            if (secondTarget != null && secondTarget.TimerTic())
            {
                objects.Remove(secondTarget);
                secondTarget = null;
            }
            if (negateSecondTarget != null && negateSecondTarget.TimerTic())
            {
                objects.Remove(negateSecondTarget);
                negateSecondTarget = null;
            }

            if (firstTarget == null)
            {
                firstTarget = new Target(random.Next(pbMain.Width - 30) + 30, random.Next(pbMain.Height - 30) + 30, 0);
                objects.Add(firstTarget);
            }

            if (secondTarget == null)
            {
                secondTarget = new Target(random.Next(pbMain.Width - 30) + 30, random.Next(pbMain.Height - 30) + 30, 0);
                objects.Add(secondTarget);
            }
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

                player.vectorX += dx * 0.5f;
                player.vectorY += dy * 0.5f;

                player.Angle = 90 - (float)Math.Atan2(player.vectorX, player.vectorY) * 180 / (float)Math.PI;
            }

            player.vectorX += -player.vectorX * 0.1f;
            player.vectorY += -player.vectorY * 0.1f;

            player.X += player.vectorX;
            player.Y += player.vectorY;

            if (negatePlayer != null)
            {
                negatePlayer.X = player.X;
                negatePlayer.Y = player.Y;
                negatePlayer.Angle = player.Angle;
            }
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            updatePlayer();
            updateTarget();
            updateBlackZone();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                }
                if (obj != blackZone && blackZone.Overlaps(obj, g))
                {
                    blackZone.Overlap(obj);
                }
                
            }
            if (firstTarget != null && firstTarget.X + 165 <= blackZone.X && negateFirstTarget != null)
            {
                objects.Remove(negateFirstTarget);
                negateFirstTarget = null;
            }

            if (secondTarget != null && secondTarget.X + 165 <= blackZone.X && negateSecondTarget != null)
            {
                objects.Remove(negateSecondTarget);
                negateSecondTarget = null;
            }

            if (marker != null && marker.X + 160 <= blackZone.X && negateMarker != null)
            {
                objects.Remove(negateMarker);
                negateMarker = null;
            }

            if (player.X + 165 <= blackZone.X && negatePlayer != null)
            {
                objects.Remove(negatePlayer);
                negatePlayer = null;
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
            if (negateMarker != null)
            {
                objects.Remove(negateMarker);
                negateMarker = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
