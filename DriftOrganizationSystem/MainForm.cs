using DriftOrganizationSystem.Service.Services;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriftOrganizationSystem.View
{
    public partial class MainForm : Form
    {
        PilotService pilotService = new PilotService();
        int checker = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PilotGrid.DataSource = pilotService.GetPilots();
            PilotGrid.Columns[0].Visible = false;

            AutoGrid.DataSource = pilotService.GetPilotCars(Convert.ToInt32(PilotGrid.Rows[0].Cells[0].Value));
            AutoGrid.Columns[0].Visible = false;
            AutoGrid.Columns[1].Visible = false;
            checker = 1;
        }

        private void PilotButton_Click(object sender, EventArgs e)
        {

        }

        private void PilotAddButton_Click(object sender, EventArgs e)
        {
            PilotForm PF = new PilotForm();
            if(PF.ShowDialog() == DialogResult.OK)
            {
                PilotGrid.DataSource = pilotService.GetPilots();           
            }
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CarForm PF = new CarForm(Convert.ToUInt32(PilotGrid.SelectedRows[0].Cells[0].Value));
            if (PF.ShowDialog() == DialogResult.OK)
            {
                AutoGrid.DataSource = pilotService.GetPilotCars(Convert.ToInt32(PilotGrid.SelectedRows[0].Cells[0].Value));
            }
        }

        private void PilotGrid_SelectionChanged(object sender, EventArgs e)
        {
            if(checker == 1)
                AutoGrid.DataSource = pilotService.GetPilotCars(Convert.ToInt32(PilotGrid.SelectedRows[0].Cells[0].Value));
        }
    }
}
