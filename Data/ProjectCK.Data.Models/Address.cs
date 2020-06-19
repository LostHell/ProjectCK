namespace ProjectCK.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        [Required]
        [MaxLength(5)]
        public string HouseNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        [Required]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
