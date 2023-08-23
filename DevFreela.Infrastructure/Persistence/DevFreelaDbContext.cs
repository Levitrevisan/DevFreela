using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("App Delivery de marretas","minha descrição",1,1,10000),
                new Project("App Delivery de salames", "minha descrição", 1, 1, 20000),
                new Project("App Delivery de alicates", "minha descrição", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Levi Trevisan","levi@elysiso.com",new DateTime(1995,01,11)),
                new User("Alphonsus Guimaraes","alfonsos@elysiso.com",new DateTime(1992,01,11)),
                new User("Alphonsus dias","alfonsos@elysiso.com",new DateTime(1993,01,11))
            };

            Skills = new List<Skill>
            {
                new Skill("bonito"),
                new Skill("sql")
            };

            ProjectComments = new List<ProjectComment>
            {
                new ProjectComment("Olha que legal", 1, 1)
            };

        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }

    }
}
