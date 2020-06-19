namespace ProjectCK.Web.ViewModels.Employees
{
    using ProjectCK.Data.Models;
    using ProjectCK.Services.Mapping;

    public class AddressOutputViewModel : IMapFrom<Address>
    {
        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}
