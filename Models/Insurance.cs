using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public String Name { get; set; }= String.Empty;
        public String Address { get; set; }= String.Empty;
        public City City { get; set; }
        public required String UserName { get; set; }
        public required String Password { get; set; }
        public required int AgencyCode { get; set; }
        public List<ServiceOrder> ServiceOrdersVictim { get; set; }= new List<ServiceOrder>();
        public List<ServiceOrder> ServiceOrdersAtFault { get; set; }= new List<ServiceOrder>();

    }
}