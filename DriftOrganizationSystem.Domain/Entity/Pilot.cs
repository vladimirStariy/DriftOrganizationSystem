namespace DriftOrganizationSystem.Domain.Entity
{
    public class Pilot
    {
        public uint Pilot_ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fathername { get; set; }
        public int Age { get; set; }

        public virtual Car Car { get; set; }
        public virtual Achievement Achievement { get; set; }
        //public virtual Registration Registration { get; set; }
    }
}
