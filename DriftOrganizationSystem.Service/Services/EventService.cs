using DriftOrganizationSystem.Data.Repository;
using DriftOrganizationSystem.Domain.Entity;
using DriftOrganizationSystem.Domain.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Service.Services
{
    public class EventService
    {
        EventRepository eventRepository = new EventRepository();
        RegistrationRepository registrationRepository = new RegistrationRepository();
        OrganizatorRepository organizatorRepository = new OrganizatorRepository();
        SponsorRepository sponsorRepository = new SponsorRepository();

        public void Create(EventViewModel model)
        {
            Event _event = new Event()
            {
                EventName = model.Event_Name,
                EventDate = model.Event_Date,
                Sponsors = model.Sponsors,
                Organizators = model.Organizators,
                Judges = model.Judges,
                Registrations = model.Registrations
            };
            eventRepository.AddEvent(_event);
        }

        public List<EventViewModel> GetEvents()
        {
            List<EventViewModel> events = new List<EventViewModel>();

            foreach (var item in eventRepository.GetEvents())
            {
                EventViewModel model = new EventViewModel();
                model.Event_Name = item.EventName;
                model.Event_Date = item.EventDate;
                model.Event_ID = item.Event_ID;
                events.Add(model);
            }

            return events;
        }

        public EventViewModel GetEventViewModelById(uint id)
        {
            EventViewModel model = new EventViewModel();
            Event _event = eventRepository.GetById(id);
            model.Event_ID = _event.Event_ID;
            model.Event_Name = _event.EventName;
            model.Event_Date = _event.EventDate;
            model.Judges = _event.Judges.ToList();
            model.Organizators = _event.Organizators.ToList();
            model.Sponsors = _event.Sponsors.ToList();
            model.Registrations = _event.Registrations.ToList();
            return model;
        }
    }
}
