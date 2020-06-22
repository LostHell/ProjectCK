namespace ProjectCK.Services.Data.EmployeesServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectCK.Web.ViewModels.Employees;

    public interface IEmployeesServices
    {
        Task<bool> ExistEmployee(string firstName, string lastName, string birthday);

        Task AddNewEmployee(EmployeesInputViewModel input);

        Task<ICollection<EmployeeOutputViewModel>> GetAllEmployees();
    }
}
