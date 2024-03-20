using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Models
{
    public class Expert
    {
        public int Id { get; set; }
        public required String FirstName { get; set; }
        public required String LastName { get; set; }
        public required String PhoneNumber { get; set; }
        public required String Address { get; set; }= String.Empty;
        public required City City { get; set; }
        public required String UserName { get; set; }
        public required String Password { get; set; }
        public List<ServiceOrder> ServiceOrders { get; set; }= new List<ServiceOrder>();
    }
}