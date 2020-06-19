namespace ProjectCK.Web.ViewModels.Employees
{
    using ProjectCK.Data.Models;
    using ProjectCK.Services.Mapping;

    public class EmployeeOutputViewModel : IMapFrom<Employee>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public AddressOutputViewModel Address { get; set; }

        public DepartmentOutputViewModel Department { get; set; }
    }
}
