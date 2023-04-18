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
    public partial class CarForm : Form
    {
        uint pilotId;
        CarService carService = new CarService();
        public CarForm(uint Pilot_ID)
        {
            InitializeComponent();
            pilotId = Pilot_ID;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            CarViewModel model = new CarViewModel();
            model.Pilot_ID = pilotId;
            model.Name = NameBox.Text;
            model.Engine = EngineBox.Text;
            model.Power = PowerBox.Text;
            model.FuelType = FuelBox.Text;
            model.Weight = Convert.ToDouble(WeightBox.Text);
            carService.Create(model);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
