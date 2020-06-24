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
        private readonly IRepository<Employee> repositoryEmployee;
        private readonly IRepository<Address> repositoryAddress;
        private readonly IRepository<Department> repositoryDepartment;

        public EmployeesServices(
            IRepository<Employee> repositoryEmployee,
            IRepository<Address> repositoryAddress,
            IRepository<Department> repositoryDepartment)
        {
            this.repositoryEmployee = repositoryEmployee;
            this.repositoryAddress = repositoryAddress;
            this.repositoryDepartment = repositoryDepartment;
        }

        public async Task<bool> ExistEmployee(string firstName, string lastName, DateTime birthday)
        {
            var employee = await this.repositoryEmployee.All()
                .AnyAsync(x => x.FirstName == firstName && x.LastName == lastName && x.Birthday == birthday);

            return employee;
        }

        public async Task AddNewEmployee(EmployeesInputViewModel input)
        {
            var currentEmployee = await this.repositoryEmployee.All()
                .FirstOrDefaultAsync(x => x.FirstName == input.FirstName &&
                                          x.LastName == input.LastName &&
                                          x.Birthday == input.Birthday);

            if (currentEmployee != null)
            {
                // Here can return string message for that the same customer is found!
                return;
            }

            currentEmployee = new Employee
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Birthday = input.Birthday,
                Gender = Enum.Parse<Gender>(input.Gender),
            };

            var address = await this.repositoryAddress.All()
                .FirstOrDefaultAsync(x =>
                    x.Street == input.Street && x.HouseNumber == input.HouseNumber && x.ZipCode == input.ZipCode);

            if (address == null)
            {
                address = new Address
                {
                    Street = input.Street,
                    HouseNumber = input.HouseNumber,
                    City = input.City,
                    Country = input.Country,
                    ZipCode = input.ZipCode,
                };

                await this.repositoryAddress.AddAsync(address);
                await this.repositoryAddress.SaveChangesAsync();
            }

            var department = await this.repositoryDepartment.All()
                .FirstOrDefaultAsync(x => x.Name == input.Department);

            if (department == null)
            {
                department = new Department
                {
                    Name = input.Department,
                };

                await this.repositoryDepartment.AddAsync(department);
                await this.repositoryDepartment.SaveChangesAsync();
            }


            currentEmployee.Address = address;
            currentEmployee.Department = department;

            await this.repositoryEmployee.AddAsync(currentEmployee);
            await this.repositoryEmployee.SaveChangesAsync();
        }

        public async Task<ICollection<EmployeeOutputViewModel>> GetAllEmployees()
        {
            var employee = await this.repositoryEmployee.All()
                .To<EmployeeOutputViewModel>().ToListAsync();

            return employee;
        }
    }
}
