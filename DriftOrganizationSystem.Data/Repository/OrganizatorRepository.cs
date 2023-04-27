using DriftOrganizationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Data.Repository
{
    public class OrganizatorRepository
    {
        public void AddOrg(Organizator entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Organizators.Add(entity);
                _db.SaveChanges();
            }
        }

        public void EditOrg(Organizator entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Organizators.Update(entity);
                _db.SaveChanges();
            }
        }

        public void DeleteOrg(int id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                var organizator = _db.Organizators.Where(x => x.Organizator_ID == id).FirstOrDefault();
                _db.Organizators.Remove(organizator);
                _db.SaveChanges();
            }
        }

        public Organizator GetById(uint id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                return _db.Organizators.Where(x => x.Organizator_ID == id).FirstOrDefault();
            }
        }
    }
}
