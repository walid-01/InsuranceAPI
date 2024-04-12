using InsuranceAPI.Database;
using InsuranceAPI.Dtos.ExpertDtos;
using InsuranceAPI.Mappers;
using InsuranceAPI.Models;
using InsuranceAPI.Models.Enums;
using InsuranceAPI.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Controller
{

    [Route("/Expert")]
    [ApiController]
    public class ExpertController : ControllerBase
    {

        private readonly ApplicationDBContext _context;

        private readonly IConfiguration _configuration;


        public ExpertController(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }


        [HttpGet]
        [Route("/expert")]
        public async Task<IActionResult> GetExpertByToken([FromHeader] String token)
        {
            String? reqUserName = Token.DecodeToken(token, _configuration["AppSettings:Token"]);
            if (reqUserName is null)
            {
                //can't decode token
                return Unauthorized("Invalid Token");
            }

            Expert? dbExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == reqUserName);
            if (dbExpert is null)
            {
                //user name not found
                return Unauthorized("Invalid Token");
            }

            //login successfully
            return Ok(dbExpert.ToGetResponseExpertDto(token));
        }



        [HttpGet]
        [Route("/Experts")]
        public async Task<IActionResult> GetExpertByCity()
        {
            try
            {
                var expertListResponses = await _context.Expert
                                   .Select(expert => expert.ToExpertListResponseDto())
                                   .ToListAsync();

                //return expert list
                return Ok(expertListResponses);
            }
            catch (Exception e)
            {
                //server error
                return StatusCode(500, $"Internal server error.{e}");
            }
        }



        [HttpPost]
        [Route("/Expert-Login")]
        public async Task<IActionResult> Login([FromBody] ExpertLoginRequest expertRequest)
        {
            //get item from db
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request structure.");
            }
            try
            {
                //check if username  exist
                Expert? dbExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == expertRequest.UserName);
                if (dbExpert is null)
                {
                    //user name not found
                    return Unauthorized("Bad user Information.");
                }


                //get token user
                if (BCrypt.Net.BCrypt.Verify(expertRequest.Password, dbExpert.Password))
                {
                    string token = Token.CreateToken(dbExpert, _configuration["AppSettings:Token"]);
                    ExpertResponse expertResponseDto = dbExpert.ToResponseExpertDto(token);
                    return Ok(expertResponseDto);
                }
                else
                {
                    //wrang password
                    return Unauthorized("Bad user Information.");
                }


            }
            catch (Exception)
            {
                //server error
                return StatusCode(500, $"Internal server error.");
            }

        }



        [HttpPost]
        [Route("/Expert-Register")]
        public async Task<IActionResult> CreateExpert([FromBody] ExpertCreateRequest expertRequest)
        {
            //validate request
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request structure.");
            }
            try
            {
                //convert request to Db model
                Expert expertModel = expertRequest.FromCreateRequestDto();

                //check if username already used
                Insurance? dbInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == expertRequest.UserName);

                if (dbInsurance is not null)
                {
                    // user name used by insurance
                    return Conflict("Username can not be used.");
                }


                Expert? dbExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == expertModel.UserName);

                //create new user
                if (dbExpert is null)
                {

                    _context.Expert.Add(expertModel);
                    _context.SaveChanges();
                    //expert created
                    return Created();
                }
                //not allowed to use user name
                else
                {
                    //user name used by expert
                    return Conflict("UserName can not be used.");
                }


            }
            catch (Exception)
            {
                //server error
                return StatusCode(500, $"Internal server error.");
            }


        }



        [HttpPut]
        public async Task<IActionResult> UpdateExpert([FromBody] ExpertUpdateRequest expertRequest)
        {
            // check request Structure
            if (!ModelState.IsValid)
            {

                return BadRequest("Invalid Structure");
            }
            //decode token to get username
            String? reqUserName = Token.DecodeToken(expertRequest.Token, _configuration["AppSettings:Token"]);
            if (reqUserName is null)
            {
                //user name not found
                return Unauthorized("Invalid Token.");
            }
            //get Expert object from db by token.username
            Expert? dbExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == reqUserName);
            if (dbExpert is null)
            {
                //expert user name not found in db
                return Unauthorized("Bad user information.");
            }
            //verify if new username used by other user
            Expert? existExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == reqUserName);
            if (dbExpert is null || dbExpert.Id == existExpert.Id)
            {

                if (BCrypt.Net.BCrypt.Verify(expertRequest.CurrentPassword, dbExpert.Password))
                {

                    dbExpert.FirstName = expertRequest.FirstName;
                    dbExpert.LastName = expertRequest.LastName;
                    dbExpert.PhoneNumber = expertRequest.PhoneNumber;
                    if (expertRequest.NewPassword is not null)
                    {
                        dbExpert.Password = BCrypt.Net.BCrypt.HashPassword(expertRequest.NewPassword);
                    }
                    await _context.SaveChangesAsync();

                    return Ok("Expert Updated.");

                }
                else
                {
                    //wrong password
                    return Unauthorized("Confirmation password incorrect.");
                }

            }
            else
            {
                //user name can not be used
                return NotFound("User Name can t be used.");
            }

        }


    }
}