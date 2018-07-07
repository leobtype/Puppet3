using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puppet3
{
    public partial class CustomForm : Form
    {
        private List<TrackBar> soundTrackBars = new List<TrackBar>();
        private void SoundTrackBarsInit()
        {
            List<TrackBar> list = new List<TrackBar>() {
                trackBar1, trackBar2, trackBar3, trackBar4, trackBar5,
                trackBar6, trackBar7, trackBar8, trackBar9, trackBar10
            };
            soundTrackBars.AddRange(list);
        }
    }
}
