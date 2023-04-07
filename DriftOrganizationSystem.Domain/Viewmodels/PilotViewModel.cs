using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftOrganizationSystem.Domain.Viewmodels
{
    public class PilotViewModel
    {
        public uint Pilot_ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fathername { get; set; }
        public int Age { get; set; }
    }
}
