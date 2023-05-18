using DriftOrganizationSystem.Domain.Entity;
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
    public partial class EventForm : Form
    {
        private uint eventId;
        private string mode;

        RegistrationService registrationService = new RegistrationService();
        EventService eventService = new EventService();
        OrganizatorService organizatorService = new OrganizatorService();

        private List<Judge> _localJudges = new List<Judge>();
        private List<Registration> _localRegistrations = new List<Registration>();
        private List<Organizator> _localOrganizators = new List<Organizator>();
        private List<Sponsor> _localSponsors = new List<Sponsor>();

        List<RegistrationViewModel> registrationViewModels;
        List<OrganizatorViewModel> organizatorViewModels;
        List<Sponsor> sponsorViewModels;
        List<Judge> judgeViewModels;

        public EventForm(uint Event_ID, string mode)
        {
            InitializeComponent();
            eventId = Event_ID;
            this.mode = mode;
        }

        private void LoadRegisters()
        {
            registrationViewModels = new List<RegistrationViewModel>();
            foreach (var item in _localRegistrations)
            {
                RegistrationViewModel model = new RegistrationViewModel();
                model.Pilot_Id = item.Pilot_ID;
                var pilot = registrationService.GetPilotById(item.Pilot_ID);
                model.FIO = pilot.Surname + " " + pilot.Name + " " + pilot.Fathername;
                model.Mark = item.Mark;
                model.Place = item.Place;
                registrationViewModels.Add(model);
            }
            PilotDataGrid.DataSource = registrationViewModels;
            PilotDataGrid.Columns[0].Visible = false;
        }

        private void LoadOrganizators()
        {
            organizatorViewModels = new List<OrganizatorViewModel>();
            foreach (var item in _localOrganizators)
            {
                OrganizatorViewModel model = new OrganizatorViewModel();
                model.Organizator_ID = item.Organizator_ID;
                var organizator = organizatorService.GetOrganizatorById(item.Organizator_ID);
                model.Surname = organizator.Surname;
                model.Name = organizator.Name;
                model.FatherName = organizator.FatherName;
                model.Position = organizator.Position;
                organizatorViewModels.Add(model);
            }
        }

        public void LoadEvent()
        {
            if(mode == "edit")
            {
                var model = eventService.GetEventViewModelById(eventId);

                PilotDataGrid.DataSource = model.Registrations;
                PilotDataGrid.Columns[0].Visible = false;
                SponsorDataGrid.DataSource = model.Sponsors;
                SponsorDataGrid.Columns[0].Visible = false;
                JudgeDataGrid.DataSource = model.Judges;
                JudgeDataGrid.Columns[0].Visible = false;
                OrganizatorDataGrid.DataSource = model.Organizators;
                OrganizatorDataGrid.Columns[0].Visible = false;
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void PilotAddButton_Click(object sender, EventArgs e)
        {
            RegistrationForm RF = new RegistrationForm("add", eventId);
            if(RF.ShowDialog() == DialogResult.OK)
            {
                if(!_localRegistrations.Any(x => x.Pilot_ID == RF.Registration.Pilot_ID))
                {
                    _localRegistrations.Add(RF.Registration);
                    LoadRegisters();
                    RF.Close();
                }
                else
                {
                    MessageBox.Show("Данный пилот уже зарегистрирован!");
                    RF.DialogResult = DialogResult.No;
                }
            }
        }

        private void PilotDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _localRegistrations.RemoveAll(x => x.Pilot_ID == Convert.ToUInt32(PilotDataGrid.SelectedRows[0].Cells[0].Value));
            }
            catch
            {
                MessageBox.Show("Список пилотов пуст");
            }
            LoadRegisters();
        }

        private void OrganizatorAddButton_Click(object sender, EventArgs e)
        {
            OrganizatorForm OF = new OrganizatorForm("add", 0);
            if(OF.ShowDialog() == DialogResult.OK)
            {
                _localOrganizators.Add(OF.organizator);
                //LoadOrganizators();
                OF.Close();
            }
        }

        private void OrganizatorDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void JudgeAddButton_Click(object sender, EventArgs e)
        {
            JudgeForm JF = new JudgeForm(0, "add");
            if(JF.ShowDialog() == DialogResult.OK)
            {
                _localJudges.Add(JF.judge);
                
                JF.Close();
            }
        }

        private void JudgeDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void SponsorAddButton_Click(object sender, EventArgs e)
        {
            SponsorForm SF = new SponsorForm(0, "add");
            if(SF.ShowDialog() == DialogResult.OK)
            {
                _localSponsors.Add(SF.sponsor);
                
                SF.Close();
            }
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
