using DriftOrganizationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Data.Repository
{
    public class SponsorRepository
    {
        public void AddSponsor(Sponsor entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Sponsors.Add(entity);
                _db.SaveChanges();
            }
        }

        public void EditSponsor(Sponsor entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Sponsors.Update(entity);
                _db.SaveChanges();
            }
        }

        public void DeleteSponsor(int id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                var sponsor = _db.Sponsors.Where(x => x.Sponsor_ID == id).FirstOrDefault();
                _db.Sponsors.Remove(sponsor);
                _db.SaveChanges();
            }
        }

        public Sponsor GetById(uint id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                return _db.Sponsors.Where(x => x.Sponsor_ID == id).FirstOrDefault();
            }
        }
    }
}
