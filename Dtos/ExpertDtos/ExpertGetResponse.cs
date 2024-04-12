using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.ExpertDtos
{
    public class ExpertGetResponse
    {
        public required String FirstName { get; set; }
        public String Role { get; set; } = "expert";
        public required String LastName { get; set; }
        public required String Address { get; set; } = String.Empty;
        public required String PhoneNumber { get; set; }
        public required City City { get; set; }
    }
}