using SSSystemGenerator.Classes;
using SSSystemGenerator.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SSSystemGenerator
{
    public partial class BaseMDIContainer : Form
    {
        public BaseMDIContainer()
        {
            InitializeComponent();
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            bool a = true;
            foreach (var item in this.MdiChildren)
            {
                if (item.GetType() == map.GetType())
                {
                    this.ActivateMdiChild(item);
                    map.BringToFront();
                    a = false;
                    break;
                }
            }
            if (a)
            {
                map.MdiParent = this;
                map.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
