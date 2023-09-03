namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, string clientName,string freelancerName)
        {
            Id = id;
            Title = title;
            Description = description;
            ClientName = clientName;
            FreelancerName = freelancerName;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
    }
}
