namespace DevFreela.API.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate) : base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;

            Skills = []; //Lista vazia []
            OwnedProjects = []; //Lista vazia []
            FreelanceProjects = []; //Lista vazia []
            Comments = []; //Lista vazia []
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

        //Relacionamento das tabelas
        public List<UserSkill> Skills { get; private set; }
        public List <Project> OwnedProjects { get; private set; }
        public List <Project> FreelanceProjects { get; private set; }
        public List <ProjectComment> Comments { get; private set; }
    }
}
