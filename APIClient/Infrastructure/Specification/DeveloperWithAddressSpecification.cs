using APIClient.Infrastructure.Data.Entities;

namespace APIClient.Infrastructure.Specification
{
    public class DeveloperWithAddressSpecification : BaseSpecifcation<Asignacion>
    {
        public DeveloperWithAddressSpecification(int idrol) : base(x => x.IdRol == idrol)
        {
            //AddInclude(x => x.Roles);
            //AddInclude(x => x.Aplicativos);
            //AddInclude(x => x.Squads);
        }
    }
}