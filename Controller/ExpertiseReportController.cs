using InsuranceAPI.Database;
using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Dtos.ExpertiseReportDtos;
using InsuranceAPI.Mappers;
using InsuranceAPI.Models;
using InsuranceAPI.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Controller
{
    [Route("/ExpertiseReport")]
    [ApiController]
    public class ExpertiseReportController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;


        public ExpertiseReportController(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> CreateExpertiseReport([FromBody] ExpertiseReportCreateRequest expertiseReportRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request Model Structure.");
            }

            ServiceOrder dbServiceOrder = await _context.ServiceOrder.FindAsync(expertiseReportRequest.ServiceOrderId);
            if (dbServiceOrder is null)
            {
                //service order not found in db
                return Unauthorized("Invalid Service Order.");
            }

            try
            {
                ExpertiseReport requestExpertiseReport = expertiseReportRequest.FromExpertiseReportCreateRequestDto();
                _context.ExpertiseReport.Add(requestExpertiseReport);
                await _context.SaveChangesAsync();

                ExpertiseReport dbExpertiseReport = await _context.ExpertiseReport.FirstOrDefaultAsync(i => i.ServiceOrderId == expertiseReportRequest.ServiceOrderId);
                if (dbExpertiseReport == null)
                {
                    //created expertise report not found in db
                    return StatusCode(500, "Internal Server error.");
                }

                foreach (DamagedPartCreateRequest requestDamagedPart in expertiseReportRequest.DamagedParts)
                {
                    DamagedPart damagedPart = requestDamagedPart.FromDamagedPartCreateRequestDto();
                    damagedPart.ExpertiseReportID = dbExpertiseReport.Id;
                    _context.DamagedPart.Add(damagedPart);
                }

                await _context.SaveChangesAsync();

                return Ok("Expertise Report Created.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Internal Server error.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server error.");
            }
        }

        [HttpPut]
        [Route("/Accept")]
        public async Task<IActionResult> AcceptExpertiseReport([FromBody] ExpertiseReportAcceptRequest expertiseReportRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request Model Structure.");
            }

            ExpertiseReport dbExpertiseReport = await _context.ExpertiseReport.FindAsync(expertiseReportRequest.ExpertiseReportID);
            if (dbExpertiseReport is null)
            {
                //expertise report not found
                return Unauthorized("Invalid Expertise Report.");
            }

            ServiceOrder dbServiceOrder = await _context.ServiceOrder.FindAsync(dbExpertiseReport.ServiceOrderId);
            if (dbServiceOrder is null)
            {
                //service order not found
                return StatusCode(500, "Invalid Service Order.");
            }

            String insuranceUserName = Token.DecodeToken(expertiseReportRequest.InsuranceToken, _configuration["AppSettings:Token"]);

            Insurance dbInsurance = await _context.Insurance.FirstOrDefaultAsync(ins => ins.UserName == insuranceUserName);
            if (dbInsurance is null)
            {
                //insurance not found
                return Unauthorized("Invalid Insurance Token.");
            }

            if (dbInsurance.Id != dbServiceOrder.VictimInsuranceID)
            {
                //order service .id not same as request.token.id
                return Unauthorized("User can not accept this expertise report.");
            }

            try
            {
                if (dbExpertiseReport.State != Models.Enums.ExpertiseReportState.Waiting)
                {
                    return Unauthorized("Expertise report already accepted.");
                }
                dbExpertiseReport.State = Models.Enums.ExpertiseReportState.Accepted;
                await _context.SaveChangesAsync();

                return Ok("Expertise report accepted.");
            }
            catch (Exception)
            {
                //server error
                return StatusCode(500, "Internal Server error.");
            }
        }


        [HttpPut]
        [Route("/Reject")]
        public async Task<IActionResult> RejectExpertiseReport([FromBody] ExpertiseReportAcceptRequest expertiseReportRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request Model Structure.");
            }

            ExpertiseReport dbExpertiseReport = await _context.ExpertiseReport.FindAsync(expertiseReportRequest.ExpertiseReportID);
            if (dbExpertiseReport is null)
            {
                //expertise report not found
                return Unauthorized("Invalid Expertise Report.");
            }

            ServiceOrder dbServiceOrder = await _context.ServiceOrder.FindAsync(dbExpertiseReport.ServiceOrderId);
            if (dbServiceOrder is null)
            {
                //service order not found
                return StatusCode(500, "Invalid Service Order.");
            }

            String insuranceUserName = Token.DecodeToken(expertiseReportRequest.InsuranceToken, _configuration["AppSettings:Token"]);

            Insurance dbInsurance = await _context.Insurance.FirstOrDefaultAsync(ins => ins.UserName == insuranceUserName);
            if (dbInsurance is null)
            {
                //insurance not found
                return Unauthorized("Invalid Insurance Token.");
            }

            if (dbInsurance.Id != dbServiceOrder.VictimInsuranceID)
            {
                //order service .id not same as request.token.id
                return Unauthorized("User can not accept this expertise report.");
            }

            try
            {
                if (dbExpertiseReport.State != Models.Enums.ExpertiseReportState.Waiting)
                {
                    return Unauthorized("Expertise report already accepted.");
                }

                dbExpertiseReport.State = Models.Enums.ExpertiseReportState.Waiting_Appeal;
                await _context.SaveChangesAsync();

                return Ok("Expertise report accepted.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server error.");
            }
        }

    }
}