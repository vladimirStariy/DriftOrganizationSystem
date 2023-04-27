using DriftOrganizationSystem.Domain.Entity;
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
    public partial class EventForm : Form
    {
        public uint eventId;
        public string mode;

        public List<Judge> _localJudges;
        public List<Registration> _localRegistrations;
        public List<Organizator> _localOrganizators;
        public List<Sponsor> _localSponsors;

        public EventForm(uint Event_ID, string mode)
        {
            InitializeComponent();
            eventId = Event_ID;
            this.mode = mode;
        }

        public void LoadEvent()
        {
            EventService eventService = new EventService();
            var model = eventService.GetEventViewModelById(eventId);

            PilotDataGrid.DataSource = model.Registrations;
            SponsorDataGrid.DataSource = model.Sponsors;
            JudgeDataGrid.DataSource = model.Judges;
            OrganizatorDataGrid.DataSource = model.Organizators;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {

        }

        private void PilotAddButton_Click(object sender, EventArgs e)
        {

        }

        private void PilotDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void OrganizatorAddButton_Click(object sender, EventArgs e)
        {

        }

        private void OrganizatorDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void JudgeAddButton_Click(object sender, EventArgs e)
        {

        }

        private void JudgeDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void SponsorAddButton_Click(object sender, EventArgs e)
        {

        }

        private void SponsorDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            if(mode == "edit")
            {

            }
        }
    }
}
