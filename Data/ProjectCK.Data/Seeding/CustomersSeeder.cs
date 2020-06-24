namespace ProjectCK.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectCK.Data.Models;

    public class CustomersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Employees.AnyAsync())
            {
                return;
            }

            var addresses = new List<(string Id, string Street, string HousNumber, string City, string Country, string ZipCode)>
            {
                (
                "1",
                "Friedrich Str.",
                "111",
                "Berlin",
                "Germany",
                "10117"),
                (
                "2",
                "Friedrich Str.",
                "12",
                "Hesen",
                "Germany",
                "15000"),
                (
                "3",
                "Hamburger Str.",
                "111a",
                "Hamburg",
                "Germany",
                "10117"),
                (
                "4",
                "Saint Kiril Str.",
                "212",
                "Sofiya",
                "Bulgaria",
                "10117"),
            };

            var departments = new List<(string Id, string Name)>
            {
                (
                "1",
                "QA"),
                (
                "2",
                "Marketing"),
                (
                "3",
                "Logistic"),
                (
                "4",
                "IT"),
            };

            var employees = new List<(string FirstName, string LastName, DateTime Birthday, string Gender)>
            {
                (
                "Enes",
                "Karadzhov",
                DateTime.Parse("01.01.1990"),
                "Male"),
                (
                "Luis",
                "Matias",
                DateTime.Parse("01.01.1991"),
                "Male"),
                (
                "Linda",
                "Matias",
                DateTime.Parse("01.01.1967"), 
                "Female"),
                (
                "Gema",
                "Theas",
                DateTime.Parse("01.01.1976"), 
                "Female"),
            };

            foreach (var address in addresses)
            {
                await dbContext.Addresses.AddAsync(new Address
                {
                    Id = address.Id,
                    Street = address.Street,
                    HouseNumber = address.HousNumber,
                    City = address.City,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                });
            }

            foreach (var department in departments)
            {
                await dbContext.Departments.AddAsync(new Department
                {
                    Id = department.Id,
                    Name = department.Name,
                });
            }

            int count = 1;

            foreach (var employee in employees)
            {
                await dbContext.Employees.AddAsync(new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Birthday = employee.Birthday,
                    Gender = Enum.Parse<Gender>(employee.Gender),
                    AddressId = count.ToString(),
                    DepartmentId = count.ToString(),
                });

                count++;
            }
        }
    }
}
