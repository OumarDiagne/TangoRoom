namespace TangoRoom.Server.Models
{

    public class Planning
    {

        public int IdPlanning { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Marathon> ListeMarathons { get; set; } = [];
    }
}