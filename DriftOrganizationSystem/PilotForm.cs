using DriftOrganizationSystem.Domain.Viewmodels;
using DriftOrganizationSystem.Service.Services;
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
    public partial class PilotForm : Form
    {
        PilotService pilotService = new PilotService();

        public PilotForm()
        {
            InitializeComponent();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            PilotViewModel pilotViewModel = new PilotViewModel();
            pilotViewModel.Name = NameBox.Text;
            pilotViewModel.Surname = SurnameBox.Text;
            pilotViewModel.Fathername = FatherNameBox.Text;
            pilotViewModel.Age = Convert.ToInt32(AgeBox.Text);
            pilotService.Create(pilotViewModel);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
