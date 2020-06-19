namespace ProjectCK.Web.ViewModels.Employees
{
    using ProjectCK.Data.Models;
    using ProjectCK.Services.Mapping;

    public class DepartmentOutputViewModel : IMapFrom<Department>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
