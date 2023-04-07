using DriftOrganizationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriftOrganizationSystem.Data.Repository
{
    public class PilotRepository
    {
        public void AddPilot(Pilot entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Pilots.Add(entity);
                _db.SaveChanges();
            }
        }

        public List<Pilot> GetPilots()
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                return _db.Pilots.ToList();
            }
        }
    }
}
