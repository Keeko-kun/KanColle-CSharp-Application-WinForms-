using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Opacity = 0;
            FadeIn();
        }

        private async void FadeIn()
        {
            while (this.Opacity < 1.0)
            {
                await Task.Delay(20);
                this.Opacity += 0.025;
            }
            this.Opacity = 1;
        }

        private async void FadeOut()
        {
            while (this.Opacity > 0)
            {
                await Task.Delay(20);
                this.Opacity -= 0.025;
            }
            this.Opacity = 0;
            this.Close();
        }

        private void pbQuit_MouseDown(object sender, MouseEventArgs e)
        {
            pbQuit.BackgroundImage = Properties.Resources.Button_Click;
        }

        private void pbQuit_MouseUp(object sender, MouseEventArgs e)
        {
            Rectangle r = new Rectangle(pbQuit.Location, pbQuit.Size);
            if (pbQuit.ClientRectangle.Contains(PointToClient(e.Location)))
            {
                FadeOut();
            }
            pbQuit.BackgroundImage = Properties.Resources.Button;
        }
    }
}
