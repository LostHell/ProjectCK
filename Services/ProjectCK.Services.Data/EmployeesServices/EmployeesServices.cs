namespace ProjectCK.Services.Data.EmployeesServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectCK.Data.Common.Repositories;
    using ProjectCK.Data.Models;
    using ProjectCK.Services.Mapping;
    using ProjectCK.Web.ViewModels.Employees;

    public class EmployeesServices : IEmployeesServices
    {
        private readonly IRepository<Employee> repositoryCustomer;
        private readonly IRepository<Address> repositoryAddress;
        private readonly IRepository<Department> repositoryDepartment;

        public EmployeesServices(
            IRepository<Employee> repositoryCustomer,
            IRepository<Address> repositoryAddress,
            IRepository<Department> repositoryDepartment)
        {
            this.repositoryCustomer = repositoryCustomer;
            this.repositoryAddress = repositoryAddress;
            this.repositoryDepartment = repositoryDepartment;
        }

        public async Task<bool> ExistEmployee(string firstName, string lastName, string birthday)
        {
            var customer = await this.repositoryCustomer.All()
                .AnyAsync(x => x.FirstName == firstName && x.LastName == lastName && x.Birthday == birthday);

            return customer;
        }

        public async Task AddNewCustomer(EmployeesInputViewModel input)
        {
            var currentCustomer = await this.repositoryCustomer.All()
                .FirstOrDefaultAsync(x => x.FirstName == input.FirstName &&
                x.LastName == input.LastName &&
                x.Birthday == input.Birthday);

            if (currentCustomer != null)
            {
                // Here can return string message for that the same customer is found!
                return;
            }

            currentCustomer = new Employee
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Birthday = input.Birthday,
                Gender = Enum.Parse<Gender>(input.Gender),
            };

            var address = new Address
            {
                Street = input.Street,
                HouseNumber = input.HouseNumber,
                City = input.City,
                Country = input.Country,
                ZipCode = input.ZipCode,
            };

            var department = new Department
            {
                Name = input.Department,
            };

            currentCustomer.Address = address;
            currentCustomer.Department = department;

            await this.repositoryAddress.AddAsync(address);
            await this.repositoryAddress.SaveChangesAsync();

            await this.repositoryDepartment.AddAsync(department);
            await this.repositoryDepartment.SaveChangesAsync();

            await this.repositoryCustomer.AddAsync(currentCustomer);
            await this.repositoryCustomer.SaveChangesAsync();
        }

        public async Task<ICollection<EmployeeOutputViewModel>> GetAllEmployees()
        {
            var customers = await this.repositoryCustomer.All().To<EmployeeOutputViewModel>().ToListAsync();

            return customers;
        }
    }
}
