namespace DevFreela.API.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() 
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
       
        //Método
        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
