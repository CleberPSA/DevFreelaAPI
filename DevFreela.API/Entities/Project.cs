using DevFreela.API.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;

namespace DevFreela.API.Entities
{
    public class Project : BaseEntity
    {
        protected Project() { }
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost) : base()
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            Status = ProjectStatusEnum.Created;
            Comments = [];
        }

        public string Title { get; private set; }
        public string Description { get; private set; }

        //Propriedade de Navegação
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        //Propriedade de Navegação
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }

        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }

        //Lista
        public List<ProjectComment> Comments { get; private set; }


        //Métodos
        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgess || Status == ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgess;
                StartedAt = DateTime.Now;
            }
        }

        public void Complete()
        {
            if (Status == ProjectStatusEnum.PaymentPending || Status == ProjectStatusEnum.InProgess)
            {
                Status = ProjectStatusEnum.Completed;
                CompletedAt = DateTime.Now;
            }
        }

        public void SetPaymentPending()
        {
            if (Status == ProjectStatusEnum.InProgess)
            {
                Status = ProjectStatusEnum.PaymentPending;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
