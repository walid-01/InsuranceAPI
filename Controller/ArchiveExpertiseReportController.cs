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
    [Route("/ArchiveExpertiseReport")]
    [ApiController]
    public class ArchiveExpertiseReportController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;


        public ArchiveExpertiseReportController(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> CreateExpertiseReportInArchive([FromBody] ArchiveExpertiseReportCreateRequest expertiseReportRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request Model Structure.");
            }


            String userName = Token.DecodeToken(expertiseReportRequest.token, _configuration["AppSettings:Token"]);
            var expert = await _context.Expert.FirstOrDefaultAsync(e => e.UserName == userName);

            if (expert is null)
            {
                return Unauthorized("token not valid.");
            }

            try
            {
                ArchiveExpertiseReport requestExpertiseReport = expertiseReportRequest.FromArchiveExpertiseReportCreateRequestDto(
                    expert.FirstName + "." + expert.LastName
                );
                _context.ArchiveExpertiseReport.Add(requestExpertiseReport);
                await _context.SaveChangesAsync();

                ArchiveExpertiseReport dbExpertiseReport = await _context.ArchiveExpertiseReport.FindAsync(requestExpertiseReport.ID);
                if (dbExpertiseReport == null)
                {
                    //created expertise report not found in db
                    return StatusCode(500, "Internal Server error.11111");
                }

                foreach (DamagedPartCreateRequest requestDamagedPart in expertiseReportRequest.DamagedParts)
                {
                    DamagedPart damagedPart = requestDamagedPart.FromDamagedPartCreateRequestDto();
                    damagedPart.ArchiveExpertiseReportID = dbExpertiseReport.ID;
                    _context.DamagedPart.Add(damagedPart);
                }

                await _context.SaveChangesAsync();

                return Ok("Expertise Report Created.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Internal Server error.22222");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server error.333333");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetArchiveExpertise()
        {
            try
            {
                var expertise = await _context.ArchiveExpertiseReport.
                Include(e => e.DamagedParts)
                .Select(e => e.ToArchiveExpertisReportResponseDto())
                .ToListAsync();

                return Ok(expertise);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var expertise = await _context.ArchiveExpertiseReport.
                Include(e => e.DamagedParts).
                FirstOrDefaultAsync(expertise => expertise.ID == id);

                if (expertise == null)
                {
                    return NotFound("Not exist.");
                }

                return Ok(expertise.ToArchiveExpertisReportResponseDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> test(int id)
        {
            try
            {
                ServiceOrder? serviceOrderResponses = await _context.ServiceOrder
                                                   .Include(so => so.AssociatedExpert)
                                                   .Include(so => so.VictimInsurance)
                                                   .Include(so => so.AtFaultInsurance)
                                                   .Include(so => so.AssociatedExpert)
                                                   .Include(so => so.ExpertiseReport)
                                                   .ThenInclude(er => er.DamagedParts)
                                                   .FirstOrDefaultAsync(e => e.ExpertiseReport.Id == id);

                return Ok(serviceOrderResponses.ExpertiseReport.FromExpertiseReportCreateToArchiveRequestDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}