namespace DrumSiteApi.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public int Time { get; set; }

        public int DayId { get; set; }
        public virtual Day Day { get; set; }
    }
}
