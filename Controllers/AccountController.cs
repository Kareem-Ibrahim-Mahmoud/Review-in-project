using Financial_Stock.DTO;
using Financial_Stock.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Financial_Stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly IConfiguration config;
        public string errors = "";
        private readonly UserManager<ApplicationUser> usermanger;
        public AccountController(UserManager <ApplicationUser> _usermanger,IConfiguration config)
        {

            this.usermanger = _usermanger;
            this.config = config;

        }


        [HttpPost("register")]
        public async Task <IActionResult> Register(RegisterUser userDto)
        {
            if(ModelState.IsValid)
            {
                //savedata 
                ApplicationUser user = new ApplicationUser();
                user.UserName = userDto.UserName;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Email = userDto.Email;
                
                IdentityResult result = await usermanger.CreateAsync(user,userDto.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Add Success");
                }
                else
                {
                   
                    foreach (var item in result.Errors)
                    {
                       // errors.Add(item.Description);
                        errors += item.Description + " ";


                    }
                    //return BadRequest(string.Join(", ", errors));

                    return BadRequest(errors.Trim());
                }

            }
            return BadRequest(ModelState);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {

            if(ModelState.IsValid==true)
            {

                ApplicationUser use = await usermanger.FindByNameAsync(user.Email);
                if(use!=null)
                {
                 bool found=await usermanger.CheckPasswordAsync(use, user.Password);
                    if(found)
                    {
                        //create tokien
                        //Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, use.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, use.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //get role
                        var roles = await usermanger.GetRolesAsync(use);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                        }
                        SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

                        SigningCredentials signincred =
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        //Create token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: config["JWT:ValidIssuer"],//url web api
                            audience: config["JWT:ValidAudiance"],//url consumer angular
                            claims: claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signincred
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expiration = mytoken.ValidTo
                        });


                    }
                    return Unauthorized();

                }
                return Unauthorized();



            }
             return Unauthorized();




        }

    }

}
