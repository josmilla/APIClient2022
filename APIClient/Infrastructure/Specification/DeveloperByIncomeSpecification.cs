using APIClient.Infrastructure.Data.Entities;

namespace APIClient.Infrastructure.Specification
{
    public class DeveloperByIncomeSpecification : BaseSpecifcation<Asignacion>
    {
        public DeveloperByIncomeSpecification()
        {
            AddOrderByDescending(x => x.MatriculaUsuario);
        }
    }
}