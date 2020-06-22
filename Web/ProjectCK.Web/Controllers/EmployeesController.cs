namespace ProjectCK.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ProjectCK.Services.Data.EmployeesServices;
    using ProjectCK.Web.ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IEmployeesServices employeesServices;

        public EmployeesController(IEmployeesServices employeesServices)
        {
            this.employeesServices = employeesServices;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeesInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Gender != "Male" && input.Gender != "Female")
            {
                this.ModelState.AddModelError(string.Empty, "Sorry, gender input type is wrong!");
                return this.View(input);
            }

            var existEmployee = await this.employeesServices
                .ExistEmployee(input.FirstName, input.LastName, input.Birthday);

            if (existEmployee == true)
            {
                this.ModelState.AddModelError(string.Empty, "Sorry, customer is already exists!");
                return this.View(input);
            }

            await this.employeesServices.AddNewEmployee(input);
            return this.RedirectToAction();
        }

        public async Task<IActionResult> AllEmployees()
        {
            var employee = await this.employeesServices.GetAllEmployees();

            return this.View(employee);
        }
    }
}
