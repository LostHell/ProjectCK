namespace ProjectCK.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        public Department()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
