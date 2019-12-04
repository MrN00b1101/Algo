using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Spiral
{
    public partial class Form1 : Form
    {
        private PointF kezdo;

        public Form1()
        {
            InitializeComponent();
            this.kezdo = new PointF(
                this.canvas.Width / 2 + 100,
                this.canvas.Height / 2
            );
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //g.DrawLine(Pens.Magenta, 50, 50, 100, 100);
            //g.DrawRectangle(Pens.Blue, 200, 200, 30, 30);
            //g.FillRectangle(Brushes.Azure, 200, 200, 30, 30);

            // this.Spiral(g, this.kezdo, 250, 90);
            this.PitagorasziFa(
                g,
                this.kezdo,
                new PointF(this.kezdo.X + 50, this.kezdo.Y),
                10);
        }

        private void Spiral(Graphics g, PointF P, int l, float a)
        {
            if (l > 1)
            {
                float atmero = l * 0.1f;
                float rad = a * (float)Math.PI / 180;

                PointF P1 = new PointF(
                    atmero * (float)Math.Cos(rad) + P.X,
                    atmero * (float)Math.Sin(rad) + P.Y
                );

                g.FillEllipse(Brushes.Crimson, P1.X, P1.Y, atmero, atmero);
                g.DrawEllipse(Pens.Indigo, P1.X, P1.Y, atmero, atmero);

                this.Spiral(g, P1, l - 1, a + 5);
            }
        }

        private void PitagorasziFa(Graphics g, PointF Pa, PointF Pb, int r)
        {
            PointF Pc = new PointF(
                Pb.X - Pa.Y + Pb.Y,
                Pb.Y - Pb.X + Pa.X
            );

            PointF Pd = new PointF(
                Pa.X - Pa.Y + Pb.Y,
                Pa.Y - Pb.X + Pa.X
            );

            g.DrawPolygon(Pens.Green, new PointF[] { Pa, Pb, Pc, Pd });

            if (r > 0)
            {
                PointF Pe = new PointF(
                    Pd.X + (Pb.X - Pa.X - Pa.Y + Pb.Y) / 2,
                    Pd.Y - (Pb.X - Pa.X + Pa.Y - Pb.Y) / 2
                );

                this.PitagorasziFa(g, Pd, Pe, r - 1);
                this.PitagorasziFa(g, Pe, Pc, r - 1);
            }
        }
    }
}
