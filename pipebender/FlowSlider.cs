using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    public partial class FlowSlider : Form
    {
        private int percentage;

        public FlowSlider(int percentage)
        {
            InitializeComponent();

            this.percentage = percentage;

            flowLabel.Text = percentage.ToString();

            flowTrack.Value = percentage;
        }

        public TrackBar TrackSlider
        {
            get
            {
                return flowTrack;
            }

            set
            {
                flowTrack = value;
            }
        }

        private void ChangeFlowLabel(object sender, EventArgs e)
        {
            flowLabel.Text = flowTrack.Value.ToString();
        }
    }
}
