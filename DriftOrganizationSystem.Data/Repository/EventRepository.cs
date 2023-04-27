using DriftOrganizationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Data.Repository
{
    public class EventRepository
    {
        public void AddEvent(Event entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Events.Add(entity);
                _db.SaveChanges();
            }
        }

        public void EditEvent(Event entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Events.Update(entity);
                _db.SaveChanges();
            }
        }

        public void DeleteEvent(int id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                var _event = _db.Events.Where(x => x.Event_ID == id).FirstOrDefault();
                _db.Events.Remove(_event);
                _db.SaveChanges();
            }
        }

        public Event GetById(uint id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                return _db.Events.Where(x => x.Event_ID == id).FirstOrDefault();
            }
        }

        public List<Event> GetEvents()
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                return _db.Events.ToList();
            }
        }
    }
}
