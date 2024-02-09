using SIMp.Classes;
using SSSystemGenerator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMp.Forms
{
    public partial class SystemForm : Form
    {

        public Systems systemInCache { get; set; }

        public void inputSystem(Systems system)
        {
            this.systemInCache = system;
        }

        public SystemForm()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_SystemName.Text != "")
            {
                SystemData sd = JsonHelper.getSystemData(tb_SystemName.Text);

                if (sd == null) MessageBox.Show("error sd is null");

                Statics.systemDataList.FirstOrDefault(sydli => sydli == sd).ID = systemInCache.ID;

                Statics.systemList.FirstOrDefault(sysl => sysl.ID == systemInCache.ID).systemColor = Statics.colorMap[sd.Status];

                Statics.Map.RefreshPanel();

            }
        }
    }
}
