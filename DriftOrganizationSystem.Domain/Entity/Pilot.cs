﻿using System.Collections.Generic;

namespace DriftOrganizationSystem.Domain.Entity
{
    public class Pilot
    {
        public uint Pilot_ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fathername { get; set; }
        public int Age { get; set; }

        public List<Car> Cars { get; set; }
        public List <Achievement> Achievements { get; set; }
        public List <Registration> Registrations { get; set; }
    }
}
