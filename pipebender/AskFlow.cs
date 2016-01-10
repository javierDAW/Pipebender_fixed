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
    public partial class AskFlow : Form
    {
        int type;

        public AskFlow(int type)
        {
            InitializeComponent();
            this.type = type;

            if (type == (int)EnumTypes.Pump) {
                Text = "Pump Flow";
                label1.Text = "Pump flow";
            }
        }

        public NumericUpDown GetFlow {
            get {
                return maxFlowNum;
            }
        }
    }
}
