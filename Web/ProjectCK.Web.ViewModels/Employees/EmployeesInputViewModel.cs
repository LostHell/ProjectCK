using System;

namespace ProjectCK.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class EmployeesInputViewModel
    {
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(15, ErrorMessage = "First name must be between 3 and 15 characters long!", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(20, ErrorMessage = "Last name must be between 4 and 15 characters long!", MinimumLength = 4)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birthday is required!")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Street is required!")]
        [StringLength(30, ErrorMessage = "Address must be between 5 and 30 characters long!", MinimumLength = 5)]
        public string Street { get; set; }

        [Required(ErrorMessage = "House number is required!")]
        [RegularExpression(@"^[0-9]{3}[a-z]{0,1}$", ErrorMessage = "House number must be valid following (112 or 112a)!")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "City is required!")]
        [StringLength(30, ErrorMessage = "City must be between 5 and 30 characters long!", MinimumLength = 5)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required!")]
        [StringLength(30, ErrorMessage = "Country must be between 4 and 30 characters long!", MinimumLength = 4)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zip Code is required!")]
        [RegularExpression(@"^[0-9]{4,5}$", ErrorMessage = "Zip Code must be valid with 4 or 5 digit!")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Department is required!")]
        [StringLength(40, ErrorMessage = "Department must be between 4 and 40 characters long!", MinimumLength = 4)]
        public string Department { get; set; }
    }
}
