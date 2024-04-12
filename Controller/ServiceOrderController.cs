using InsuranceAPI.Database;
using InsuranceAPI.Dtos.ServiceOrderDtos;
using InsuranceAPI.Mappers;
using InsuranceAPI.Models;
using InsuranceAPI.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Controller
{
    [Route("/ServiceOrder")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;


        public ServiceOrderController(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<IActionResult> GetServicesOrder([FromHeader] String userToken)
        {
            try
            {
                //get Insurance id from token
                String userName = Token.DecodeToken(userToken, _configuration["AppSettings:Token"]);
                Insurance? selectedInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == userName);
                if (selectedInsurance is not null)
                {
                    var serviceOrderListResponses = await _context.ServiceOrder
                                    .Where(ServiceOrder => ServiceOrder.VictimInsuranceID == selectedInsurance.Id)
                                    .ToListAsync();

                    foreach (var serviceOrderResponse in serviceOrderListResponses)
                    {
                        // Load the associated entities for the current service order
                        var ServiceOrder = await _context.ServiceOrder
                                                        .Include(so => so.AssociatedExpert)
                                                        .Include(so => so.VictimInsurance)
                                                        .Include(so => so.AtFaultInsurance)
                                                        .Include(so => so.ExpertiseReport)
                                                            .ThenInclude(er => er.DamagedParts)
                                                        .FirstOrDefaultAsync(so => so.Id == serviceOrderResponse.Id);

                        // Update the corresponding service order response with the loaded service order
                        if (ServiceOrder != null)
                        {
                            serviceOrderResponse.AssociatedExpert = ServiceOrder.AssociatedExpert;
                            serviceOrderResponse.VictimInsurance = ServiceOrder.VictimInsurance;
                            serviceOrderResponse.AtFaultInsurance = ServiceOrder.AtFaultInsurance;
                            serviceOrderResponse.ExpertiseReport = ServiceOrder.ExpertiseReport;
                        }
                    }


                    return Ok(serviceOrderListResponses.Select(ServiceOrder => ServiceOrder.ToServiceOrderResponseDto()).Reverse());
                }

                //get expert if from token
                Expert? selectedExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == userName);
                if (selectedExpert is not null)
                {
                    var serviceOrderListResponses = await _context.ServiceOrder
                                    .Where(ServiceOrder => ServiceOrder.AssociatedExpertID == selectedExpert.Id)
                                    .ToListAsync();

                    foreach (var serviceOrderResponse in serviceOrderListResponses)
                    {
                        // Load the associated entities for the current service order
                        var ServiceOrder = await _context.ServiceOrder
                                                        .Include(so => so.AssociatedExpert)
                                                        .Include(so => so.VictimInsurance)
                                                        .Include(so => so.AtFaultInsurance)
                                                        .Include(so => so.ExpertiseReport)
                                                            .ThenInclude(er => er.DamagedParts)
                                                        .FirstOrDefaultAsync(so => so.Id == serviceOrderResponse.Id);

                        // Update the corresponding service order response with the loaded service order
                        if (ServiceOrder != null)
                        {
                            serviceOrderResponse.AssociatedExpert = ServiceOrder.AssociatedExpert;
                            serviceOrderResponse.VictimInsurance = ServiceOrder.VictimInsurance;
                            serviceOrderResponse.AtFaultInsurance = ServiceOrder.AtFaultInsurance;
                            serviceOrderResponse.ExpertiseReport = ServiceOrder.ExpertiseReport;
                        }
                    }


                    return Ok(serviceOrderListResponses.Select(ServiceOrder => ServiceOrder.ToServiceOrderResponseDto()));
                }

                return Unauthorized("Invalid token.");

            }
            catch (Exception)
            {
                return StatusCode(500, $"Internal server error.");
            }
        }


        [HttpGet]
        [Route("/ServiceOrderById")]
        public async Task<IActionResult> GetServicesOrderById([FromHeader] String userToken, [FromHeader] int id)
        {
            try
            {
                //get Insurance id from token
                String userName = Token.DecodeToken(userToken, _configuration["AppSettings:Token"]);
                Insurance? selectedInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == userName);
                if (selectedInsurance is not null)
                {
                    ServiceOrder? serviceOrderResponses = await _context.ServiceOrder
                                    .Include(so => so.AssociatedExpert)
                                    .Include(so => so.VictimInsurance)
                                    .Include(so => so.AtFaultInsurance)
                                    .Include(so => so.ExpertiseReport)
                                    .ThenInclude(er => er.DamagedParts)
                                    .FirstOrDefaultAsync(ServiceOrder => ServiceOrder.VictimInsuranceID == selectedInsurance.Id
                                     && ServiceOrder.Id == id);

                    if (serviceOrderResponses is null)
                    {
                        return NotFound("Order not found.");
                    }




                    return Ok(serviceOrderResponses?.ToServiceOrderResponseDto());
                }

                //get expert if from token
                Expert? selectedExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == userName);
                if (selectedExpert is not null)
                {
                    ServiceOrder? serviceOrderResponses = await _context.ServiceOrder
                                    .Include(so => so.AssociatedExpert)
                                    .Include(so => so.VictimInsurance)
                                    .Include(so => so.AtFaultInsurance)
                                    .Include(so => so.ExpertiseReport)
                                    .ThenInclude(er => er.DamagedParts)
                                    .FirstOrDefaultAsync(ServiceOrder => ServiceOrder.VictimInsuranceID == selectedExpert.Id
                                     && ServiceOrder.Id == id);


                    if (serviceOrderResponses is null)
                    {
                        return NotFound("Order not found.");
                    }


                    return Ok(serviceOrderResponses?.ToServiceOrderResponseDto());
                }

                return Unauthorized("Invalid token.");

            }
            catch (Exception)
            {
                return StatusCode(500, $"Internal server error.");
            }
        }


        [HttpPost]
        [Route("/CreateServiceOrder")]
        public async Task<IActionResult> CreateServiceOrder([FromBody] ServiceOrderCreateRequest serviceOrderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad model structure.");
            }

            try
            {
                //get Insurance id from token
                String insuranceUserName = Token.DecodeToken(serviceOrderRequest.VictimInsuranceToken, _configuration["AppSettings:Token"]);
                Insurance? selectedInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == insuranceUserName);
                if (selectedInsurance is null)
                {
                    //insurance user name not found
                    return Unauthorized("Invalid Token.");
                }

                //check selected Expert
                Expert? selectedExpert = await _context.Expert.FindAsync(serviceOrderRequest.AssociatedExpertID);
                if (selectedExpert is null)
                {
                    //expert not found
                    return Unauthorized("Invalid Expert.");
                }
                // add it to db
                _context.ServiceOrder.Add(serviceOrderRequest.FromCreateServiceOrderDto(selectedInsurance.Id));
                _context.SaveChanges();

                return Created();

            }
            catch (Exception)
            {
                return StatusCode(500, $"Internal server error.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServiceOrder([FromBody] ServiceOrderUdateRequest serviceOrderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad model structure.");
            }

            try
            {
                //get Insurance id from token
                String insuranceUserName = Token.DecodeToken(serviceOrderRequest.VictimInsuranceToken, _configuration["AppSettings:Token"]);
                Insurance? selectedInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == insuranceUserName);
                if (selectedInsurance is null)
                {
                    return Unauthorized("Invalid Token.");
                }

                //get Service order from db
                ServiceOrder dbServiceOrder = await _context.ServiceOrder.FindAsync(serviceOrderRequest.Id);
                if (dbServiceOrder is null)
                {
                    //service order not found
                    return Unauthorized("Bad Service order information.");
                }

                //chek if insurance is the owner of this service order
                if (selectedInsurance.Id != dbServiceOrder.VictimInsuranceID)
                {
                    return Unauthorized("User can not update this Service Order.");
                }

                //check selected Expert
                Expert? selectedExpert = await _context.Expert.FindAsync(serviceOrderRequest.AssociatedExpertID);
                if (selectedExpert is null)
                {
                    //expert not found
                    return Unauthorized("Invalid Expert.");
                }

                //check if Service order has Report
                ExpertiseReport ExpertiseReport = await _context.ExpertiseReport.FirstOrDefaultAsync(expReport => expReport.ServiceOrderId == dbServiceOrder.Id);
                if (ExpertiseReport is not null)
                {
                    return Unauthorized("User can not update this service order.");
                }

                // update the service order it to db
                dbServiceOrder.VictimFullName = serviceOrderRequest.VictimFullName;
                dbServiceOrder.VictimPolicyNumber = serviceOrderRequest.VictimPolicyNumber;
                dbServiceOrder.VictimCity = serviceOrderRequest.VictimCity;
                dbServiceOrder.VehicleMakerAndModel = serviceOrderRequest.VehicleMakerAndModel;
                dbServiceOrder.VehicleLicensePlate = serviceOrderRequest.VehicleLicensePlate;
                dbServiceOrder.VehicleType = serviceOrderRequest.VehicleType;
                dbServiceOrder.VehicleSeriesNumber = serviceOrderRequest.VehicleSeriesNumber;
                dbServiceOrder.VehicleGenre = serviceOrderRequest.VehicleGenre;
                dbServiceOrder.VehicleWeight = serviceOrderRequest.VehicleWeight;
                dbServiceOrder.AtFaultFullName = serviceOrderRequest.AtFaultFullName;
                dbServiceOrder.AtFaultPolicyNumber = serviceOrderRequest.AtFaultPolicyNumber;
                dbServiceOrder.AtFaultCity = serviceOrderRequest.AtFaultCity;
                dbServiceOrder.AtFaultInsuranceID = serviceOrderRequest.AtFaultInsuranceID;
                dbServiceOrder.AssociatedExpertID = serviceOrderRequest.AssociatedExpertID;
                _context.SaveChanges();

                return Ok("Service Order updated");

            }
            catch (Exception)
            {
                return StatusCode(500, $"Internal server error.");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteServiceOrder([FromBody] ServiceOrderDeleteRequest serviceOrderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad model structure.");
            }

            try
            {
                //get Insurance id from token
                String insuranceUserName = Token.DecodeToken(serviceOrderRequest.InsuranceToken, _configuration["AppSettings:Token"]);
                Insurance? selectedInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == insuranceUserName);
                if (selectedInsurance is null)
                {
                    return Unauthorized("Invalid Token.");
                }

                //get Service order from db
                ServiceOrder dbServiceOrder = await _context.ServiceOrder.FindAsync(serviceOrderRequest.ServiceOrderId);
                if (dbServiceOrder is null)
                {
                    return Unauthorized("Bad Service order information.");
                }

                //check if user is the owner of Dervice order
                if (dbServiceOrder.VictimInsuranceID != selectedInsurance.Id)
                {
                    return Unauthorized("User can not update this service order.");
                }

                //check if Service order has Report
                ExpertiseReport ExpertiseReport = await _context.ExpertiseReport.FirstOrDefaultAsync(expReport => expReport.ServiceOrderId == dbServiceOrder.Id);
                if (ExpertiseReport is not null)
                {
                    return Unauthorized("User can not update this service order.");
                }

                _context.ServiceOrder.Remove(dbServiceOrder);
                _context.SaveChanges();

                return Ok("Service order deleted.");

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server error.");
            }
        }


    }
}