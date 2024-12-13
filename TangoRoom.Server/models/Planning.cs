namespace TangoRoom.Server.models
{

    public class Planning
    {

        public int IdPlanning { get; set; }
        public required string Name { get; set; }
        public List<Marathon> ListeMarathons { get; set; } = [];
    }
}