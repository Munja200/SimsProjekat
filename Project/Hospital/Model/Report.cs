namespace Hospital.Model
{
    public class Report
    {
        public bool Written { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public Report(bool written, string description, int id)
        {
            Written = written;
            Description = description;
            Id = id;

        }

        public Report()
        {
        }
    }
}
