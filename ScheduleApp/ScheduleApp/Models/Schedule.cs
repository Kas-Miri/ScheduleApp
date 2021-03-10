using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleApp.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        public int DisciplineID { get; set; }
        [ForeignKey(nameof(DisciplineID))]
        public Discipline Discipline { get; set; }

        public int TimeBeginID { get; set; }
        [ForeignKey(nameof(TimeBeginID))]
        public Time TimeBegin { get; set; }

        public int TimeEndID { get; set; }
        [ForeignKey(nameof(TimeEndID))]
        public Time TimeEnd { get; set; }
    }
}
