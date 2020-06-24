namespace ProjectCK.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
