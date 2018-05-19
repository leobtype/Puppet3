using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Puppet3
{
    public partial class MascotForm : Form
    {
        private void SetMouseEvent(PictureBox pictureBox)
        {
            pictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            pictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseButtonPressed)
            {
                Point newLocation = new Point();
                newLocation.X = Location.X + e.Location.X - locationBeforeMouseDown.X;
                newLocation.Y = Location.Y + e.Location.Y - locationBeforeMouseDown.Y;
                Location = newLocation;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseButtonPressed = false;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            locationBeforeMouseDown = e.Location;
            mouseButtonPressed = true;
        }
        
        private Point locationBeforeMouseDown;
        private bool mouseButtonPressed = false;
    }
}