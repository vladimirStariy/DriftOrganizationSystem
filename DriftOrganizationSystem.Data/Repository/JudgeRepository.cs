using DriftOrganizationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Data.Repository
{
    public class JudgeRepository
    {
        public void AddJudge(Judge entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Judges.Add(entity);
                _db.SaveChanges();
            }
        }

        public void EditJudge(Judge entity)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                _db.Judges.Update(entity);
                _db.SaveChanges();
            }
        }

        public void DeleteJudge(int id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                var judge = _db.Judges.Where(x => x.Judge_ID == id).FirstOrDefault();
                _db.Judges.Remove(judge);
                _db.SaveChanges();
            }
        }

        public Judge GetById(uint id)
        {
            using (DriftDbContext _db = new DriftDbContext())
            {
                return _db.Judges.Where(x => x.Judge_ID == id).FirstOrDefault();
            }
        }
    }
}
