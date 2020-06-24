namespace ProjectCK.Services.Data.EmployeesServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectCK.Web.ViewModels.Employees;

    public interface IEmployeesServices
    {
        Task<bool> ExistEmployee(string firstName, string lastName, DateTime birthday);

        Task AddNewEmployee(EmployeesInputViewModel input);

        Task<ICollection<EmployeeOutputViewModel>> GetAllEmployees();
    }
}
