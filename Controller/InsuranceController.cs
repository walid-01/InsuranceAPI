using InsuranceAPI.Database;
using InsuranceAPI.Dtos.InsuranceDtos;
using InsuranceAPI.Mappers;
using InsuranceAPI.Models;
using InsuranceAPI.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace cars.Controller
{
    [Route("Insurance")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        private readonly IConfiguration _configuration;


        public InsuranceController(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }


        [HttpGet]
        [Route("/Insurance")]
        public async Task<IActionResult> GetInsuranceByToken([FromHeader] String token)
        {
            String? reqUserName = Token.DecodeToken(token, _configuration["AppSettings:Token"]);
            if (reqUserName is null)
            {
                //can't decode token
                return Unauthorized("Invalid Token");
            }

            Insurance? dbInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == reqUserName);
            if (dbInsurance is null)
            {
                //user name not in db
                return Unauthorized("Invalid Token");
            }

            return Ok(dbInsurance.ToResponseInsuranceDto(token));
        }

        [HttpGet]
        [Route("/InsurancesList")]
        public IActionResult GetInsurancesList()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                var insurance = _context.Insurance.ToList().Select(ins => ins.ToInsurnaceListResponceDto());

                return Ok(insurance);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }



        [HttpPost]
        [Route("/Insurance-login")]
        public async Task<IActionResult> Login([FromBody] InsuranceLoginRequestDto insuranceRequest)
        {
            //get item from db
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid request structure.");
            }
            try
            {
                //check if username  exist
                Insurance? dbInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == insuranceRequest.UserName);

                //create new user
                if (dbInsurance is null)
                {
                    //user name not found
                    return Unauthorized("Bad user Information.");
                }
                //get token user
                else
                {
                    if (BCrypt.Net.BCrypt.Verify(insuranceRequest.Password, dbInsurance.Password))
                    {
                        string token = Token.CreateToken(dbInsurance, _configuration["AppSettings:Token"]);
                        InsuranceResponseDto insuranceResponseDto = dbInsurance.ToResponseInsuranceDto(token);
                        return Ok(insuranceResponseDto);
                    }
                    else
                    {
                        //wrong password
                        return Unauthorized("Bad user Information.");
                    }
                }

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }



        [HttpPost]
        [Route("/Insurance-Register")]
        public async Task<IActionResult> CreateInsurance([FromBody] InsuranceCreateRequestDto insuranceRequest)
        {
            //validate request
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request structure.");
            }
            try
            {
                //convert request to Db model
                Insurance insuranceModel = insuranceRequest.FromCreateRequestDto();
                //check if username already used
                Expert? dbExpert = await _context.Expert.FirstOrDefaultAsync(i => i.UserName == insuranceRequest.UserName);

                if (dbExpert is not null)
                {
                    //user name used by experts
                    return Conflict("User name can't be used.");
                }

                Insurance? dbInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == insuranceModel.UserName);

                //create new user
                if (dbInsurance is null)
                {

                    _context.Insurance.Add(insuranceModel);
                    _context.SaveChanges();

                    return Created();
                }
                //not allowed to use user name
                else
                {
                    //user name used by insurance
                    return Conflict("User name can't be used.");
                }


            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }


        }


        [HttpPut]
        public async Task<IActionResult> UpdateInsurance([FromBody] InsuranceUpdateRequestDto insuranceRequest)
        {
            // check request Structure
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Structure");
            }
            //decode token to get username
            String? reqUserName = Token.DecodeToken(insuranceRequest.Token, _configuration["AppSettings:Token"]);
            if (reqUserName is null)
            {
                //can't decode token
                return Unauthorized("Invalid Token.");
            }
            //get Insurance object from db by token.username
            Insurance? dbInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == reqUserName);
            if (dbInsurance is null)
            {
                //user name not found in insurance db
                return NotFound("Bad user information.");
            }
            
            //verify if new username used by other user
            Insurance? existInsurance = await _context.Insurance.FirstOrDefaultAsync(i => i.UserName == reqUserName);
            if (dbInsurance is null || dbInsurance.Id == existInsurance.Id)
            {

                if (BCrypt.Net.BCrypt.Verify(insuranceRequest.CurrentPassword, dbInsurance.Password))
                {

                    dbInsurance.Address = insuranceRequest.Address;
                    dbInsurance.AgencyCode = insuranceRequest.AgencyCode;
                    dbInsurance.City = insuranceRequest.City;
                    dbInsurance.Name = insuranceRequest.Name;
                    dbInsurance.Password = BCrypt.Net.BCrypt.HashPassword(insuranceRequest.NewPassword);

                    await _context.SaveChangesAsync();

                    return Ok("Insurace Updated");

                }
                else
                {
                    //wrong password
                    return Unauthorized("Confirmation password incorrect.");
                }

            }
            else
            {
                return NotFound("User Name can t be used.");
            }

        }

    }
}